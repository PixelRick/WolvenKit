using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using gpm.Installer;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using WolvenKit.Common.Services;
using WolvenKit.Core.Services;
using WolvenKit.Functionality.Services;
using WolvenKit.Interaction;

namespace WolvenKit.ViewModels.Shell
{
    public class StatusBarViewModel : ReactiveObject
    {
        #region Fields

        private const string s_noProjectLoaded =
            "NO PROJECT LOADED | Create a New Project or Open an existing Project to get started with WolvenKit";

        public ISettingsManager _settingsManager { get; set; }
        private readonly ILoggerService _loggerService;

        private readonly AutoInstallerService _autoInstallerService;
        private readonly IProjectManager _projectManager;
        private readonly IProgressService<double> _progressService;

        private readonly ObservableAsPropertyHelper<double> _progress;

        private readonly ObservableAsPropertyHelper<bool> _isIndeterminate;

        private readonly ObservableAsPropertyHelper<string> _currentProject;

        #endregion Fields

        #region Constructors

        public StatusBarViewModel(
            ISettingsManager settingsManager,
            IProjectManager projectManager,
            ILoggerService loggerService,
            IProgressService<double> progressService,

            AutoInstallerService autoInstallerService
            )
        {
            _autoInstallerService = autoInstallerService;
            _settingsManager = settingsManager;
            _projectManager = projectManager;
            _progressService = progressService;
            _loggerService = loggerService;

            IsLoading = false;
            LoadingString = "";

            CheckForUpdatesCommand = ReactiveCommand.CreateFromTask(CheckForUpdates);

            _projectManager
                .WhenAnyValue(
                    x => x.ActiveProject,
                    project => project != null ? project.Name : s_noProjectLoaded)
                .ToProperty(
                    this,
                    x => x.CurrentProject,
                    out _currentProject);

            _ = Observable.FromEventPattern<EventHandler<double>, double>(
                handler => _progressService.ProgressChanged += handler,
                handler => _progressService.ProgressChanged -= handler)
                .Select(_ => _.EventArgs * 100)
                .ToProperty(this, x => x.Progress, out _progress);

            _ = _progressService
                .WhenAnyValue(x => x.IsIndeterminate)
                .ToProperty(this, x => x.IsIndeterminate, out _isIndeterminate);

            _ = _progressService.WhenAnyValue(x => x.IsIndeterminate).Subscribe(b =>
            {
                IsIndeterminate = b;
            });
        }

        #endregion Constructors

        #region Properties

        public double Progress => _progress.Value;

        //public bool IsIndeterminate => _isIndeterminate.Value;

        [Reactive] public bool IsIndeterminate { get; set; }

        public string InternetConnected { get; private set; }

        public bool IsLoading { get; set; }

        public string LoadingString { get; set; }

        public string CurrentProject => _currentProject.Value;

        [Reactive] public string Status { get; set; } = "Ready";

        public object VersionNumber => _settingsManager.GetVersionNumber();

        #endregion Properties

        public ReactiveCommand<Unit, Unit> CheckForUpdatesCommand { get; }
        private async Task CheckForUpdates()
        {
            // 1 API call
            if (!(await _autoInstallerService.CheckForUpdate())
                .Out(out var release))
            {
                _loggerService.Info($"Is update available: {release != null}");
                return;
            }

            _loggerService.Success($"Update available: {release.TagName}");
            _settingsManager.IsUpdateAvailable = true;

            var result = await Interactions.ShowMessageBoxAsync("An update is ready to install for WolvenKit. Exit the app and install it?", "Update available");
            switch (result)
            {
                case WMessageBoxResult.OK:
                case WMessageBoxResult.Yes:
                    if (await _autoInstallerService.Update()) // 1 API call
                    {

                    }
                    break;
            }
        }

    }
}

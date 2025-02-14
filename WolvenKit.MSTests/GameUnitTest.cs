using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Catel.IoC;
using CP77.CR2W;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtoBuf.Meta;
using Splat;
using WolvenKit.Common;
using WolvenKit.Common.Services;
using WolvenKit.Core.Compression;
using WolvenKit.Core.Services;
using WolvenKit.Modkit.RED4.RigFile;
using WolvenKit.RED4.CR2W;
using WolvenKit.RED4.CR2W.Archive;
using WolvenKit.Common.Interfaces;
using WolvenKit.Modkit.RED4;
using WolvenKit.MSTests.Model;

namespace WolvenKit.MSTests
{
    [TestClass]
    public class GameUnitTest
    {
        #region Fields

        internal const string s_testResultsDirectory = "_CR2WTestResults";
        internal static Dictionary<string, IEnumerable<FileEntry>> s_groupedFiles;
        internal static IArchiveManager s_bm;
        internal static bool s_writeToFile;
        private const string s_gameDirectorySetting = "GameDirectory";
        private const string s_writeToFileSetting = "WriteToFile";
        protected static IConfigurationRoot s_config;
        public static string s_gameDirectoryPath;


        #endregion Fields

        #region Methods

        protected static void Setup(TestContext context)
        {
            #region cp77 game dir

            // Init
            Console.WriteLine("BaseTestClass.BaseTestInitialize()");
            s_config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            s_writeToFile = bool.Parse(s_config.GetSection(s_writeToFileSetting).Value);

            // overrides hardcoded appsettings.json
            var cp77Dir = Environment.GetEnvironmentVariable("CP77_DIR", EnvironmentVariableTarget.User);
            if (!string.IsNullOrEmpty(cp77Dir) && new DirectoryInfo(cp77Dir).Exists)
            {
                s_gameDirectoryPath = cp77Dir;
            }
            else
            {
                s_gameDirectoryPath = s_config.GetSection(s_gameDirectorySetting).Value;
            }

            if (string.IsNullOrEmpty(s_gameDirectoryPath))
            {
                throw new ConfigurationErrorsException($"'{s_gameDirectorySetting}' is not configured");
            }

            var gameDirectory = new DirectoryInfo(s_gameDirectoryPath);
            if (!gameDirectory.Exists)
            {
                throw new ConfigurationErrorsException($"'{s_gameDirectorySetting}' is not a valid directory");
            }

            #endregion

            #region oodle

            var gameBinDir = new DirectoryInfo(Path.Combine(gameDirectory.FullName, "bin", "x64"));
            var oodleInfo = new FileInfo(Path.Combine(gameBinDir.FullName, "oo2ext_7_win64.dll"));
            if (!oodleInfo.Exists)
            {
                Assert.Fail("Could not find oo2ext_7_win64.dll.");
            }
            var ass = AppDomain.CurrentDomain.BaseDirectory;
            var appOodleFileName = Path.Combine(ass, "oo2ext_7_win64.dll");
            if (!File.Exists(appOodleFileName))
            {
                oodleInfo.CopyTo(appOodleFileName);
            }
            if (!Oodle.Load())
            {
                Assert.Fail("Could not load oo2ext_7_win64.dll.");
            }

            #endregion

            //protobuf
            RuntimeTypeModel.Default[typeof(IGameArchive)].AddSubType(20, typeof(Archive));

            // IoC
            ServiceLocator.Default.RegisterInstance<ILoggerService>(new CatelLoggerService(false));
            ServiceLocator.Default.RegisterType<IHashService, HashService>();
            ServiceLocator.Default.RegisterType<IProgressService<double>, ProgressService<double>>();
            ServiceLocator.Default.RegisterType<Red4ParserService>();
            ServiceLocator.Default.RegisterType<MeshTools>();        //RIG, Cp77FileService
            ServiceLocator.Default.RegisterType<IArchiveManager, ArchiveManager>();
            ServiceLocator.Default.RegisterType<IModTools, ModTools>();         //Cp77FileService, ILoggerService, IProgress, IHashService, Mesh, Target

            Locator.CurrentMutable.RegisterConstant(new HashService(), typeof(IHashService));


            var hashService = ServiceLocator.Default.ResolveType<IHashService>();
            s_bm = ServiceLocator.Default.ResolveType<IArchiveManager>();

            var archivedir = new DirectoryInfo(Path.Combine(gameDirectory.FullName, "archive", "pc", "content"));
            s_bm.LoadFromFolder(archivedir);
            s_groupedFiles = s_bm.GetGroupedFiles();

            var keyes = s_groupedFiles.Keys.ToList();
            var keystring = string.Join(',', keyes);
            //Console.WriteLine(keystring);
        }

        #endregion Methods
    }
}

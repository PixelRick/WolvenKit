using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class UI_NarrativePlateDef : gamebbScriptDefinition
	{
		[Ordinal(0)] 
		[RED("PlateData")] 
		public gamebbScriptID_Variant PlateData
		{
			get => GetPropertyValue<gamebbScriptID_Variant>();
			set => SetPropertyValue<gamebbScriptID_Variant>(value);
		}

		public UI_NarrativePlateDef()
		{
			PlateData = new();
		}
	}
}

using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class questMenuState_ConditionType : questIUIConditionType
	{
		[Ordinal(0)] 
		[RED("state")] 
		public CEnum<questEUIMenuState> State
		{
			get => GetPropertyValue<CEnum<questEUIMenuState>>();
			set => SetPropertyValue<CEnum<questEUIMenuState>>(value);
		}
	}
}

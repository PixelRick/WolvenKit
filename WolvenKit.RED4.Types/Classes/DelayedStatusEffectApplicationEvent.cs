using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class DelayedStatusEffectApplicationEvent : redEvent
	{
		[Ordinal(0)] 
		[RED("statusEffectEvent")] 
		public CHandle<gameeventsApplyStatusEffectEvent> StatusEffectEvent
		{
			get => GetPropertyValue<CHandle<gameeventsApplyStatusEffectEvent>>();
			set => SetPropertyValue<CHandle<gameeventsApplyStatusEffectEvent>>(value);
		}
	}
}

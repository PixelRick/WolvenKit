using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class audioGameplayTierActivatedASTCD : audioAudioStateTransitionConditionData
	{
		[Ordinal(1)] 
		[RED("gameplayTier")] 
		public CEnum<audioGameplayTier> GameplayTier
		{
			get => GetPropertyValue<CEnum<audioGameplayTier>>();
			set => SetPropertyValue<CEnum<audioGameplayTier>>(value);
		}
	}
}

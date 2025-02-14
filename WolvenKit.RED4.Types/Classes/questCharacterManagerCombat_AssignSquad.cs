using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class questCharacterManagerCombat_AssignSquad : questICharacterManagerCombat_NodeSubType
	{
		[Ordinal(0)] 
		[RED("presetID")] 
		public TweakDBID PresetID
		{
			get => GetPropertyValue<TweakDBID>();
			set => SetPropertyValue<TweakDBID>(value);
		}

		[Ordinal(1)] 
		[RED("puppetRef")] 
		public gameEntityReference PuppetRef
		{
			get => GetPropertyValue<gameEntityReference>();
			set => SetPropertyValue<gameEntityReference>(value);
		}

		[Ordinal(2)] 
		[RED("squadType")] 
		public CEnum<AISquadType> SquadType
		{
			get => GetPropertyValue<CEnum<AISquadType>>();
			set => SetPropertyValue<CEnum<AISquadType>>(value);
		}

		public questCharacterManagerCombat_AssignSquad()
		{
			PresetID = new() { Value = 130861404206 };
			PuppetRef = new() { Names = new() };
			SquadType = Enums.AISquadType.Combat;
		}
	}
}

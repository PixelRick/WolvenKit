using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class worldSaveSanitizationForbiddenAreaNode : worldTriggerAreaNode
	{
		[Ordinal(7)] 
		[RED("safeSpotOffset")] 
		public Vector4 SafeSpotOffset
		{
			get => GetPropertyValue<Vector4>();
			set => SetPropertyValue<Vector4>(value);
		}

		public worldSaveSanitizationForbiddenAreaNode()
		{
			SafeSpotOffset = new();
		}
	}
}

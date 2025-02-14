using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class gameMountAIEvent : AIAIEvent
	{
		[Ordinal(2)] 
		[RED("data")] 
		public CHandle<gameMountEventData> Data
		{
			get => GetPropertyValue<CHandle<gameMountEventData>>();
			set => SetPropertyValue<CHandle<gameMountEventData>>(value);
		}
	}
}

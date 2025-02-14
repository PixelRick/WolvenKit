using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class AIInt32ArgumentInstancePS : AIArgumentInstancePS
	{
		[Ordinal(1)] 
		[RED("value")] 
		public CInt32 Value
		{
			get => GetPropertyValue<CInt32>();
			set => SetPropertyValue<CInt32>(value);
		}
	}
}

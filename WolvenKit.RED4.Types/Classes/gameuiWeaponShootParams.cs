using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class gameuiWeaponShootParams : RedBaseClass
	{
		[Ordinal(0)] 
		[RED("fromWorldPosition")] 
		public Vector4 FromWorldPosition
		{
			get => GetPropertyValue<Vector4>();
			set => SetPropertyValue<Vector4>(value);
		}

		[Ordinal(1)] 
		[RED("forward")] 
		public Vector4 Forward
		{
			get => GetPropertyValue<Vector4>();
			set => SetPropertyValue<Vector4>(value);
		}

		public gameuiWeaponShootParams()
		{
			FromWorldPosition = new();
			Forward = new();
		}
	}
}

using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class scnOutputSocket : RedBaseClass
	{
		[Ordinal(0)] 
		[RED("stamp")] 
		public scnOutputSocketStamp Stamp
		{
			get => GetPropertyValue<scnOutputSocketStamp>();
			set => SetPropertyValue<scnOutputSocketStamp>(value);
		}

		[Ordinal(1)] 
		[RED("destinations")] 
		public CArray<scnInputSocketId> Destinations
		{
			get => GetPropertyValue<CArray<scnInputSocketId>>();
			set => SetPropertyValue<CArray<scnInputSocketId>>(value);
		}

		public scnOutputSocket()
		{
			Stamp = new() { Name = 65535, Ordinal = 65535 };
			Destinations = new();
		}
	}
}

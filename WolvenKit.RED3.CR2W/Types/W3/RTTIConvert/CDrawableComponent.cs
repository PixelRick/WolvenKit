using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CDrawableComponent : CBoundedComponent
	{
		[Ordinal(1)] [RED("drawableFlags")] 		public CEnum<EDrawableFlags> DrawableFlags { get; set;}

		[Ordinal(2)] [RED("lightChannels")] 		public CEnum<ELightChannel> LightChannels { get; set;}

		[Ordinal(3)] [RED("renderingPlane")] 		public CEnum<ERenderingPlane> RenderingPlane { get; set;}

		public CDrawableComponent(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}
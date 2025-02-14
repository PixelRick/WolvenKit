using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehaviorGraphMimicsBlendNode : CBehaviorGraphNode
	{
		[Ordinal(1)] [RED("cachedFirstInputNode")] 		public CPtr<CBehaviorGraphNode> CachedFirstInputNode { get; set;}

		[Ordinal(2)] [RED("cachedSecondInputNode")] 		public CPtr<CBehaviorGraphNode> CachedSecondInputNode { get; set;}

		[Ordinal(3)] [RED("cachedControlVariableNode")] 		public CPtr<CBehaviorGraphValueNode> CachedControlVariableNode { get; set;}

		[Ordinal(4)] [RED("type")] 		public CEnum<EBehaviorMimicBlendType> Type { get; set;}

		public CBehaviorGraphMimicsBlendNode(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}
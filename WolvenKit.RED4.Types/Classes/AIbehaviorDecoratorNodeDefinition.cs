using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class AIbehaviorDecoratorNodeDefinition : AIbehaviorTreeNodeDefinition
	{
		[Ordinal(0)] 
		[RED("child")] 
		public CHandle<AIbehaviorTreeNodeDefinition> Child
		{
			get => GetPropertyValue<CHandle<AIbehaviorTreeNodeDefinition>>();
			set => SetPropertyValue<CHandle<AIbehaviorTreeNodeDefinition>>(value);
		}
	}
}

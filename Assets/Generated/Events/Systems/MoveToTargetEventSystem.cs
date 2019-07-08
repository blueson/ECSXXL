//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class MoveToTargetEventSystem : Entitas.ReactiveSystem<FightEntity> {

    readonly System.Collections.Generic.List<IMoveToTargetListener> _listenerBuffer;

    public MoveToTargetEventSystem(Contexts contexts) : base(contexts.fight) {
        _listenerBuffer = new System.Collections.Generic.List<IMoveToTargetListener>();
    }

    protected override Entitas.ICollector<FightEntity> GetTrigger(Entitas.IContext<FightEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(FightMatcher.MoveToTarget)
        );
    }

    protected override bool Filter(FightEntity entity) {
        return entity.isMoveToTarget && entity.hasMoveToTargetListener;
    }

    protected override void Execute(System.Collections.Generic.List<FightEntity> entities) {
        foreach (var e in entities) {
            
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.moveToTargetListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnMoveToTarget(e);
            }
        }
    }
}
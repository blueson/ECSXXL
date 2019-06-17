//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class AnyLoadPrefabPahtEventSystem : Entitas.ReactiveSystem<FightEntity> {

    readonly Entitas.IGroup<FightEntity> _listeners;
    readonly System.Collections.Generic.List<FightEntity> _entityBuffer;
    readonly System.Collections.Generic.List<IAnyLoadPrefabPahtListener> _listenerBuffer;

    public AnyLoadPrefabPahtEventSystem(Contexts contexts) : base(contexts.fight) {
        _listeners = contexts.fight.GetGroup(FightMatcher.AnyLoadPrefabPahtListener);
        _entityBuffer = new System.Collections.Generic.List<FightEntity>();
        _listenerBuffer = new System.Collections.Generic.List<IAnyLoadPrefabPahtListener>();
    }

    protected override Entitas.ICollector<FightEntity> GetTrigger(Entitas.IContext<FightEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(FightMatcher.LoadPrefabPaht)
        );
    }

    protected override bool Filter(FightEntity entity) {
        return entity.hasLoadPrefabPaht;
    }

    protected override void Execute(System.Collections.Generic.List<FightEntity> entities) {
        foreach (var e in entities) {
            var component = e.loadPrefabPaht;
            foreach (var listenerEntity in _listeners.GetEntities(_entityBuffer)) {
                _listenerBuffer.Clear();
                _listenerBuffer.AddRange(listenerEntity.anyLoadPrefabPahtListener.value);
                foreach (var listener in _listenerBuffer) {
                    listener.OnAnyLoadPrefabPaht(e, component.path);
                }
            }
        }
    }
}
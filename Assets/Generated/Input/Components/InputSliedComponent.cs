//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity sliedEntity { get { return GetGroup(InputMatcher.Slied).GetSingleEntity(); } }
    public SliedComponent slied { get { return sliedEntity.slied; } }
    public bool hasSlied { get { return sliedEntity != null; } }

    public InputEntity SetSlied(CustomVector2 newClickPos, SliedDirection newDir) {
        if (hasSlied) {
            throw new Entitas.EntitasException("Could not set Slied!\n" + this + " already has an entity with SliedComponent!",
                "You should check if the context already has a sliedEntity before setting it or use context.ReplaceSlied().");
        }
        var entity = CreateEntity();
        entity.AddSlied(newClickPos, newDir);
        return entity;
    }

    public void ReplaceSlied(CustomVector2 newClickPos, SliedDirection newDir) {
        var entity = sliedEntity;
        if (entity == null) {
            entity = SetSlied(newClickPos, newDir);
        } else {
            entity.ReplaceSlied(newClickPos, newDir);
        }
    }

    public void RemoveSlied() {
        sliedEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public SliedComponent slied { get { return (SliedComponent)GetComponent(InputComponentsLookup.Slied); } }
    public bool hasSlied { get { return HasComponent(InputComponentsLookup.Slied); } }

    public void AddSlied(CustomVector2 newClickPos, SliedDirection newDir) {
        var index = InputComponentsLookup.Slied;
        var component = (SliedComponent)CreateComponent(index, typeof(SliedComponent));
        component.clickPos = newClickPos;
        component.dir = newDir;
        AddComponent(index, component);
    }

    public void ReplaceSlied(CustomVector2 newClickPos, SliedDirection newDir) {
        var index = InputComponentsLookup.Slied;
        var component = (SliedComponent)CreateComponent(index, typeof(SliedComponent));
        component.clickPos = newClickPos;
        component.dir = newDir;
        ReplaceComponent(index, component);
    }

    public void RemoveSlied() {
        RemoveComponent(InputComponentsLookup.Slied);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherSlied;

    public static Entitas.IMatcher<InputEntity> Slied {
        get {
            if (_matcherSlied == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Slied);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherSlied = matcher;
            }

            return _matcherSlied;
        }
    }
}

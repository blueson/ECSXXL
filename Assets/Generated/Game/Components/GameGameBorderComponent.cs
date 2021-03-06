//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameBorderEntity { get { return GetGroup(GameMatcher.GameBorder).GetSingleEntity(); } }
    public GameBorderComponent gameBorder { get { return gameBorderEntity.gameBorder; } }
    public bool hasGameBorder { get { return gameBorderEntity != null; } }

    public GameEntity SetGameBorder(int newColumns, int newRows) {
        if (hasGameBorder) {
            throw new Entitas.EntitasException("Could not set GameBorder!\n" + this + " already has an entity with GameBorderComponent!",
                "You should check if the context already has a gameBorderEntity before setting it or use context.ReplaceGameBorder().");
        }
        var entity = CreateEntity();
        entity.AddGameBorder(newColumns, newRows);
        return entity;
    }

    public void ReplaceGameBorder(int newColumns, int newRows) {
        var entity = gameBorderEntity;
        if (entity == null) {
            entity = SetGameBorder(newColumns, newRows);
        } else {
            entity.ReplaceGameBorder(newColumns, newRows);
        }
    }

    public void RemoveGameBorder() {
        gameBorderEntity.Destroy();
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
public partial class GameEntity {

    public GameBorderComponent gameBorder { get { return (GameBorderComponent)GetComponent(GameComponentsLookup.GameBorder); } }
    public bool hasGameBorder { get { return HasComponent(GameComponentsLookup.GameBorder); } }

    public void AddGameBorder(int newColumns, int newRows) {
        var index = GameComponentsLookup.GameBorder;
        var component = (GameBorderComponent)CreateComponent(index, typeof(GameBorderComponent));
        component.columns = newColumns;
        component.rows = newRows;
        AddComponent(index, component);
    }

    public void ReplaceGameBorder(int newColumns, int newRows) {
        var index = GameComponentsLookup.GameBorder;
        var component = (GameBorderComponent)CreateComponent(index, typeof(GameBorderComponent));
        component.columns = newColumns;
        component.rows = newRows;
        ReplaceComponent(index, component);
    }

    public void RemoveGameBorder() {
        RemoveComponent(GameComponentsLookup.GameBorder);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameBorder;

    public static Entitas.IMatcher<GameEntity> GameBorder {
        get {
            if (_matcherGameBorder == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameBorder);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameBorder = matcher;
            }

            return _matcherGameBorder;
        }
    }
}

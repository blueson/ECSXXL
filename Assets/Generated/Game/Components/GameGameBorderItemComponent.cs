//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly GameBorderItemComponent gameBorderItemComponent = new GameBorderItemComponent();

    public bool isGameBorderItem {
        get { return HasComponent(GameComponentsLookup.GameBorderItem); }
        set {
            if (value != isGameBorderItem) {
                var index = GameComponentsLookup.GameBorderItem;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : gameBorderItemComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherGameBorderItem;

    public static Entitas.IMatcher<GameEntity> GameBorderItem {
        get {
            if (_matcherGameBorderItem == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameBorderItem);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameBorderItem = matcher;
            }

            return _matcherGameBorderItem;
        }
    }
}
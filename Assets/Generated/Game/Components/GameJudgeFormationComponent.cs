//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly JudgeFormation judgeFormationComponent = new JudgeFormation();

    public bool isJudgeFormation {
        get { return HasComponent(GameComponentsLookup.JudgeFormation); }
        set {
            if (value != isJudgeFormation) {
                var index = GameComponentsLookup.JudgeFormation;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : judgeFormationComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherJudgeFormation;

    public static Entitas.IMatcher<GameEntity> JudgeFormation {
        get {
            if (_matcherJudgeFormation == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.JudgeFormation);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherJudgeFormation = matcher;
            }

            return _matcherJudgeFormation;
        }
    }
}
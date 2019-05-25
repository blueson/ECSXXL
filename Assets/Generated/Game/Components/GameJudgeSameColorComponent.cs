//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public JudgeSameColor judgeSameColor { get { return (JudgeSameColor)GetComponent(GameComponentsLookup.JudgeSameColor); } }
    public bool hasJudgeSameColor { get { return HasComponent(GameComponentsLookup.JudgeSameColor); } }

    public void AddJudgeSameColor(System.Collections.Generic.List<Entitas.IEntity> newLeftList, System.Collections.Generic.List<Entitas.IEntity> newRightList, System.Collections.Generic.List<Entitas.IEntity> newUpList, System.Collections.Generic.List<Entitas.IEntity> newDownList) {
        var index = GameComponentsLookup.JudgeSameColor;
        var component = (JudgeSameColor)CreateComponent(index, typeof(JudgeSameColor));
        component.leftList = newLeftList;
        component.rightList = newRightList;
        component.upList = newUpList;
        component.downList = newDownList;
        AddComponent(index, component);
    }

    public void ReplaceJudgeSameColor(System.Collections.Generic.List<Entitas.IEntity> newLeftList, System.Collections.Generic.List<Entitas.IEntity> newRightList, System.Collections.Generic.List<Entitas.IEntity> newUpList, System.Collections.Generic.List<Entitas.IEntity> newDownList) {
        var index = GameComponentsLookup.JudgeSameColor;
        var component = (JudgeSameColor)CreateComponent(index, typeof(JudgeSameColor));
        component.leftList = newLeftList;
        component.rightList = newRightList;
        component.upList = newUpList;
        component.downList = newDownList;
        ReplaceComponent(index, component);
    }

    public void RemoveJudgeSameColor() {
        RemoveComponent(GameComponentsLookup.JudgeSameColor);
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

    static Entitas.IMatcher<GameEntity> _matcherJudgeSameColor;

    public static Entitas.IMatcher<GameEntity> JudgeSameColor {
        get {
            if (_matcherJudgeSameColor == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.JudgeSameColor);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherJudgeSameColor = matcher;
            }

            return _matcherJudgeSameColor;
        }
    }
}
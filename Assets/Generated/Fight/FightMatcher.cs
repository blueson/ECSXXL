//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class FightMatcher {

    public static Entitas.IAllOfMatcher<FightEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<FightEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<FightEntity> AllOf(params Entitas.IMatcher<FightEntity>[] matchers) {
          return Entitas.Matcher<FightEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<FightEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<FightEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<FightEntity> AnyOf(params Entitas.IMatcher<FightEntity>[] matchers) {
          return Entitas.Matcher<FightEntity>.AnyOf(matchers);
    }
}

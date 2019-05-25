using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameFeature : Feature
{
    public GameFeature(Contexts contexts) : base("GameFeature")
    {
        Add(new CreateBorderSystem(contexts));
        Add(new ExchangeSystem(contexts));
        Add(new MoveCompleteSystem(contexts));
        Add(new GetSameColorSystem(contexts));
        Add(new JudgeSameColorSystem(contexts));
        Add(new EliminateSystem(contexts));
        Add(new ExchangeBackSystem(contexts));
        Add(new FallSystem(contexts));
        Add(new GameDestroySystem(contexts));
        Add(new FillSystem(contexts));
        Add(new JudgeStateSystem(contexts));
        Add(new JudgeFormationSystem(contexts));
        Add(new SameEliminateSystem(contexts));
    }
}

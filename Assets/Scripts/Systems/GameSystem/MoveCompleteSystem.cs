using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveCompleteSystem : ReactiveSystem<GameEntity>
{
    public MoveCompleteSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MoveComplete);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isMoveComplete == true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            entity.isMoveComplete = false;
            entity.isGetSomeColor = true;
        }
    }
}

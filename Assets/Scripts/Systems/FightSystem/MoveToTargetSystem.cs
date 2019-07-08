using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveToTargetSystem : ReactiveSystem<FightEntity>
{
    public MoveToTargetSystem(Contexts context) : base(context.fight)
    {
    }

    protected override void Execute(List<FightEntity> entities)
    {
        
    }

    protected override bool Filter(FightEntity entity)
    {
        return entity.isMoveToTarget;
    }

    protected override ICollector<FightEntity> GetTrigger(IContext<FightEntity> context)
    {
        return context.CreateCollector(FightMatcher.MoveToTarget);
    }
}

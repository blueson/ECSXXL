using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EnemyInfoSystem : ReactiveSystem<FightEntity>
{
    public EnemyInfoSystem(Contexts context) : base(context.fight)
    {
    }

    protected override void Execute(List<FightEntity> entities)
    {
        foreach (var entity in entities)
        {
            var dis = Vector2.Distance(entity.rolePos.pos, entity.enemyInfo.enemy.rolePos.pos);
            if (dis < 0.5)
            {

            }
            else
            {
                entity.isMoveToTarget = true;
            }
        }
    }

    protected override bool Filter(FightEntity entity)
    {
        return entity.hasEnemyInfo;
    }

    protected override ICollector<FightEntity> GetTrigger(IContext<FightEntity> context)
    {
        return context.CreateCollector(FightMatcher.EnemyInfo);
    }
}

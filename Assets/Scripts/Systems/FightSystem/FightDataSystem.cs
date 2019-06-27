using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FightDataSystem : ReactiveSystem<FightEntity>,IInitializeSystem
{
    public FightDataSystem(Contexts context) : base(context.fight)
    {

    }

    public void Initialize()
    {
        var fightData = CreaterService.Instance.CreateFightData();

        for(int i =0;i<fightData.fightData.heroCount;i++)
        {
            CreaterService.Instance.CreateHero(i);
        }

        for(int i=0;i<fightData.fightData.enemyCount;i++)
        {
            CreaterService.Instance.CreateEnemy(i);
        }
    }

    protected override void Execute(List<FightEntity> entities)
    {
        var fightData = entities.SingleEntity<FightEntity>().fightData;
    }

    protected override bool Filter(FightEntity entity)
    {
        return entity.hasFightData;
    }

    protected override ICollector<FightEntity> GetTrigger(IContext<FightEntity> context)
    {
        return context.CreateCollector(FightMatcher.FightData);
    }
}

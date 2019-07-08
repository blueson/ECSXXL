using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SearchEnemySystem : ReactiveSystem<FightEntity>
{
    private Contexts _contexts;
    public SearchEnemySystem(Contexts contexts) : base(contexts.fight)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<FightEntity> entities)
    {
        foreach(var entity in entities)
        {
            var enemy = GetNextEnemyService.Instance.GetNextEnemy(entity);
            entity.AddEnemyInfo(enemy);
        }
    }

    protected override bool Filter(FightEntity entity)
    {
        return entity.isSearchEnemy;
    }

    protected override ICollector<FightEntity> GetTrigger(IContext<FightEntity> context)
    {
        return context.CreateCollector(FightMatcher.SearchEnemy);
    }
}

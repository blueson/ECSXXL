using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EliminateSystem : ReactiveSystem<GameEntity>
{
    public EliminateSystem(Contexts context) : base(context.game)
    {
    }

    protected override void Execute(List<GameEntity> entities)
    {
        List<IEntity> eliminaList = new List<IEntity>();

        foreach(var entity in entities)
        {
            if(entity.judgeSameState.state == JudgeState.NONE) 
            {
                eliminaList.Add(entity);
            }

            var left = entity.judgeSameColor.leftList;
            var right = entity.judgeSameColor.rightList;
            var up = entity.judgeSameColor.upList;
            var down = entity.judgeSameColor.downList;

            if(left.Count + right.Count >= 2)
            {
                eliminaList.AddRange(left);
                eliminaList.AddRange(right);
            }

            if(up.Count + down.Count >= 2)
            {
                eliminaList.AddRange(up);
                eliminaList.AddRange(down);
            }
        }

        GameEntity removeEntity;
        for (int i = 0; i < eliminaList.Count; i++)
        {
            removeEntity = eliminaList[i] as GameEntity;
            removeEntity.isGameDestroy = true;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasEliminate && entity.eliminate.canEliminate;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Eliminate);
    }
}

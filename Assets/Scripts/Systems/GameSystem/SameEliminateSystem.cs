using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SameEliminateSystem : ReactiveSystem<GameEntity>
{
    Contexts _context;

    public SameEliminateSystem(Contexts context) : base(context.game)
    {
        _context = context;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(GameEntity entity in entities)
        { 
            for(int column = 0;column<entity.gameBorder.columns;column++)
            { 
                for(int row = 0;row < entity.gameBorder.rows;row++)
                {
                    GameEntity item = _context.game.GetEntitiesWithItemIndex(new Vector2(column, row)).SingleEntity();

                    if(item.loadPrefab.path == entity.loadPrefab.path) 
                    {
                        item.isGameDestroy = true;
                    }
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isGameDestroy && entity.hasJudgeSameState 
            && entity.judgeSameState.state == JudgeState.JUDGE_SAME_COLOR;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameDestroy);
    }
}

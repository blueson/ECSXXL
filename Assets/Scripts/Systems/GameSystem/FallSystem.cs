using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;

public class FallSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public FallSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var gameBorad = _contexts.game.gameBorder;

        for (var column = 0; column < gameBorad.columns; column++)
        {
            for (var row = 1; row < gameBorad.rows; row++)
            {
                var entitys = _contexts.game.GetEntitiesWithItemIndex(new Vector2(column, row))
                    .Where(e => e.isMovable).ToArray();

                foreach(var entity in entitys)
                {
                    MoveDown(entity);
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return !entity.isGameBorderItem;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameBorderItem.Removed());
    }

    private void MoveDown(GameEntity entity)
    {
        int nextRow = GetNextEmptyService.Instance.GetNextRow(new CustomVector2((int)entity.itemIndex.index.x,(int)entity.itemIndex.index.y));
        if(nextRow < entity.itemIndex.index.y)
        {
            entity.ReplaceItemIndex(new Vector2(entity.itemIndex.index.x, nextRow));
        }
    }
}

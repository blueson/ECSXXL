using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FillSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public FillSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var gameBorad = _contexts.game.gameBorder;

        for (var column = 0; column < gameBorad.columns; column++)
        {
            var pos = gameBorad.rows + 1;
            var nextRow = GetNextEmptyService.Instance.GetNextRow(new CustomVector2(column, pos));

            for (var row = nextRow; row < gameBorad.rows; row++)
            {
                var entitys = _contexts.game.GetEntitiesWithItemIndex(new Vector2(column, row));
                if(entitys.Count == 0) 
                {
                    CreaterService.Instance.CreateBall(new Vector2(column, row));
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
}

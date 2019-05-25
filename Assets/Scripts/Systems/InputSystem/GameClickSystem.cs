using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameClickSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;
    private GameClickComponent _clickComponent;

    public GameClickSystem(Contexts context) : base(context.input)
    {
        _contexts = context;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var inputEntity = entities.SingleEntity();
        var click = inputEntity.gameClick;

        var gameEntity = _contexts.game.GetEntitiesWithItemIndex(new Vector2(click.x, click.y));
        bool canMove = false;
        if(gameEntity != null) 
        {
            canMove = gameEntity.SingleEntity().isMovable;
        }

        if (canMove)
        {
            if (_clickComponent == null)
            {
                _clickComponent = click;
            }
            else
            {
                if((click.x == _clickComponent.x - 1 && click.y == _clickComponent.y) 
                    || (click.x == _clickComponent.x + 1 && click.y == _clickComponent.y)
                    || (click.y == _clickComponent.y - 1 && click.x == _clickComponent.x)
                    || (click.y == _clickComponent.y + 1 && click.x == _clickComponent.x))
                {
                    ReplaceItemIndex(click);
                    ReplaceItemIndex(_clickComponent);
                    _clickComponent = null;
                }
            }
        }
    }

    private void ReplaceItemIndex(GameClickComponent click) 
    {
        var entitys = _contexts.game.GetEntitiesWithItemIndex(new Vector2(click.x, click.y));
        foreach(var entity in entitys)
        {
            entity.ReplaceExchange(ExchangeState.START);
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasGameClick;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.GameClick);
    }
}

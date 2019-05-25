using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SliedSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;
    public SliedSystem(Contexts context) : base(context.input)
    {
        _contexts = context;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        if (entities.Count != 1)
        {
            return;
        }

        var entity = entities.SingleEntity();
        var pos = entity.slied.clickPos;
        bool canMove = _contexts.game.GetEntitiesWithItemIndex(new Vector2(pos.x, pos.y)).SingleEntity().isMovable;

        if (canMove)
        {
            var nextPos = NextPos(entity);
            _contexts.input.ReplaceGameClick(nextPos.x, nextPos.y);
            //Debug.Log(entity.slied.dir);
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasSlied;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Slied);
    }

    private CustomVector2 NextPos(InputEntity entity)
    {
        var x = entity.slied.clickPos.x;
        var y = entity.slied.clickPos.y;

        switch (entity.slied.dir)
        {
            case SliedDirection.LEFT:
                x--;
                break;
            case SliedDirection.RIGHT:
                x++;
                break;
            case SliedDirection.UP:
                y++;
                break;
            case SliedDirection.DOWN:
                y--;
                break;
        }

        x = Mathf.Min(x, _contexts.game.gameBorder.columns - 1);
        x = Mathf.Max(x, 0);

        y = Mathf.Min(y, _contexts.game.gameBorder.rows - 1);
        y = Mathf.Max(y, 0);

        return new CustomVector2(x, y);
    }
}

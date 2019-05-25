using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CreateBorderSystem : ReactiveSystem<GameEntity>,IInitializeSystem
{
    private Contexts _contexts;

    public CreateBorderSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    public void Initialize()
    {
        var gameBorder = CreaterService.Instance.CreateBorder().gameBorder;

        Vector2 index = new Vector2();
        for (var x = 0; x < gameBorder.columns; x++)
        {
            for (var y = 0; y < gameBorder.rows; y++)
            {
                index.x = x;
                index.y = y;
                if (RandomCreateBlocker())
                {
                    CreaterService.Instance.CreateBlocker(index);
                }
                else
                {
                    CreaterService.Instance.CreateBall(index);
                }
            }
        }
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var gameBorder = entities.SingleEntity<GameEntity>().gameBorder;
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameBorder;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameBorder);
    }

    private bool RandomCreateBlocker()
    {
        int random = Random.Range(0, 10);
        return random == 1;
    }
}

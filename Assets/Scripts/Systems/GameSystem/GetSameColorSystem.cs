using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class GetSameColorSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public GetSameColorSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GetSomeColor);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isGetSomeColor;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            var left = JudgeLeft(entity);
            var right = JudgeRight(entity);
            var up = JudgeUp(entity);
            var down = JudgeDown(entity);

            entity.ReplaceJudgeSameColor(left, right, up, down);
            entity.isGetSomeColor = false;
        }
    }

    private List<IEntity> JudgeLeft(GameEntity entity)
    {
        var sameColor = entity.loadPrefab.path;
        var index = entity.itemIndex.index;
        List<IEntity> sameColorList = new List<IEntity>();

        //左侧
        for (int x = (int)index.x - 1; x >= 0; x--)
        {
            if (!AddSameColor(sameColorList, sameColor, x, (int)index.y))
            {
                break;
            }
        }
        return sameColorList;
    }

    private List<IEntity> JudgeRight(GameEntity entity)
    {
        var sameColor = entity.loadPrefab.path;
        var index = entity.itemIndex.index;
        List<IEntity> sameColorList = new List<IEntity>();

        //右侧
        for (int x = (int)index.x + 1; x < _contexts.game.gameBorder.columns; x++)
        {
            if (!AddSameColor(sameColorList, sameColor, x, (int)index.y))
            {
                break;
            }
        }
        return sameColorList;
    }

    private List<IEntity> JudgeUp(GameEntity entity)
    {
        var sameColor = entity.loadPrefab.path;
        var index = entity.itemIndex.index;
        List<IEntity> sameColorList = new List<IEntity>();

        //上侧
        for (int y = (int)index.y + 1; y < _contexts.game.gameBorder.rows; y++)
        {
            if (!AddSameColor(sameColorList, sameColor, (int)index.x, y))
            {
                break;
            }
        }
        return sameColorList;
    }

    private List<IEntity> JudgeDown(GameEntity entity)
    {
        var sameColor = entity.loadPrefab.path;
        var index = entity.itemIndex.index;
        List<IEntity> sameColorList = new List<IEntity>();

        //下侧
        for (int y = (int)index.y - 1; y >= 0; y--)
        {
            if (!AddSameColor(sameColorList, sameColor, (int)index.x, y))
            {
                break;
            }
        }
        return sameColorList;
    }

    private bool AddSameColor(List<IEntity> sameColorList,string sameColor, int x,int y) 
    {
        var returnValue = IsSameColor(sameColor, x, y);
        if (!returnValue.Item1)
        {
            return false;
        }

        sameColorList.Add(returnValue.Item2);
        return true;
    }

    private Tuple<bool,GameEntity> IsSameColor(string color, int x, int y)
    {
        var entitys = _contexts.game.GetEntitiesWithItemIndex(new Vector2(x, y));
        if (entitys.Count != 1) return new Tuple<bool, GameEntity>(false,null);

        var entity = entitys.SingleEntity();

        if (!entity.isMovable) return new Tuple<bool, GameEntity>(false,entity);

        return new Tuple<bool,GameEntity>(entity.loadPrefab.path == color,entity);
    }
}

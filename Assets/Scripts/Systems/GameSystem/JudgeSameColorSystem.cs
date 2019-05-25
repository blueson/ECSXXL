using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class JudgeSameColorSystem : ReactiveSystem<GameEntity>
{
    public JudgeSameColorSystem(Contexts context) : base(context.game)
    {
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        { 
            if(IsComplete(entity))
            {
                //匹配成功
                //entity.ReplaceEliminate(true);
                entity.isJudgeFormation = true;
            }
            else
            {
                //匹配不成功
                entity.ReplaceEliminate(false);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasJudgeSameColor;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.JudgeSameColor);
    }

    private bool IsComplete(GameEntity entity)
    {
        var leftCount = entity.judgeSameColor.leftList.Count;
        var rightCount = entity.judgeSameColor.rightList.Count;
        var upCount = entity.judgeSameColor.upList.Count;
        var downCount = entity.judgeSameColor.downList.Count;

        return leftCount + rightCount >= 2 || upCount + downCount >= 2;
    }
}

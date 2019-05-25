using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class JudgeFormationSystem : ReactiveSystem<GameEntity>
{
    public JudgeFormationSystem(Contexts context) : base(context.game)
    {

    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            if(JudgeSameColor(entity.judgeSameColor))
            {
                entity.ReplaceJudgeSameState(JudgeState.JUDGE_SAME_COLOR);
            }
            else if(JudgeHorColor(entity.judgeSameColor))
            {
                entity.ReplaceJudgeSameState(JudgeState.JUDGE_HOR);
            }
            else if (JudgeVecColor(entity.judgeSameColor))
            {
                entity.ReplaceJudgeSameState(JudgeState.JUDGE_VEC);
            }
            else if (JudgeExplode(entity.judgeSameColor))
            {
                entity.ReplaceJudgeSameState(JudgeState.JUDGE_EXPLODE);
            }

            entity.ReplaceEliminate(true);
            entity.isJudgeFormation = false;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isJudgeFormation;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.JudgeFormation);
    }

    private bool JudgeSameColor(JudgeSameColor sameColor)
    { 
        if(sameColor.leftList.Count + sameColor.rightList.Count >= 4)
        {
            return true;
        }

        if(sameColor.upList.Count + sameColor.downList.Count >= 4)
        {
            return true;
        }
        return false;
    }

    private bool JudgeHorColor(JudgeSameColor sameColor)
    { 
        if(sameColor.leftList.Count + sameColor.rightList.Count >= 3)
        {
            return true;
        }

        return false;
    }

    private bool JudgeVecColor(JudgeSameColor sameColor)
    {
        if (sameColor.upList.Count + sameColor.downList.Count >= 3)
        {
            return true;
        }
        return false;
    }

    private bool JudgeExplode(JudgeSameColor sameColor)
    { 
        if(sameColor.leftList.Count + sameColor.rightList.Count == 2 
            && sameColor.upList.Count + sameColor.downList.Count == 2)
        {
            return true;
        }
        return false;
    }
}

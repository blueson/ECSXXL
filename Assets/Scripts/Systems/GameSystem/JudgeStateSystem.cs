using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class JudgeStateSystem : ReactiveSystem<GameEntity>
{
    public JudgeStateSystem(Contexts context) : base(context.game)
    {
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(GameEntity entity in entities) 
        {
            var name = "";
            switch(entity.judgeSameState.state)
            {
                case JudgeState.JUDGE_SAME_COLOR:
                    name = ConstData.path + ConstData.allName;
                    break;
                case JudgeState.JUDGE_HOR:
                    name = entity.loadPrefab.path + ConstData.horName;
                    break;
                case JudgeState.JUDGE_VEC:
                    name = entity.loadPrefab.path + ConstData.vecName;
                    break;
                case JudgeState.JUDGE_EXPLODE:
                    name = entity.loadPrefab.path + ConstData.explodeName;
                    break;
            }

            entity.ReplaceSpecial(name);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasJudgeSameState && entity.judgeSameState.state != JudgeState.NONE;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.JudgeSameState);
    }
}

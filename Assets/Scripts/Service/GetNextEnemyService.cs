using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNextEnemyService
{
    public static GetNextEnemyService Instance { private set; get; } = new GetNextEnemyService();

    private Contexts _contexts;

    public void Init(Contexts contexts)
    {
        _contexts = contexts;
    }

    public FightEntity GetNextEnemy(FightEntity entity)
    {
        var entitys = _contexts.fight.GetGroup(FightMatcher.FightRoleType);
        FightEntity enemy = null;
        var entityPos = entity.rolePos.pos;
        float dis = -1;
        foreach(var enemyEntity in entitys)
        {
            if(enemyEntity.fightRoleType.roleType != entity.fightRoleType.roleType)
            {
                if (enemy == null) {
                    enemy = enemyEntity;
                    dis = Vector2.Distance(entityPos, enemyEntity.rolePos.pos);
                }
                else
                {
                    var offsetDis = Vector2.Distance(entityPos, enemyEntity.rolePos.pos);
                    if (dis < offsetDis){
                        enemy = enemyEntity;
                        dis = offsetDis;
                    }
                }
            }
        }

        return enemy;
    }
}

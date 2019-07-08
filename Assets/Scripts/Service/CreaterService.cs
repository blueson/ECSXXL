using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CreaterService
{
    private Contexts _contexts;
    private static CreaterService _instance;
    public static CreaterService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CreaterService();
            }

            return _instance;
        }
    }

    public void init(Contexts contexts) 
    {
        _contexts = contexts;
    }

    public GameEntity CreateBorder()
    {
        var entity = _contexts.game.CreateEntity();
        entity.AddGameBorder(8, 9);
        return entity;
    }

    /// <summary>
    /// 创建可以移动的物体
    /// </summary>
    /// <param name="index">Index.</param>
    public GameEntity CreateBall(Vector2 index)
    {
        var entity = _contexts.game.CreateEntity();
        entity.isGameBorderItem = true;
        entity.isMovable = true;
        entity.AddItemIndex(index);
        entity.AddJudgeSameState(JudgeState.NONE);
        int randomIndex = Random.Range(0, 5);
        entity.AddLoadPrefab(ConstData.itemPrefab + randomIndex);
        return entity;
    }

    /// <summary>
    /// 创建障碍物体
    /// </summary>
    /// <returns>The blocker.</returns>
    /// <param name="index">Index.</param>
    public GameEntity CreateBlocker(Vector2 index)
    {
        var entity = _contexts.game.CreateEntity();
        entity.isGameBorderItem = true;
        entity.isMovable = false;
        entity.AddItemIndex(index);
        entity.AddLoadPrefab(ConstData.blockPrefab);
        return entity;
    }

    public FightEntity CreateFightData()
    {
        var entity = _contexts.fight.CreateEntity();
        entity.AddFightData(5, 5);
        return entity;
    }

    public FightEntity CreateHero(int index)
    {
        var entity = _contexts.fight.CreateEntity();
        entity.AddFightRoleType(RoleType.HERO);
        entity.AddLoadPrefabPaht("Prefabs/Role/Role2");
        entity.AddRolePos(new Vector2(-index / 3, index % 3 + 2));
        entity.isSearchEnemy = true;
        return entity;
    }

    public FightEntity CreateEnemy(int index)
    {
        var entity = _contexts.fight.CreateEntity();
        entity.AddFightRoleType(RoleType.ENMEY);
        entity.AddLoadPrefabPaht("Prefabs/Role/Role1");
        entity.AddRolePos(new Vector2(index / 3, index % 3 + 2));
        entity.isSearchEnemy = true;
        return entity;
    }
}

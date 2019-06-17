using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRolePrefabService : IAnyLoadPrefabPahtListener
{
    public static LoadRolePrefabService Instance { get; private set; } = new LoadRolePrefabService();

    private Contexts _contexts;
    private Transform _heroParent;
    private Transform _enemyParent;

    public void Init(Contexts contexts,Transform gameController)
    {
        _contexts = contexts;
        CreateRoleParent(gameController);
        contexts.fight.CreateEntity().AddAnyLoadPrefabPahtListener(this);
    }

    private void CreateRoleParent(Transform gameController)
    {
        _heroParent = new GameObject("heroParent").transform;
        _heroParent.parent = gameController;

        _enemyParent = new GameObject("enemyParent").transform;
        _enemyParent.parent = gameController;
    }

    public void OnAnyLoadPrefabPaht(FightEntity entity, string path)
    {
        Transform parent;
        if (entity.fightRoleType.roleType == RoleType.HERO)
        {
            parent = _heroParent;
        }
        else
        {
            parent = _enemyParent;
        }

        GameObject go = Resources.Load<GameObject>(path);
        var view = GameObject.Instantiate(go,parent).GetComponent<FightView>();
        view.Link(entity, _contexts);
    }
}

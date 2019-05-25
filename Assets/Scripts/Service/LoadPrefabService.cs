using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class LoadPrefabService : IAnyLoadPrefabListener
{
    public static LoadPrefabService Instance { get; private set; } = new LoadPrefabService();
    private Contexts _contexts;
    private Transform _settleParent;
    private Transform _moveParent;

    public virtual void Init(Contexts contexts, Transform gameController)
    {
        _contexts = contexts;
        CreateSubParent(gameController);
        contexts.game.CreateEntity().AddAnyLoadPrefabListener(this);
    }

    private void CreateSubParent(Transform parent)
    {
        _settleParent = new GameObject("settle").transform;
        _settleParent.SetParent(parent);
        _moveParent = new GameObject("move").transform;
        _moveParent.SetParent(parent);
    }

    public void OnAnyLoadPrefab(GameEntity entity, string path)
    {
        Transform temp;

        if (entity.isMovable)
        {
            temp = _moveParent;
        }
        else
        {
            temp = _settleParent;
        }

        GameObject go = Resources.Load<GameObject>(path);
        var view = Object.Instantiate(go, temp).GetComponent<GameItemView>();
        view.Link(entity, _contexts);
    }
}

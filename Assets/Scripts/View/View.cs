using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.Unity;
using DG.Tweening;

public class View : MonoBehaviour,IView,IGameDestroyListener
{
    protected GameEntity _gameEntity;
    public virtual void Link(IEntity entity, Contexts contexts)
    {
        if (entity is GameEntity)
        {
            _gameEntity = entity as GameEntity;
        }
        else
        {
            Debug.LogError("entity 不是GameEntity");
            return;
        }

        gameObject.Link(entity);
        _gameEntity.AddGameDestroyListener(this);
    }

    public virtual void OnGameDestroy(GameEntity entity)
    {
        gameObject.Unlink();
    }
}

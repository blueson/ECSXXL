using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using DG.Tweening;

public class GameItemView : View,IItemIndexListener,ISpecialListener
{
    public override void Link(IEntity entity, Contexts contexts)
    {
        base.Link(entity, contexts);
        _gameEntity.AddItemIndexListener(this);
        _gameEntity.AddSpecialListener(this);
        transform.position = new Vector2(_gameEntity.itemIndex.index.x,contexts.game.gameBorder.rows);
    }

    public void OnItemIndex(GameEntity entity, Vector2 index)
    {
        transform.DOMove(new Vector3(index.x, index.y, 0), 0.3f)
            .OnComplete(() => entity.isMoveComplete = true);
    }

    public override void OnGameDestroy(GameEntity entity)
    {
        base.OnGameDestroy(entity);
        var time = 0.5f;
        transform.DOScale(0.5f, time)
            .OnComplete(() => Destroy(gameObject));
    }

    public void OnSpecial(GameEntity entity, string specialName)
    {
        Debug.Log(specialName);
        var animator = transform.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(specialName);
    }
}

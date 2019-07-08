using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using DG.Tweening;

public class FightView : MonoBehaviour,IView,IRolePosListener,IMoveToTargetListener
{
    private FightEntity _fightEntity;
    public void Link(IEntity entity, Contexts contexts)
    {
        if(entity is FightEntity)
        {
            _fightEntity = entity as FightEntity;
        }
        else
        {
            Debug.Log("不是FightEntity");
            return;
        }

        _fightEntity.AddRolePosListener(this);
        _fightEntity.AddMoveToTargetListener(this);
        gameObject.Link(entity);
    }

    public void OnMoveToTarget(FightEntity entity)
    {
        var tween = transform.DOMove(LoadRolePrefabService.Instance.GetWorldPos(entity.enemyInfo.enemy), 2);
        tween.onComplete = () => {
            Debug.Log("移动完成");
        };
    }

    public void OnRolePos(FightEntity entity, Vector2 pos)
    {
        transform.localPosition = pos;
    }

    private void OnDestroy()
    {
        gameObject.Unlink();
    }
}

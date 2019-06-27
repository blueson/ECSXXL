using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class FightView : MonoBehaviour,IView,IRolePosListener
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
        gameObject.Link(entity);
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

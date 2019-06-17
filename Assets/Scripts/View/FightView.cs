using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class FightView : MonoBehaviour,IView
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

        gameObject.Link(entity);
    }

    private void OnDestroy()
    {
        gameObject.Unlink();
    }
}

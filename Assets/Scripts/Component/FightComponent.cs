using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// 战斗双方数量
/// </summary>
[Fight,Unique]
public class FightData : IComponent
{
    public int heroCount;

    public int enemyCount;
}

/// <summary>
/// 战斗角色类型
/// </summary>
[Fight]
public class FightRoleType : IComponent
{
    public RoleType roleType;
}

[Fight, Event(EventTarget.Any)]
public class LoadPrefabPaht : IComponent
{
    public string path;
}

[Fight,Event(EventTarget.Self,
    Entitas.CodeGeneration.Attributes.EventType.Added,1)]
public class RolePos : IComponent
{
    [EntityIndex]
    public Vector2 pos;
}

[Fight]
public class SearchEnemy : IComponent
{

}

[Fight]
public class EnemyInfo : IComponent
{
    public FightEntity enemy;
}

[Fight,Event(EventTarget.Self,
    Entitas.CodeGeneration.Attributes.EventType.Added,1)]
public class MoveToTarget : IComponent
{

}
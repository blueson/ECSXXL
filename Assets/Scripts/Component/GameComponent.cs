using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// 游戏面板
/// </summary>
[Game,Unique]
public class GameBorderComponent : IComponent
{
    /// <summary>
    /// 行
    /// </summary>
    public int columns;

    /// <summary>
    /// 列
    /// </summary>
    public int rows;
}

/// <summary>
/// 是否是游戏面板里的物体
/// </summary>
[Game]
public class GameBorderItemComponent : IComponent
{

}

/// <summary>
/// 物体位置组件
/// </summary>
[Game, Event(EventTarget.Self, Entitas.CodeGeneration.Attributes.EventType.Added,1)]
public class ItemIndexComponent : IComponent
{
    [EntityIndex]
    public Vector2 index;
}

/// <summary>
/// 销毁组件
/// </summary>
[Game, Event(EventTarget.Self)]
public class GameDestroyComponent : IComponent
{ 

}

/// <summary>
/// 加载组件
/// </summary>
[Game, Event(EventTarget.Any)]
public class LoadPrefabComponent : IComponent
{
    /// <summary>
    /// prefab路径
    /// </summary>
    public string path;
}

/// <summary>
/// 元素是否可以移动的组件
/// </summary>
[Game]
public class MovableComponent : IComponent
{ 
    
}

[Game]
public class ExchangeComponent : IComponent
{
    public ExchangeState exchangeState;
}

[Game]
public class MoveComplete : IComponent
{ 
    
}

[Game]
public class GetSomeColor : IComponent
{ 
    
}

[Game]
public class JudgeSameColor : IComponent
{
    public List<IEntity> leftList;
    public List<IEntity> rightList;
    public List<IEntity> upList;
    public List<IEntity> downList;
}

[Game]
public class Eliminate : IComponent
{
    public bool canEliminate;
}

[Game]
public class JudgeFormation : IComponent
{ 

}

[Game]
public class JudgeSameState : IComponent
{
    public JudgeState state;
}

[Game,Event(EventTarget.Self)]
public class Special : IComponent
{
    public string specialName;
}
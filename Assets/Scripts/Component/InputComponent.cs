using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input,Unique]
public class GameClickComponent : IComponent
{
    public int x;
    public int y;
}

[Input,Unique]
public class SliedComponent : IComponent
{
    public CustomVector2 clickPos;
    public SliedDirection dir;
}

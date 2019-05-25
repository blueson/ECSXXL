using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class InputFeature : Feature
{
    public InputFeature(Contexts contexts) : base("InputFeature")
    {
        Add(new GameClickSystem(contexts));
        Add(new SliedSystem(contexts));
    }
}

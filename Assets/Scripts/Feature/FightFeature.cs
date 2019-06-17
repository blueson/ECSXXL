﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FightFeature : Feature
{
    public FightFeature(Contexts contexts) : base("FightFeature")
    {
        Add(new FightDataSystem(contexts));
    }
}
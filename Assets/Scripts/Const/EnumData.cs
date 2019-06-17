using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SliedDirection
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}


public enum ExchangeState
{ 
    NONE,
    START,
    EXCHANGE,
    EXCHANGE_BACK,
    END
}

public enum JudgeState
{ 
    NONE,
    JUDGE_SAME_COLOR,
    JUDGE_HOR,
    JUDGE_VEC,
    JUDGE_EXPLODE
}

public enum RoleType
{
    HERO,
    ENMEY
}
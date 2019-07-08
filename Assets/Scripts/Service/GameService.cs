using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService
{
    public GameService(Contexts contexts,Transform gameController)
    {
        LoadPrefabService.Instance.Init(contexts, gameController);
        LoadRolePrefabService.Instance.Init(contexts, gameController);
        CreaterService.Instance.init(contexts);
        GetNextEmptyService.Instance.Init(contexts);
        GetNextEnemyService.Instance.Init(contexts);
    }
}

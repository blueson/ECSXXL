using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    Systems _systems;
    void Start()
    {
        Contexts contexts = Contexts.sharedInstance;
        _systems = new GameFeature(contexts)
            .Add(new FightFeature(contexts))
            .Add(new FightEventSystems(contexts))
            .Add(new GameEventSystems(contexts))
            .Add(new InputFeature(contexts));

        new GameService(contexts, transform);
        _systems.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}

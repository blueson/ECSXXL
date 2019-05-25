using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;

public class GameDestroySystem : ICleanupSystem
{
    private Contexts _context;
    private IGroup<GameEntity> _group;

    public GameDestroySystem(Contexts contexts)
    {
        _context = contexts;
        _group = _context.game.GetGroup(GameMatcher.GameDestroy);
    }

    public void Cleanup()
    {
        foreach(var entity in _group.GetEntities())
        {
            entity.Destroy();
        }
    }
}

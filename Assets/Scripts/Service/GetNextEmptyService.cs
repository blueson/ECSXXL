using System;
using UnityEngine;
using System.Linq;

public class GetNextEmptyService
{
    public static GetNextEmptyService Instance { private set; get; } = new GetNextEmptyService();

    private Contexts _contexts;

    public void Init(Contexts contexts)
    {
        _contexts = contexts;
    }

    public int GetNextRow(CustomVector2 pos)
    {
        int row = pos.y;

        for (var y = pos.y - 1; y >= 0; y--)
        {
            var entitys = _contexts.game.GetEntitiesWithItemIndex(new Vector2(pos.x, y)).ToArray();

            if(entitys.Length == 0)
            {
                row = y;
            }
            else
            { 
                if(!entitys.Single().isMovable)
                {
                    continue;
                }

                break;
            }
        }

        return row;
    }
}

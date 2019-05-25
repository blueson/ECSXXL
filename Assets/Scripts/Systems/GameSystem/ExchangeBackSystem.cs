using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class ExchangeBackSystem : ReactiveSystem<GameEntity>
{
    public ExchangeBackSystem(Contexts context) : base(context.game)
    {

    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            entity.ReplaceExchange(ExchangeState.EXCHANGE_BACK);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasEliminate && !entity.eliminate.canEliminate &&
            entity.hasExchange && entity.exchange.exchangeState == ExchangeState.EXCHANGE;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Eliminate);
    }
}

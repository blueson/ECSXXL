using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class ExchangeSystem : ReactiveSystem<GameEntity>
{
    public ExchangeSystem(Contexts context) : base(context.game)
    {

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Exchange);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasExchange
            && (entity.exchange.exchangeState == ExchangeState.START
            || entity.exchange.exchangeState == ExchangeState.EXCHANGE_BACK);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if(entities.Count == 2)
        {
            Exchange(entities[0], entities[1]);
            SetExchangeState(entities[0]);
            SetExchangeState(entities[1]);
        }
    }

    private void Exchange(GameEntity one,GameEntity two)
    {
        var onePos = one.itemIndex.index;
        var twoPos = two.itemIndex.index;

        one.ReplaceItemIndex(twoPos);
        two.ReplaceItemIndex(onePos);
    }

    private void SetExchangeState(GameEntity entity)
    {
        if (entity.exchange.exchangeState == ExchangeState.START)
        {
            entity.ReplaceExchange(ExchangeState.EXCHANGE);
        }
        else if (entity.exchange.exchangeState == ExchangeState.EXCHANGE_BACK)
        {
            entity.ReplaceExchange(ExchangeState.END);
        }
    }
}

using System;
using UnityEngine;

using strange.extensions.context.impl;

namespace Game
{
    public class GameContext : SignalContext
    {
        public GameContext(MonoBehaviour contextView) : base(contextView) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            injectionBinder.Bind<GameStartSignal>().ToSingleton();

            mediationBinder.Bind<PaddleView>().To<PaddleMediator>();
            mediationBinder.Bind<BallView>().To<BallMediator>();
        }
    }
}
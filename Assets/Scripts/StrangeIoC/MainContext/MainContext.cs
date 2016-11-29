using System;
using UnityEngine;

using strange.extensions.context.impl;

namespace Game
{
    public class MainContext : SignalContext
    {
        public MainContext(MonoBehaviour contextView) : base(contextView) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            commandBinder.Bind<GameStartSignal>().To<MainStartCommand>().Once();

            injectionBinder.Bind<LoadSceneSignal>().ToSingleton().CrossContext();
            commandBinder.Bind<LoadSceneSignal>().To<LoadSceneCommand>();

            injectionBinder.Bind<UnloadSceneSignal>().ToSingleton().CrossContext();
            commandBinder.Bind<UnloadSceneSignal>().To<UnloadSceneCommand>();
        }
    }
}
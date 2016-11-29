using System;
using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using strange.extensions.context.api;

namespace Game
{
    public class SignalContext : MVCSContext
    {
        public SignalContext(MonoBehaviour contextView) : base(contextView) { }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();

            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        public override void Launch()
        {
            base.Launch();

            Signal<string> startSignal = injectionBinder.GetInstance<GameStartSignal>();
            if (startSignal != null)
                startSignal.Dispatch("Excute");
        }

        public void OnDestroy()
        {
            Signal endSignal = injectionBinder.GetInstance<GameExitSignal>();
            if (endSignal != null)
                endSignal.Dispatch();
        }
    }
}
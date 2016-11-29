using System;
using UnityEngine;

using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;

namespace Game
{
    public class MainStartCommand : Command
    {
        public override void Execute()
        {
            Signal<string> loadSceneSignal = injectionBinder.GetInstance<LoadSceneSignal>();
            //loadSceneSignal.Dispatch("Service");
            loadSceneSignal.Dispatch("Game");
        }
    }
}
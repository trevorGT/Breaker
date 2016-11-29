using System;
using UnityEngine;
using strange.extensions.context.impl;

namespace Game
{
    public class GameBootstrap : ContextView
    {
        void Awake()
        {
            this.context = new GameContext(this);
        }
    }
}
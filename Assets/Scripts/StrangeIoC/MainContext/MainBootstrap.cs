using System;
using UnityEngine;
using strange.extensions.context.impl;

namespace Game
{
    public class MainBootstrap : ContextView
    {
        void Awake()
        {
            this.context = new MainContext(this);
        }
    }
}
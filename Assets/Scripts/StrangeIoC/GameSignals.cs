using System;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Game
{
    public class GameStartSignal : Signal<string> { }
    public class GameExitSignal : Signal { }

    public class LoadSceneSignal : Signal<string> { }
    public class UnloadSceneSignal : Signal<string> { }
}
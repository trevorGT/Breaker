using System;
using UnityEngine;
using UnityEngine.SceneManagement;

using strange.extensions.context.api;
using strange.extensions.command.impl;

namespace Game
{
    public class UnloadSceneCommand : Command
    {
        [Inject]
        public string sceneName { get; set; }

        public override void Execute()
        {
            SceneManager.UnloadScene(sceneName);
        }
    }
}
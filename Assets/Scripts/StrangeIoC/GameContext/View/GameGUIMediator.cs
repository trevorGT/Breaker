using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Game
{
    public class GameGUIMediator : Mediator
    {
        [Inject]
        public GameGUIView view { get; set; }

        public override void OnRegister()
        {
            
        }

        public override void OnRemove()
        {
            
        }
    }
}
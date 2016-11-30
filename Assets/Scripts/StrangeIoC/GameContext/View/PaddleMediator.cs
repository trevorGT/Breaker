using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Game
{
    public class PaddleMediator : Mediator
    {
        [Inject]
        public PaddleView view { get; set; }

        public override void OnRegister()
        {
            
        }

        public override void OnRemove()
        {

        }
    }
}
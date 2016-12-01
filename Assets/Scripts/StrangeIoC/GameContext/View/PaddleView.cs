using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Game
{
    public class PaddleView : View
    {
        public float paddleSpeed = .2f;

        void Update()
        {
            float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
            var pos = transform.position;
            pos.x = Mathf.Clamp(xPos, -0.9f, 0.9f);
            transform.position = pos;
        }
    }
}
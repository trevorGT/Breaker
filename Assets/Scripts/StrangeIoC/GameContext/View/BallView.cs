using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Game
{
    public class BallView : View
    {
        [SerializeField]
        private Rigidbody2D rgb2D;

        [SerializeField]
        private Vector2 _velocity = new Vector2(0, 1);

        private float _speed = 1f;
        private float lastSpeed;

        private bool isAccelerate = false;
        private bool isDecelerate = false;

        public Vector2 velocity
        {
            get { return _velocity; }
            set
            {
                _velocity = value;
                rgb2D.velocity = _velocity;
            }
        }

        public float speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                rgb2D.velocity = velocity * _speed;
            }
        }

        protected override void Start()
        {
            base.Start();
            velocity = _velocity;
        }
        
        void Update()
        {
            if (isAccelerate)
            {
                speed = Mathf.Lerp(speed, 2.5f, Time.deltaTime);
                Debug.Log(speed);
                //                 if (speed.Equals(2.5f))
                //                 {
                //                     isAccelerate = false;
                //                     isDecelerate = true;
                //                 }
            }
//             else if (isDecelerate)
//             {
//                 speed = Mathf.Lerp(speed, 1f, Time.time);
// 
//                 if (speed.Equals(1f))
//                 {
//                     isDecelerate = false;
//                 }
//             }
            
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            foreach (ContactPoint2D contact in col.contacts)
            {
                Vector2 s = velocity;
                Vector2 n = contact.normal;
                Vector2 c = n * -1;
                float tempSProductC = Vector2.Dot(s, c);
                float tempModeN = Mathf.Sqrt(c.x * c.x+ c.y * c.y);
                n *= tempSProductC / tempModeN;

                Vector2 f = 2 * n + s;

                if (contact.collider.gameObject.tag == "Paddle")
                {
                    f += new Vector2(.5f, 0);
                }
                isAccelerate = true;
                velocity = f;
            }
        }
    }
}
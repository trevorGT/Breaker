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

        public Vector2 velocity
        {
            get { return _velocity; }
            set
            {
                _velocity = value;
                rgb2D.velocity = _velocity;
            }
        }

        protected override void Start()
        {
            base.Start();
            velocity = _velocity;
        }

        void Update()
        {
            Debug.Log("rgb2D velocity:" + rgb2D.velocity);
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
                //f *= 1.1f;

                if (contact.collider.gameObject.tag == "Paddle")
                {
                    f += new Vector2(.5f, 0);
                }
                Debug.Log("velocity:" + f);
                
                velocity = f;
            }
        }
    }
}
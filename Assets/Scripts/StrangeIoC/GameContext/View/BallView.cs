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
            //DoingAccelerate();
            //Debug.Log("ball speed" + speed);
            //Debug.Log("ball velocity:" + velocity);
            //DoingDecelerate();
            Debug.Log("velocity:" + velocity);
            Debug.Log("dis:" + (velocity.x * velocity.x + velocity.y * velocity.y));
        }
        #region accelerate
        void StartAccelerate()
        {
            if (isAccelerate == false)
            {
                isAccelerate = true;
                timeStartAccelerate = Time.time;
            }
        }

        float timeStartAccelerate;
        float timeAccelerateDuringLerp = 1f;
        void DoingAccelerate()
        {
            if (isAccelerate)
            {
                float percentageComplete = (Time.time - timeStartAccelerate) / timeAccelerateDuringLerp;
                speed = Mathf.Lerp(1f, 2.5f, percentageComplete);

                if (speed.Equals(2.5f))
                {
                    //isAccelerate = false;
                    //StartDecelerate();
                }
            }
        }
        #endregion

        #region decelerate
        void StartDecelerate()
        {
            isDecelerate = true;
            timeStartDecelerate = Time.time;
        }

        float timeStartDecelerate;
        float timeDecelerateDuringLerp = 1f;
        void DoingDecelerate()
        {
            if (isDecelerate)
            {
                float percentageComplete = (Time.time - timeStartDecelerate) / timeDecelerateDuringLerp;
                speed = Mathf.Lerp(2.5f, 1f, percentageComplete);
            }
        }
        #endregion

        void OnCollisionEnter2D(Collision2D col)
        {
            foreach (ContactPoint2D contact in col.contacts)
            {
                Vector2 s = velocity;
                Vector2 n = contact.normal;
                //Debug.Log("normal:" + contact.normal);
                if (contact.collider.gameObject.tag == "Paddle" &&
                    contact.normal.Equals(new Vector2(0, 1)))
                {
                    float calc = contact.point.x - contact.collider.gameObject.transform.position.x;
                    float angle = Mathf.PI / 2 * calc;
                    n = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
//                     Debug.Log("angle:" + angle);
//                     Debug.Log("n:" + new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)));
//                     Debug.Log("dis:" + (n.x * n.x + n.y * n.y));
//                     Debug.Log("calc:" + calc);
                }

                Vector2 c = n * -1;
                float tempSProductC = Vector2.Dot(s, c);
                float tempModeN = Mathf.Sqrt(c.x * c.x + c.y * c.y);
                n *= tempSProductC / tempModeN;

                Vector2 f = 2 * n + s;

                StartAccelerate();
                velocity = f;
            }
        }
    }
}
using System;

namespace Game
{
    public class BrickBase : IBrick
    {
        private int _score;
        public bool isFix = false;

        public int score
        {
            get
            {
                return _score;
            }
        }

        public void Hurt(int damage = 1)
        {

        }

        protected virtual void Dead()
        {

        }
    }
}
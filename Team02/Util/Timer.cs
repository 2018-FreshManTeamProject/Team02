using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team02.Util
{
    abstract class Timer
    {
        protected float limitTime;//制限時間
        protected float currentTime;//現在の時間

        public Timer(float second)
        {
            limitTime = 60 * second;//60fps*秒
        }
        public Timer()
            :this(1)
        { }
        public abstract void Initialize();

        public abstract void Update(GameTime gametime);

        public abstract bool IsTime();

        public abstract float Rate();



        public void SetTime(float second)
        {
            limitTime = 60 * second;
        }
        public float Now()
        {
            return currentTime / 60f;
        }


    }
}

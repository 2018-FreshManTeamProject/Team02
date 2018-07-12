using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team02.Util
{
    class CountUptimer:Timer
    {
        public CountUptimer()
       : base()
        {
            Initialize();


        }
        public CountUptimer(float second)
            : base()
        {
            Initialize();
        }
        public override void Initialize()
        {
            currentTime = 0.0f;
        }
        public override bool IsTime()
        {
            return currentTime >= limitTime;
        }

        public override float Rate()
        {
            return currentTime / limitTime;
        }

        public override void Update(GameTime gametime)
        {
            currentTime = Math.Max(currentTime + 1f, limitTime);
        }
    }
}

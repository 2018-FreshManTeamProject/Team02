using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team02.Util
{
    class CountDowntimer:Timer
    {
        public CountDowntimer()
            :base()
        {
            Initialize();
        }
        public CountDowntimer(float second)
            :base(second)
        {
            Initialize();
        }
        public override void Initialize()
        {
            currentTime = limitTime;
        }
        public override bool IsTime()
        {
            return currentTime <= 0.0f;
        }

        public override float Rate()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            currentTime = Math.Max(currentTime - 1f, 0.0f);
        }
    }
}

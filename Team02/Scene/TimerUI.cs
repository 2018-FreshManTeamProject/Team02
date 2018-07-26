using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Team02.Util;

namespace Team02.Scene
{
    class TimerUI
    {
        private Timer timer;
        private int num;

        public TimerUI(Timer timer)
        {
            this.timer = timer;
        }
        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("timer", new Vector2(400, 10));
            renderer.DrawNumber("number", new Vector2(600, 13), timer.Now());
        }

    }
}

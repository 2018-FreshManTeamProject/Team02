using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Team02
{
    abstract class Character
    {
        protected Vector2 position;
        protected string name;
        protected bool isDeadFlag;

        public Character(string name)
        {
            this.name = name;
            position = Vector2.Zero;
            isDeadFlag = false;
        }

        public abstract void Initialize();
        public abstract void Update(GameTime gameTime);
        public abstract void Shutdown();

        public bool IsDead()
        {
            return isDeadFlag;
        }


        public virtual void Draw(Renderer renderer)
        {
            renderer.DrawTexture(name, position);
        }

    }
}

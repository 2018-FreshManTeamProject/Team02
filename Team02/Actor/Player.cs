using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Team02
{
    class Player
    {
        private Vector2 position;

        public Player()
        {
            position = Vector2.Zero;
        }

        public void Initialize()
        {
            position = new Vector2(300, 400);
        }

        public void Update(GameTime gameTime)
        {
            Vector2 velocity = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                velocity.X = 1f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                velocity.X = -1f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                velocity.Y = -1f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                velocity.Y = 1f;
            }

            if(velocity.Length() != 0)
            {
                velocity.Normalize();
            }

            float speed = 5.0f;

            position = position + velocity * speed;
        }

        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("white", position);
        }

        public void Shutdown()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;//Assert用




namespace Team02
{
    class Renderer
    {
        private ContentManager contentManager;
        private GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;

        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        

        public void LoadContent(string assetName,Texture2D texture)
        {
            if(textures.ContainsKey(assetName))
            {
#if DEBUG
                Console.WriteLine(
                    assetName+
                    "はすでに読み込まれています。/n"+
                    "プログラムを確認してください。");
#endif 

                return;
            }
            textures.Add(assetName, texture);
        }
        public void DrawTexture(
            string assetName,
            Vector2 position,
            Rectangle? rect,
            float rotate,
            Vector2 rotatePosition,
            Vector2 scale,
            SpriteEffects effects=SpriteEffects.None,
            float depath=0.0f,
            float alpha=1.0f)
        {
            spriteBatch.Draw(
                textures[assetName],
                position,
                rect,
                Color.White * alpha,
                rotate,
                rotatePosition,
                scale,
                effects, 
                depath);
        }
        public Renderer(ContentManager content,GraphicsDevice graphics)
        {
            contentManager = content;
            graphicsDevice = graphics;
            spriteBatch = new SpriteBatch(graphicsDevice);
        }
        public void LoadContent(string assetName,string filepath="./")
        {
            if(textures.ContainsKey(assetName))
            {
#if DEBUG
                Console.WriteLine(assetName+"はすでに読み込まれています。\n プログラムを確認してください。");
#endif
                return;
            }
            textures.Add(assetName, contentManager.Load<Texture2D>(filepath + assetName));

        }
        public void Unload()
        {
            textures.Clear();
        }
        public void Begin()
        {
            spriteBatch.Begin();
        }
        public void End()
        {
            spriteBatch.End();
        }
        public void DrawTexture(string assetName,Vector2 position,float alpha=1.0f)
        {
            Debug.Assert(
                textures.ContainsKey(assetName),
                "描画時にアセット名の指定を間違えたか、画像の読み込み自体出来ていません");
            spriteBatch.Draw(textures[assetName], position, Color.White * alpha);

        }
        public void DrawTexture(string assetName,Vector2 position,Rectangle rect,float alpha=1.0f)
        {
            Debug.Assert(
                textures.ContainsKey(assetName),
                "描画時にアセット名の指定を間違えたか、画像の読み込み自体出来ていません");
            spriteBatch.Draw(
                textures[assetName],
                position,
                rect,
                Color.White * alpha);
        }
        public void DrawNumber(
            string assetName,
            Vector2 position,
            int number,
            float alpha=1.0f)
        {
            Debug.Assert(
                textures.ContainsKey(assetName),
                "描画前にアセット名の指定を間違えたか、" +
                "画像の読み込み自体出来ていません");
            if(number<0)
            {
                number = 0;
            }
            int Width = 32;//画像横幅
            foreach(var n in number.ToString())
            {
                spriteBatch.Draw(
                    textures[assetName],
                    position,
                    new Rectangle((n - '0') * Width, 0, Width, 64),
                    Color.White);
                position.X += Width;
            }
        }
        public void DrawNumber(
            string assetName,
            Vector2 position,
            float number,
            float alpha=1.0f)
        {
            if(number<0.0f)
            {
                number = 0.0f;
            }
            int width = 32;

            foreach(var n in number.ToString("0"))
            {
                if(n=='.')
                {
                    spriteBatch.Draw(
                        textures[assetName],
                        position,
                        new Rectangle(10 * width, 0, width, 64),
                        Color.White * alpha);

                }
                else
                {
                    spriteBatch.Draw(
                        textures[assetName],
                        position,
                        new Rectangle((n - '0') * width, 0, width, 64),
                        Color.White * alpha);
                }
                position.X += width;
            }
        }

        internal void DrawTexture(string v1, Vector2 vector2, Rectangle? v2)
        {
            throw new NotImplementedException();
        }
    }
}

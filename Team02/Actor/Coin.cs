using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Team02.Device;

namespace Team02.Actor
{
    class Coin
    {
        //フィールド
        private Vector2 position;//位置

        //コンストラクタ
        public Coin()
        {
            position = Vector2.Zero;
        }
        //初期化メソッド
        public void Initialize()
        {
            position = new Vector2(100, 100);
        }
        //更新処理
        public void Update(GameTime gameTime)
        { }
        //描画メソッド
        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("black", position);
        }
        //終了処理
        public void Shutdown()
        { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace Team02.Actor
{
    class Coin:Character
    {
        //フィールド
        //private Vector2  position;//位置

        //コンストラクタ
        public  Coin()
           : base("black"){ }
       
        //初期化メソッド
        public override  void Initialize()
        {
            position = new Vector2(100, 100);
        }
        //更新処理
        public override  void Update(GameTime gameTime)
        { }
        //描画メソッド
        public  override void Draw(Renderer renderer)
        {
                renderer.DrawTexture("black", position);
            
        }
       
        //終了処理
        public override void Shutdown()
        { }

        
    }
}

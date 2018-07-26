// このファイルで必要なライブラリのnamespaceを指定
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Team02.Util;
using Team02.Scene;
using Team02.Actor;

/// <summary>
/// プロジェクト名がnamespaceとなります
/// </summary>
namespace Team02
{
    /// <summary>
    /// ゲームの基盤となるメインのクラス
    /// 親クラスはXNA.FrameworkのGameクラス
    /// </summary>
    public class Game1 : Game
    {
        // フィールド（このクラスの情報を記述）
        private GraphicsDeviceManager graphicsDeviceManager;//グラフィックスデバイスを管理するオブジェクト
        private SpriteBatch spriteBatch;//画像をスクリーン上に描画するためのオブジェクト
        private Timer timer;
        private TimerUI timerUI;
        private Renderer renderer;
        private Player player;
        private Coin coin;


        private CountDowntimer waittimer;
        private List<Character> characters;


        /// <summary>
        /// コンストラクタ
        /// （new で実体生成された際、一番最初に一回呼び出される）
        /// </summary>
        public Game1()
        {
            //グラフィックスデバイス管理者の実体生成
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            //コンテンツデータ（リソースデータ）のルートフォルダは"Contentに設定
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// 初期化処理（起動時、コンストラクタの後に1度だけ呼ばれる）
        /// </summary>
        protected override void Initialize()
        {
            // この下にロジックを記述
            player = new Player();

            player.Initialize();
            //コインの実体生成
            coin = new Coin();
            //コインを初期化
            coin.Initialize();

            timer = new CountDowntimer(10);
            timerUI = new TimerUI(timer);
            waittimer = new CountDowntimer(2);
            characters = new List<Character>();
            characters.Add(new Coin());
            for (int i = 0; i < 1; i++)
            {

                characters.Add(new Coin());

            }
            foreach (var c in characters)
            {
                c.Initialize();
            }







            // この上にロジックを記述
            base.Initialize();// 親クラスの初期化処理呼び出し。絶対に消すな！！
        }

        /// <summary>
        /// コンテンツデータ（リソースデータ）の読み込み処理
        /// （起動時、１度だけ呼ばれる）
        /// </summary>
        protected override void LoadContent()
        {

            // 画像を描画するために、スプライトバッチオブジェクトの実体生成
            renderer = new Renderer(Content, GraphicsDevice);

            // この下にロジックを記述
            renderer.LoadContent("white");
            renderer.LoadContent("black");
            renderer.LoadContent("number");
            renderer.LoadContent("timer");
            // この上にロジックを記述
        }

        /// <summary>
        /// コンテンツの解放処理
        /// （コンテンツ管理者以外で読み込んだコンテンツデータを解放）
        /// </summary>
        protected override void UnloadContent()
        {
            // この下にロジックを記述


            // この上にロジックを記述
        }

        /// <summary>
        /// 更新処理
        /// （1/60秒の１フレーム分の更新内容を記述。音再生はここで行う）
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Update(GameTime gameTime)
        {
            // ゲーム終了処理（ゲームパッドのBackボタンかキーボードのエスケープボタンが押されたら終了）
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                 (Keyboard.GetState().IsKeyDown(Keys.Escape)))
            {
                Exit();
            }

            player.Update(gameTime);
            // この下に更新ロジックを記述
            waittimer.Update(gameTime);
            if (!waittimer.IsTime())
            {
                return;
            }
            coin.Update(gameTime);

            timer.Update(gameTime);



            // この上にロジックを記述
            base.Update(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Draw(GameTime gameTime)
        {
            // 画面クリア時の色を設定
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // この下に描画ロジックを記述
            renderer.Begin();


            Vector2 basePos = new Vector2(290, 150);


            if (!waittimer.IsTime())
            {
                renderer.DrawNumber("number", new Vector2(390, 200), waittimer.Now() + 1);


            }
            else
            {
                for (int x = 0; x < 2; x++)
                {
                    for (int y = 0; y < 2; y++)
                    {
                        renderer.DrawTexture("black", basePos + new Vector2(100 * x, 100 * y));



                    }
                }


                //coin.Draw(renderer);
                timerUI.Draw(renderer);


                player.Draw(renderer);

            }

            renderer.End();

            //この上にロジックを記述
            base.Draw(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }
    }
}


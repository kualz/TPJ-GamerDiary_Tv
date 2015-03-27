#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace PAC_Man
{
    
    public class Game1 : Game
    {   
        public enum GameState
        {
            Win,
            running,
            gameOver,
            LostLife,
            MenuScene
        };
        public GameState gamestate;
        MenuScene menuScene;
        private objectpacman novopac;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont Score;
        private SpriteFont Lifes;
        private Room room;
        private Mobs mobs;
        private Mobs mobs0;
        private Mobs mobs1;
        private Mobs mobs2;
        private Mobs mobs3;
        private Mobs mobs4;
        private Mobs mobs5;
        private Mobs mobs6;
        private Camera2D camera;
       
        public Game1()
            : base()
        {       
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 650;
            graphics.PreferredBackBufferWidth = 560;
            Content.RootDirectory = "Content";
            camera = new Camera2D(this);
            menuScene = new MenuScene();
            Components.Add(camera);
        }

        
        protected override void Initialize()
        {
            base.Initialize();
            gamestate = GameState.MenuScene;
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(this.GraphicsDevice);
            menuScene.Load(Content);

            room = new Room();
            room.Load(Content);
            room.InicializarColisoes();

            novopac = new objectpacman();
            novopac.Load(Content);

            camera.Focus = novopac;

            mobs = new Mobs(240, 280-60, 100f);
            Collisions.Phantoms.Add(mobs);
            mobs0 = new Mobs(280, 280-60, 100f);
            Collisions.Phantoms.Add(mobs0);
            mobs1 = new Mobs(300, 280 - 60, 100f);
            Collisions.Phantoms.Add(mobs1);
            mobs2 = new Mobs(320, 280 - 60, 100f);
            Collisions.Phantoms.Add(mobs2);
            mobs3 = new Mobs(340, 280 - 60, 100f);
            Collisions.Phantoms.Add(mobs3);
            mobs4 = new Mobs(360, 280 - 60, 100f);
            Collisions.Phantoms.Add(mobs4);
            mobs5 = new Mobs(220, 280 - 60, 100f);           
            Collisions.Phantoms.Add(mobs5);
            mobs6 = new Mobs(320, 280 - 60, 100f);
            Collisions.Phantoms.Add(mobs6);
            mobs.load(Content, "Monster1_bitt");
            mobs0.load(Content, "Monster1_bytt");
            mobs1.load(Content, "Monster1_bytt");
            mobs2.load(Content, "Monster1_bitt");
            mobs3.load(Content, "Monster1_bitt");
            mobs4.load(Content, "Monster1_bytt");
            mobs5.load(Content, "Monster1_bitt");
            mobs6.load(Content, "Monster1_bitt");

            Score = Content.Load<SpriteFont>("MyFont");
            Lifes = Content.Load<SpriteFont>("MyFont");
        }

        
        protected override void UnloadContent()
        {
           
          
        }

        
        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            if (gamestate == GameState.MenuScene)
            {
                menuScene.Update(gameTime, this);
            }
            if (gamestate == GameState.running)
            {   
                novopac.Update(gameTime, room, camera);
                mobs.Update(gameTime);
                mobs0.Update(gameTime);
                mobs1.Update(gameTime);
                mobs2.Update(gameTime);
                mobs3.Update(gameTime);
                mobs4.Update(gameTime);
                mobs5.Update(gameTime);
                mobs6.Update(gameTime);
                if (room.WinTest())
                    gamestate = GameState.Win;    
                if(Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    gamestate = GameState.MenuScene;
                }
            }



            base.Update(gameTime); 
        }
        
        protected override void Draw(GameTime gameTime)
        {
            if (gamestate == GameState.MenuScene)
            {
                spriteBatch.Begin();
                menuScene.Draw(spriteBatch);
                spriteBatch.End();
            }
            if (gamestate == GameState.running || gamestate == GameState.LostLife || gamestate == GameState.gameOver)
            {
                GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

                if (gamestate == GameState.gameOver)
                {
                    spriteBatch.DrawString(Score, "GAME OVER", new Vector2(novopac.ReturnPosPacmanCamera().X - 50, novopac.ReturnPosPacmanCamera().Y - 80), Color.White);
                    spriteBatch.DrawString(Score, "Score: " + objectpacman.score, new Vector2(novopac.ReturnPosPacmanCamera().X - 50, novopac.ReturnPosPacmanCamera().Y - 50), Color.White);
                    gamestate = GameState.MenuScene;
                }
                if (gamestate == GameState.running || gamestate == GameState.LostLife)
                {
                    room.Draw(spriteBatch);
                    novopac.Draw(spriteBatch);
                    mobs.Draw(spriteBatch);
                    mobs0.Draw(spriteBatch);
                    mobs1.Draw(spriteBatch);
                    mobs2.Draw(spriteBatch);
                    mobs3.Draw(spriteBatch);
                    mobs4.Draw(spriteBatch);
                    mobs5.Draw(spriteBatch);
                    mobs6.Draw(spriteBatch);
                    spriteBatch.DrawString(Score, "Score: " + objectpacman.score, new Vector2(camera.Position.X - 200, camera.Position.Y + 180), Color.White);
                    spriteBatch.DrawString(Score, "Lifes: " + objectpacman.lifes, new Vector2(camera.Position.X + 120, camera.Position.Y + 180), Color.White);
                    if (objectpacman.gamestateLOST() == true)
                        gamestate = GameState.gameOver;
                }
                if (gamestate == GameState.Win)
                {
                    spriteBatch.DrawString(Score, "Good Job", new Vector2(novopac.ReturnPosPacmanCamera().X - 50, novopac.ReturnPosPacmanCamera().Y - 80), Color.White);
                    spriteBatch.DrawString(Score, "Score: " + objectpacman.score, new Vector2(novopac.ReturnPosPacmanCamera().X - 50, novopac.ReturnPosPacmanCamera().Y - 50), Color.White);

                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}

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
        GameState gamestate;
        enum GameState
        {
            Win,
            running,
            gameOver,
            LostLife
        };
        objectpacman novopac;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont Score;
        SpriteFont Lifes;
        Texture2D mobs1;
        double lastHumanMove;
        Room room;
        Mobs mobs;
        Mobs mobs0;
       
        public Game1()
            : base()
        {       
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 650;
            graphics.PreferredBackBufferWidth = 560;
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            base.Initialize();
            gamestate = GameState.running;
        }

        
        protected override void LoadContent()
        {
            room = new Room();
            room.Load(Content);
            room.InicializarColisoes();

            novopac = new objectpacman();
            novopac.Load(Content);

            mobs = new Mobs(240, 280, 100);
            mobs0 = new Mobs(280, 280, 100);
            mobs.load(Content, "Monster1_bitt");
            mobs0.load(Content, "Monster1_bytt");

            spriteBatch = new SpriteBatch(GraphicsDevice);

            Score = Content.Load<SpriteFont>("MyFont");
            Lifes = Content.Load<SpriteFont>("MyFont");
        }

        
        protected override void UnloadContent()
        {
           
          
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            lastHumanMove += gameTime.ElapsedGameTime.TotalSeconds;
            if (gamestate == GameState.running)
            {   
                novopac.Update(gameTime, room);     
            }       
            base.Update(gameTime); 
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            if (gamestate == GameState.gameOver)
                spriteBatch.DrawString(Score, "GAME OVER", new Vector2(220, 260), Color.White);
            spriteBatch.DrawString(Score, "Score: " + novopac.score, new Vector2(10, 620), Color.White);

            room.Draw(spriteBatch);
            novopac.Draw(spriteBatch);
            mobs.Draw(spriteBatch);
            mobs0.Draw(spriteBatch);


            if (gamestate == GameState.Win)
            {                
                spriteBatch.DrawString(Score, "Good Job", new Vector2(220, 260), Color.White);
                spriteBatch.DrawString(Score, "Score: " + novopac.score, new Vector2(220, 275), Color.White);
                UnloadContent();
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}

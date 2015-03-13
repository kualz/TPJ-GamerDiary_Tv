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
        Texture2D square;
        Texture2D PacMan;
        Texture2D PacManDown;
        Texture2D PacManLeft;
        Texture2D PacMan_Empowered;
        Texture2D PacManDown_Empowered;
        Texture2D PacManLeft_Empowered;
        Texture2D PacManUp_Empowered;
        Texture2D FOOD;
        Texture2D FOOD1;
        Texture2D PacManUp;
        SpriteFont Score;
        SpriteFont Lifes;
        int score = 0;
        double lastHumanMove;
        byte[,] board = Room.RetornoRoom();
        byte[,] newBoard = new byte[28, 31];
       
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 650;
            graphics.PreferredBackBufferWidth = 560;
            Content.RootDirectory = "Content";
            newBoard = board;
        }

        
        protected override void Initialize()
        {
            base.Initialize();
            gamestate = GameState.running;
        }

        
        protected override void LoadContent()
        {

            novopac = new objectpacman();
            novopac.Load(Content);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            square = Content.Load<Texture2D>("square");

            PacMan = Content.Load<Texture2D>("Bitmap1");
            PacManDown = Content.Load<Texture2D>("PacManDown");
            PacManUp = Content.Load<Texture2D>("PacManUp");
            PacManLeft = Content.Load<Texture2D>("PacManLeft");

            PacMan_Empowered = Content.Load<Texture2D>("PacManRight_Empowered");
            PacManDown_Empowered = Content.Load<Texture2D>("PacManDown_Empowered");
            PacManUp_Empowered = Content.Load<Texture2D>("PacManUp_Empowered");
            PacManLeft_Empowered = Content.Load<Texture2D>("PacManLeft_Empowered");

            FOOD = Content.Load<Texture2D>("Bitmap2");
            Score = Content.Load<SpriteFont>("MyFont");
            FOOD1 = Content.Load<Texture2D>("Bitmap3");
            Lifes = Content.Load<SpriteFont>("MyFont");
        }

        
        protected override void UnloadContent()
        {
            PacMan_Empowered.Dispose();
            PacManDown_Empowered.Dispose();
            PacManUp_Empowered.Dispose();
            PacManLeft_Empowered.Dispose();
            square.Dispose();
            PacMan.Dispose();
            PacManDown.Dispose();
            PacManLeft.Dispose();
            PacManUp.Dispose();
            FOOD.Dispose();
            FOOD1.Dispose();
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            lastHumanMove += gameTime.ElapsedGameTime.TotalSeconds;
            if (gamestate == GameState.running)
            {   
                novopac.Update(gameTime);     
            }
       
            base.Update(gameTime); 
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            if (gamestate == GameState.gameOver)
                spriteBatch.DrawString(Score, "GAME OVER", new Vector2(220, 260), Color.White);
            spriteBatch.DrawString(Score, "Score: " + score, new Vector2(10, 620), Color.White);
            for (int x = 0; x < 28; x++)
                for (int y = 0; y < 31; y++)
                {
                    novopac.Draw(spriteBatch);          
                    if (board[y, x] == 1)
                        spriteBatch.Draw(square, new Vector2(x * 20, y * 20), Color.Blue);
                    if (board[y, x] == 2)
                        spriteBatch.Draw(square, new Vector2(x * 20, y * 20), Color.White);
                    if (board[y, x] == 4)
                        spriteBatch.Draw(FOOD, new Vector2(x * 20, y * 20), Color.White);
                    if (board[y, x] == 5)
                        spriteBatch.Draw(FOOD1, new Vector2(x * 20, y * 20), Color.White);
                }
            if (gamestate == GameState.Win)
            {                
                spriteBatch.DrawString(Score, "Good Job", new Vector2(220, 260), Color.White);
                spriteBatch.DrawString(Score, "Score: " + score, new Vector2(220, 275), Color.White);
                UnloadContent();
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}

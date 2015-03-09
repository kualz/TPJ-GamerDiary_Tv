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
        bool down = false, up = false, left, right = false;
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
        Player PacMan_Loc = new Player(14, 11);
        int score = 0;
        float lastHumanMove;
        float PlayerStateTime;
        byte[,] board = {{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                         {1,5,5,5,5,5,5,5,5,5,5,5,5,1,1,5,5,5,5,5,5,5,5,5,5,5,5,1},
                         {1,5,1,1,1,1,5,1,1,1,1,1,5,1,1,5,1,1,1,1,1,5,1,1,1,1,5,1},
                         {1,5,1,1,1,1,5,1,1,1,1,1,5,1,1,5,1,1,1,1,1,5,1,1,1,1,5,1},
                         {1,5,1,1,1,1,5,1,1,1,1,1,5,1,1,5,1,1,1,1,1,5,1,1,1,1,5,1},
                         {1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1},
                         {1,5,1,1,1,1,5,1,1,5,1,1,1,1,1,1,1,1,5,1,1,5,1,1,1,1,5,1},
                         {1,5,1,1,1,1,5,1,1,5,1,1,1,1,1,1,1,1,5,1,1,5,1,1,1,1,5,1},
                         {1,5,5,5,5,5,5,1,1,5,5,5,5,1,1,5,5,5,5,1,1,5,5,5,5,5,5,1},
                         {1,1,1,1,1,1,5,1,1,1,1,1,0,1,1,0,1,1,1,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,1,1,1,0,1,1,0,1,1,1,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,0,0,0,0,0,0,0,0,0,0,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,0,1,1,1,2,2,1,1,1,0,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,0,1,2,2,2,2,2,2,1,0,1,1,5,1,1,1,1,1,1},
                         {3,0,0,0,0,0,5,0,0,0,1,2,2,2,2,2,2,1,0,0,0,5,0,0,0,0,0,3},
                         {1,1,1,1,1,1,5,1,1,0,1,2,2,2,2,2,2,1,0,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,0,1,1,1,1,1,1,1,1,0,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,0,0,0,0,4,0,0,0,0,0,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,0,1,1,1,1,1,1,1,1,0,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,0,1,1,1,1,1,1,1,1,0,1,1,5,1,1,1,1,1,1},
                         {1,5,5,5,5,5,5,5,5,5,5,5,5,1,1,5,5,5,5,5,5,5,5,5,5,5,5,1},
                         {1,5,1,1,1,1,5,1,1,1,1,1,5,1,1,5,1,1,1,1,1,5,1,1,1,1,5,1},
                         {1,5,1,1,1,1,5,1,1,1,1,1,5,1,1,5,1,1,1,1,1,5,1,1,1,1,5,1},
                         {1,5,5,5,1,1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1,1,5,5,5,1},
                         {1,1,1,5,1,1,5,1,1,5,1,1,1,1,1,1,1,1,5,1,1,5,1,1,5,1,1,1},
                         {1,1,1,5,1,1,5,1,1,5,1,1,1,1,1,1,1,1,5,1,1,5,1,1,5,1,1,1},
                         {1,5,5,5,5,5,5,1,1,5,5,5,5,1,1,5,5,5,5,1,1,5,5,5,5,5,5,1},
                         {1,5,1,1,1,1,1,1,1,1,1,1,5,1,1,5,1,1,1,1,1,1,1,1,1,1,5,1},
                         {1,5,1,1,1,1,1,1,1,1,1,1,5,1,1,5,1,1,1,1,1,1,1,1,1,1,5,1},
                         {1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1},
                         {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}};

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
        }

        
        protected override void UnloadContent()
        {
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
            lastHumanMove += (float)gameTime.ElapsedGameTime.TotalSeconds;
            PlayerStateTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (gamestate == GameState.running)
            {
                if (lastHumanMove >= 0.5f / 10f)
                {
                    lastHumanMove = 0;
                    if (Keyboard.GetState().IsKeyDown(Keys.Down))
                        if (CanGoDown())
                        {
                            PacMan_Loc.Incrementa_PY();                          
                            down = true;
                            up = false;
                            left = false;
                            right = false;
                        }

                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                        if (CanGoUp())
                        {
                            PacMan_Loc.Decrementa_PY();
                            up = true;
                            down = false;
                            left = false;
                            right = false;
                        }
                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                        if (CanGoleft())
                        //if (board[PacMan_Loc._Py(), PacMan_Loc._Px()] == 3)
                        //    PacMan_Loc.Change_Py(29);
                        {
                            PacMan_Loc.Decrementa_PX();
                            if (PacMan_Loc._Px() == 1 && PacMan_Loc._Py() == 14)
                            {
                                PacMan_Loc.change_Px(25);
                            }                        
                            left = true;
                            up = false;
                            down = false;
                            right = false;
                        }
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                        if (CanGoRight())
                        //if (board[PacMan_Loc._Py(), PacMan_Loc._Px()] == 3)
                        //    PacMan_Loc.Change_Py(0);
                        {
                            PacMan_Loc.Incrementa_PX();
                            if (PacMan_Loc._Px() == 26 && PacMan_Loc._Py() == 14)
                            {
                                PacMan_Loc.change_Px(2);
                            }
                            right = true;
                            up = false;
                            down = false;
                            left = false;
                        }
                }
                if (board[PacMan_Loc._Py(), PacMan_Loc._Px()] == 5)
                {
                    score += 2;
                    board[PacMan_Loc._Py(), PacMan_Loc._Px()] = 0;
                }
                if (board[PacMan_Loc._Py(), PacMan_Loc._Px()] == 4)
                {
                    score += 10;
                    board[PacMan_Loc._Py(), PacMan_Loc._Px()] = 0;
                    PacMan_Loc.Set_Player_State();
                }
                if (PlayerStateTime >= 5f && PacMan_Loc.Get_PlayerState() == Player.PlayerState.empowered)
                {
                    PlayerStateTime = 0;
                    PacMan_Loc.Set_Player_State();
                }
                Test_GameOver();
            }
            if (gamestate == GameState.LostLife)
            {
                PacMan_Loc.change_Px(14);
                PacMan_Loc.Change_Py(11);
                board = newBoard;
            }
            base.Update(gameTime); 
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();


            spriteBatch.DrawString(Score, "Score: " + score, new Vector2(10, 620), Color.White);
            for (int x = 0; x < 28; x++)
                for (int y = 0; y < 31; y++)
                {
                    if (board[y, x] == 0)
                        if (PacMan_Loc._Px() == x && PacMan_Loc._Py() == y)
                        {
                            if (PacMan_Loc.Get_PlayerState() == Player.PlayerState.normal)
                            {
                                spriteBatch.Draw(PacMan, new Vector2(x * 20, y * 20), Color.White);
                                if (down)
                                    spriteBatch.Draw(PacManDown, new Vector2(x * 20, y * 20), Color.White);
                                if (up)
                                    spriteBatch.Draw(PacManUp, new Vector2(x * 20, y * 20), Color.White);
                                if (left)
                                    spriteBatch.Draw(PacManLeft, new Vector2(x * 20, y * 20), Color.White);
                                if (right)
                                    spriteBatch.Draw(PacMan, new Vector2(x * 20, y * 20), Color.White);
                            }
                            if (PacMan_Loc.Get_PlayerState() == Player.PlayerState.empowered)
                            {
                                spriteBatch.Draw(PacMan, new Vector2(x * 20, y * 20), Color.White);
                                if (down)
                                    spriteBatch.Draw(PacManDown_Empowered, new Vector2(x * 20, y * 20), Color.White);
                                if (up)
                                    spriteBatch.Draw(PacManUp_Empowered, new Vector2(x * 20, y * 20), Color.White);
                                if (left)
                                    spriteBatch.Draw(PacManLeft_Empowered, new Vector2(x * 20, y * 20), Color.White);
                                if (right)
                                    spriteBatch.Draw(PacMan_Empowered, new Vector2(x * 20, y * 20), Color.White);
                            }
                        }
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

        private bool CanGoleft()
        {
            if (board[PacMan_Loc._Py(), PacMan_Loc._Px() - 1] == 0 || 
                board[PacMan_Loc._Py(), PacMan_Loc._Px() - 1] == 4 ||
                board[PacMan_Loc._Py(), PacMan_Loc._Px() - 1] == 5)
                return true;
            else return false;
        }
        private bool CanGoRight()
        {
            if (board[PacMan_Loc._Py(), PacMan_Loc._Px() + 1] == 0 || 
                board[PacMan_Loc._Py(), PacMan_Loc._Px() + 1] == 4 ||
                board[PacMan_Loc._Py(), PacMan_Loc._Px() + 1] == 5)
                return true;
            else return false;
        }
        private bool CanGoUp()
        {
            if (board[PacMan_Loc._Py() - 1, PacMan_Loc._Px()] == 0 || 
                board[PacMan_Loc._Py() - 1, PacMan_Loc._Px()] == 5)
                return true;
            else return false;
        }
        private bool CanGoDown()
        {
            if (board[PacMan_Loc._Py() + 1, PacMan_Loc._Px()] == 0 ||
                board[PacMan_Loc._Py() + 1, PacMan_Loc._Px()] == 5)
                return true;
            else return false;
        }

        private void Test_GameOver()
        {
            int aux = 0;
            for (int x = 0; x < 28; x++)
                for (int y = 0; y < 31; y++)
                {
                    if (board[y, x] == 5)
                        aux++;
                }
            if (aux != 0)
                gamestate = GameState.running;
            else
                gamestate = GameState.Win;
        }
    }
}

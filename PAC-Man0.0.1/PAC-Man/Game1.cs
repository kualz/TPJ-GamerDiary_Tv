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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D square;
        Texture2D PacMan;
        Player PacMan_Loc = new Player(1, 1);
        Keys key;
        float lastHumanMove;
        byte[,] board = {{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                         {1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                         {1,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,0,1},
                         {1,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,0,1},
                         {1,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,0,1},
                         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                         {1,0,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,0,1},
                         {1,0,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,0,1},
                         {1,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0,1},
                         {1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,1},
                         {1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,1},
                         {1,1,1,1,1,1,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,1,1,1,1},
                         {1,1,1,1,1,1,0,1,1,0,1,1,1,2,2,1,1,1,0,1,1,0,1,1,1,1,1,1},
                         {1,1,1,1,1,1,0,1,1,0,1,2,2,2,2,2,2,1,0,1,1,0,1,1,1,1,1,1},
                         {3,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,3},
                         {1,1,1,1,1,1,0,1,1,0,1,2,2,2,2,2,2,1,0,1,1,0,1,1,1,1,1,1},
                         {1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1},
                         {1,1,1,1,1,1,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,1,1,1,1},
                         {1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1},
                         {1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1},
                         {1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                         {1,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,0,1},
                         {1,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,0,1},
                         {1,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,1},
                         {1,1,1,0,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,0,1,1,1},
                         {1,1,1,0,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,0,1,1,1},
                         {1,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0,1},
                         {1,0,1,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1},
                         {1,0,1,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1},
                         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                         {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}};
                       
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 620;
            graphics.PreferredBackBufferWidth = 560;
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            square = Content.Load<Texture2D>("square");
            PacMan = Content.Load<Texture2D>("Bitmap1");
        }

        
        protected override void UnloadContent()
        {
            square.Dispose();
            PacMan.Dispose();
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            lastHumanMove += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (lastHumanMove >= 0.5f / 10f)
            {
                lastHumanMove = 0;
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    if (CanGoDown())
                        PacMan_Loc.Incrementa_PY();
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    if (CanGoUp())
                        PacMan_Loc.Decrementa_PY();
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    if (CanGoleft())
                        //if (board[PacMan_Loc._Py(), PacMan_Loc._Px()] == 3)
                        //    PacMan_Loc.Change_Py(29);
                        PacMan_Loc.Decrementa_PX();
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    if (CanGoRight())
                        //if (board[PacMan_Loc._Py(), PacMan_Loc._Px()] == 3)
                        //    PacMan_Loc.Change_Py(0);
                        PacMan_Loc.Incrementa_PX();

            }


            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            for (int x = 0; x < 28; x++)
                for (int y = 0; y < 31; y++)
                {
                    if (board[y, x] == 0)
                    {
                        if (PacMan_Loc._Px() == x && PacMan_Loc._Py() == y)
                        {
                            spriteBatch.Draw(PacMan, new Vector2(x * 20, y * 20), Color.White);
                        }
                    }
                    if (board[y, x] ==1 )
                    {
                        spriteBatch.Draw(square, new Vector2(x * 20, y * 20), Color.Blue);
                    }
                    if (board[y, x] == 2)
                    {
                        spriteBatch.Draw(square, new Vector2(x * 20, y * 20), Color.White);
                    }
                }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private bool CanGoleft()
        {
            if (board[PacMan_Loc._Py(), PacMan_Loc._Px() - 1] == 0 )
                return true;
            else return false;
        }
        private bool CanGoRight()
        {
            if (board[PacMan_Loc._Py(), PacMan_Loc._Px() + 1] == 0 )
                return true;
            else return false;
        }
        private bool CanGoUp()
        {
            if (board[PacMan_Loc._Py() - 1, PacMan_Loc._Px()] == 0)
                return true;
            else return false;
        }
        private bool CanGoDown()
        {
            if (board[PacMan_Loc._Py() + 1, PacMan_Loc._Px()] == 0)
                return true;
            else return false;
        }
    }
}

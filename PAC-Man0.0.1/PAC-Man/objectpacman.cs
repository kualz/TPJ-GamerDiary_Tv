using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAC_Man
{
    class objectpacman
    {
        public enum PacManState
        {
            GoingRight,
            GoingLeft,
            GoingDown,
            GoingUp
        };
        public PacManState PacMove;
        public Vector2 position;
        public float x;
        public float y;
        private Texture2D texture;
        private float speed;
        private int TextureSize = 19;
        private Rectangle Rec;
        private Room novo;

        public objectpacman() 
        {
            speed = 100f;
            x = 250;
            y = 342;
            position = new Vector2(x, y);
        }

        public void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("Bitmap1.bmp");
        }

        public int GetPacstate()
        {
            if(PacMove == PacManState.GoingDown)
            {
                return 1;
            }
            if (PacMove == PacManState.GoingLeft)
            {
                return 2;
            }
            if (PacMove == PacManState.GoingRight)
            {
                return 3;
            }
            if (PacMove == PacManState.GoingUp)
            {
                return 4;
            }
            return 0;
        }

        public void Update(GameTime gameTime)
        {
            novo = new Room();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                float nx = x - speed * deltaTime;
                if (novo.IsColliding((int)nx, (int)y) == false)
                {
                    PacMove = PacManState.GoingLeft;
                    x = nx;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                float ny = y - speed * deltaTime;
                if (novo.IsColliding((int)x, (int)ny) == false)
                {
                    PacMove = PacManState.GoingUp;
                    y = ny ;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                float nx = x + speed * deltaTime;
                if (novo.IsColliding((int)nx, (int)y) == false)
                {
                    PacMove = PacManState.GoingRight;
                    x = nx;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                float ny = y + speed * deltaTime;
                if (novo.IsColliding((int)x, (int)ny) == false)
                {
                    PacMove = PacManState.GoingDown;
                    y = ny;
                }
            }

            position = new Vector2(x, y);
            Rec = new Rectangle((int)(x), (int)(y), TextureSize, TextureSize);
            deltaTime = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}


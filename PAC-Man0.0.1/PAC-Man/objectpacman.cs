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
        private int TextureSize = 20;
        private Rectangle Rec;
        private Room novo = new Room();

        public objectpacman() 
        {
            speed = 100f;
            x = 20;
            y = 20;
            position = new Vector2(x, y);
        }

        public void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("Monster1_bitt.bmp");
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
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (novo.IsColliding(Rec) == false)
                {
                    PacMove = PacManState.GoingLeft;
                    x -= speed * deltaTime;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (novo.IsColliding(Rec) == false)
                {
                    PacMove = PacManState.GoingUp;
                    y -= speed * deltaTime;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (novo.IsColliding(Rec) == false)
                {
                    PacMove = PacManState.GoingRight;
                    x += speed * deltaTime;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (novo.IsColliding(Rec) == false)
                {
                    PacMove = PacManState.GoingDown;
                    y += speed * deltaTime;
                }
            }

            position = new Vector2(x, y);
            Rec = new Rectangle((int)(x + 0.5), (int)(y + 0.5), TextureSize, TextureSize);
            deltaTime = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}


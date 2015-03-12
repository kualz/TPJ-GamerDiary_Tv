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
        
        public Vector2 position;
        public float x;
        public float y;
        private Texture2D texture;
        private float speed;

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

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (Collisions.canGoleft((int)(x + 0.5), (int)(y + 0.5)))
                {
                    x -= speed * deltaTime;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (Collisions.canGoUp((int)(x + 0.5), (int)(y + 0.5)))
                {
                    y -= speed * deltaTime;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (Collisions.canGoRight((int)(x + 0.5), (int)(y + 0.5)))
                {
                    x += speed * deltaTime;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (Collisions.canGoDown((int)(x + 0.5), (int)(y + 0.5)))
                {
                    y += speed * deltaTime;
                }
            }

            position = new Vector2(x, y);
            deltaTime = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }

}


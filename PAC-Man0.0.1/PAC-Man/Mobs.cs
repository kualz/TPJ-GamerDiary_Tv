using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAC_Man
{
    class Mobs : AI
    {
        private int speed;
        private Vector2 position;
        private float x, y;
        private Texture2D mob;
        private Rectangle Rec;

        public Mobs(float PositionX, float PositionY, int speed)
        {
            this.speed = speed;
            x = PositionX;
            y = PositionY;
            position = new Vector2(x, y);
        }

        public void load(ContentManager content, string nomeSpriteMob1, string nomeSpriteMob2)
        {
            mob = content.Load<Texture2D>(nomeSpriteMob1);
            mob = content.Load<Texture2D>(nomeSpriteMob2);
            //mob3
            //mob4
        }

        public void Update(GameTime gameTime)
        {
            float DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 nextPosition = position;


        }

        public List<Rectangle> CheckCollisions(Vector2 pos)
        {
            List<Rectangle> collidingWith = new List<Rectangle>();

            Rectangle rect = new Rectangle((int)Math.Round(pos.X), (int)Math.Round(pos.Y), Rec.Width, Rec.Height);

            foreach (var rectangle in Collisions.Rectangles)
            {
                if (rect.Intersects(rectangle) && rect != rectangle)
                {
                    collidingWith.Add(rectangle);
                }
            }
            return collidingWith;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}

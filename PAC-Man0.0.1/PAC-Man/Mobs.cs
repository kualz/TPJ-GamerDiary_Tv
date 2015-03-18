using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAC_Man
{
    class Mobs
    {
        private enum mobState
        {
            goingUp,
            goingDown,
            goingLeft,
            goingRight
        };
        private mobState status;
        protected float speed;
        protected Vector2 position;
        protected float x, y;
        protected Texture2D mob;
        protected Rectangle Rec;
        private int textureSize = 20;

        public Mobs(float PositionX, float PositionY, float speed)
        {
            this.speed = speed;
            x = PositionX;
            y = PositionY;
            position = new Vector2(x, y);
            Rec = new Rectangle((int)Math.Round(x), (int)Math.Round(y), textureSize, textureSize);
            Collisions.Phantoms.Add(Rec);
        }

        public void load(ContentManager content, string nomeSpriteMob)
        {
            mob = content.Load<Texture2D>(nomeSpriteMob);
        }

        public void Update(GameTime gameTime)
        {
            float DeltaTime1 = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 nextPosition = position;

            if(status == mobState.goingUp)
            {
                nextPosition = new Vector2(position.X, position.Y - speed * DeltaTime1);
                if(CheckCollisions(nextPosition).Count == 0)
                    position = nextPosition;
                else
                    ChooseDirection(DeltaTime1);
            }

            if(status == mobState.goingDown)
            {

                nextPosition = new Vector2(position.X, position.Y + speed * DeltaTime1);
                if(CheckCollisions(nextPosition).Count == 0)
                    position = nextPosition;
                else
                    ChooseDirection(DeltaTime1);
            }

            if(status == mobState.goingLeft)
            {
                nextPosition = new Vector2(position.X - speed * DeltaTime1, position.Y);
                if (CheckCollisions(nextPosition).Count == 0)
                    position = nextPosition;
                else
                    ChooseDirection(DeltaTime1);
                
            }
            if(status == mobState.goingRight)
            {
                nextPosition = new Vector2(position.X + speed * DeltaTime1, position.Y);
                if (CheckCollisions(nextPosition).Count == 0)
                    position = nextPosition;
                else
                    ChooseDirection(DeltaTime1);
             }
            Collisions.Phantoms.Remove(Rec);
            Rec = new Rectangle((int)Math.Round(position.X), (int)Math.Round(position.Y), textureSize, textureSize);
            Collisions.Phantoms.Add(Rec);
            ////Collisions.Phantoms[1].X = (int)Math.Round(nextPosition.X);
            ////Collisions.Phantoms[1].Y = nextPosition.Y;
            
        }

        private mobState ChooseDirection(float gametime)
        {
            int random;
            Random rand = new Random();
            random = rand.Next(1, 4);
            if (random == 1)
            {
                status = mobState.goingDown;
                return status;
            }

            if(random == 2)
            {
                status = mobState.goingLeft;
                return status;
            }

            if(random == 3)
            {
                status = mobState.goingRight;
                return status;
            }

            if(random == 4)
            {
                status = mobState.goingUp;
                return status;
            }

            return 0;
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
            spriteBatch.Draw(mob, new Vector2(position.X, position.Y), Color.White);
        }
    }
}

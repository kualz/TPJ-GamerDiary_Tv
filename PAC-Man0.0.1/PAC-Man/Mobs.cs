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
        protected Texture2D[] mob;
        protected Rectangle Rec;
        private int textureSize = 20;
        private Random rand;
        private int ingameactive;
        private float timer = 0f;
        private float intervalo = 0.15f;
        private int currentFrame = 0;

        public Mobs(float PositionX, float PositionY, float speed)
        {
            this.ingameactive = 1;
            this.speed = speed;
            x = PositionX;
            y = PositionY;
            position = new Vector2(x, y);
            Rec = new Rectangle((int)Math.Round(x), (int)Math.Round(y), textureSize, textureSize);
        }
        public void destroyFuckinMob()
        {
            this.ingameactive = 0;

            for (int i = Collisions.Phantoms.Count - 1; i >= 0; i--)
            {
                if (Collisions.Phantoms[i] == this)
                {
                    Collisions.Phantoms.RemoveAt(i);
                    objectpacman.score += 30;
                }
            }
        }

        public Rectangle returnrecMob()
        {
            return Rec;
        }

        public void load(ContentManager content)
        {
            mob = new Texture2D[3];

            mob[0] = content.Load<Texture2D>("Monster1_bitt");
            mob[1] = content.Load<Texture2D>("Monster2_bitt");
            mob[2] = content.Load<Texture2D>("Monster3_bitt");
        }

        public int randomGen()
        {
            int random = 0;
            rand = new Random();
            random = rand.Next(1, 3);
            return random;
        }

        public void Update(GameTime gameTime)
        {
            float DeltaTime1 = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 nextPosition = position;

            timer += DeltaTime1;

            if(timer >= intervalo)
            {
                currentFrame++;
                if (currentFrame >= (3))
                {
                    currentFrame = 0;
                }
                timer = 0;
            }



            if(status == mobState.goingUp)
            {
                int generated = randomGen();
                nextPosition = new Vector2(position.X, position.Y - speed * DeltaTime1);
                if (CheckCollisions(nextPosition).Count == 0)
                {
                    position = nextPosition;
                    //esquerda
                    nextPosition = new Vector2(position.X - speed * DeltaTime1, position.Y);
                    if (CheckCollisions(nextPosition).Count == 0)
                    {
                        if (generated == 1)
                        {
                            position = nextPosition;
                            status = mobState.goingLeft;
                        }
                    }
                    //direita
                    nextPosition = new Vector2(position.X + speed * DeltaTime1, position.Y);
                    if (CheckCollisions(nextPosition).Count == 0)
                    {
                        if (generated == 2)
                        {
                            position = nextPosition;
                            status = mobState.goingRight;
                        }
                    }
                }
                else
                    ChooseDirection(DeltaTime1);
                generated = 0;
            }

            if(status == mobState.goingDown)
            {
                int generated = randomGen();
                nextPosition = new Vector2(position.X, position.Y + speed * DeltaTime1);
                if (CheckCollisions(nextPosition).Count == 0)
                {
                    position = nextPosition;
                    nextPosition = new Vector2(position.X - speed * DeltaTime1, position.Y);
                    if (CheckCollisions(nextPosition).Count == 0)
                    {
                        if (generated == 1)
                        {
                            position = nextPosition;
                            status = mobState.goingLeft;
                        }
                    }
                    //direita
                    nextPosition = new Vector2(position.X + speed * DeltaTime1, position.Y);
                    if (CheckCollisions(nextPosition).Count == 0)
                    {
                        if (generated == 2)
                        {
                            position = nextPosition;
                            status = mobState.goingRight;
                        }
                    }
                }
                else
                    ChooseDirection(DeltaTime1);
                generated = 0;
            }

            if(status == mobState.goingLeft)
            {
                int genarated = randomGen();
                nextPosition = new Vector2(position.X - speed * DeltaTime1, position.Y);
                if (CheckCollisions(nextPosition).Count == 0)
                {
                    position = nextPosition;
                    if (position.X < 10 && position.Y > 279 && position.Y < 281) position = new Vector2(26 * 20, 280);
                    //cima
                    nextPosition = new Vector2(position.X, position.Y - speed * DeltaTime1);
                    if (CheckCollisions(nextPosition).Count == 0)
                    {
                        if (genarated == 1)
                        {
                            position = nextPosition;
                            status = mobState.goingUp;
                        }
                    }
                    //baixo
                    nextPosition = new Vector2(position.X, position.Y + speed * DeltaTime1);
                    if (CheckCollisions(nextPosition).Count == 0)
                    {
                        if (genarated == 2)
                        {
                            position = nextPosition;
                            status = mobState.goingDown;
                        }
                    }
                }
                else
                    ChooseDirection(DeltaTime1);
                genarated = 0;
                
            }
            if(status == mobState.goingRight)
            {
                int generated = randomGen();
                nextPosition = new Vector2(position.X + speed * DeltaTime1, position.Y);
                if (CheckCollisions(nextPosition).Count == 0)
                {
                    position = nextPosition;
                    if (position.X < 533 && position.X > 531 && position.Y > 279 && position.Y < 281) position = new Vector2(15, 280);
                    //cima
                    nextPosition = new Vector2(position.X, position.Y - speed * DeltaTime1);
                    if (CheckCollisions(nextPosition).Count == 0)
                    {
                        if (generated == 1)
                        {
                            position = nextPosition;
                            status = mobState.goingUp;
                        }
                    }
                    //baixo
                    nextPosition = new Vector2(position.X, position.Y + speed * DeltaTime1);
                    if (CheckCollisions(nextPosition).Count == 0)
                    {
                        if (generated == 2)
                        {
                            position = nextPosition;
                            status = mobState.goingDown;
                        }
                    }
                }
                else
                    ChooseDirection(DeltaTime1);
                generated = 0;
             }
            Rec = new Rectangle((int)Math.Round(position.X), (int)Math.Round(position.Y), textureSize, textureSize);            
        }

        private mobState ChooseDirection(float gametime)
        {
            int random;
            Random rand = new Random();
            random = rand.Next(1, 7);
            if (random == 1 || random == 2)
            {
                status = mobState.goingDown;
                return status;
            }

            if(random == 3)
            {
                status = mobState.goingLeft;
                return status;
            }

            if(random == 4)
            {
                status = mobState.goingRight;
                return status;
            }

            if (random == 5 || random == 6 || random == 7)
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
            if( ingameactive == 1) 
                spriteBatch.Draw(mob[currentFrame], new Vector2(position.X, position.Y), Color.White);
        }
    }
}

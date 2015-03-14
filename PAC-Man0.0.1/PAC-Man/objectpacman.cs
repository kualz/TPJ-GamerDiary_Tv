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
        public Texture2D[] textures;
        private float speed;
        private int TextureSize = 19;
        private Rectangle Rec;
        public double rotaçao;
        float intervalo= 0.08f, timer;
        int currentFrame;

        public objectpacman() 
        {
            speed = 100f;
            x = 250;
            y = 340;
            position = new Vector2(x, y);
        }

        public void Load(ContentManager content)
        {
            textures = new Texture2D[5];
            textures[0] = content.Load<Texture2D>("Bitmap1.bmp");
            textures[1] = content.Load<Texture2D>("Pacman2.bmp");
            textures[2] = content.Load<Texture2D>("Pacman3.bmp");
            textures[3] = content.Load<Texture2D>("Pacman2.bmp");
            textures[4] = content.Load<Texture2D>("Bitmap1.bmp");
        }


        public void Update(GameTime gameTime, Room room, int score)
        {        
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 nextPosition = position;
            timer += deltaTime;
            if (timer >= intervalo)
            {
                currentFrame++;
                if (currentFrame >= (5))
                {
                    currentFrame = 0;
                }
                timer = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                nextPosition = new Vector2(position.X - speed * deltaTime , position.Y);
                if (CheckCollisions(nextPosition).Count == 0) 
                {
                    rotaçao = Math.PI;
                    PacMove = PacManState.GoingLeft;
                    position = nextPosition;                                
                    if (position.X < 10 && position.Y > 279 && position.Y < 281) position = new Vector2(26 * 20, 280);
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                nextPosition = new Vector2(position.X, position.Y - speed * deltaTime);
                if (CheckCollisions(nextPosition).Count == 0) 
                {
                    rotaçao = -Math.PI / 2;
                    PacMove = PacManState.GoingUp;
                    position = nextPosition;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                nextPosition = new Vector2(position.X + speed * deltaTime, position.Y);
                if (CheckCollisions(nextPosition).Count == 0) 
                {
                    rotaçao = 0;
                    PacMove = PacManState.GoingRight;
                    position = nextPosition;
                    if (position.X < 533 && position.X > 531 && position.Y > 279 && position.Y < 281) position = new Vector2(15, 280);
                }       
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                nextPosition = new Vector2(position.X, position.Y + speed * deltaTime);
                if (CheckCollisions(nextPosition).Count == 0) 
                {
                    rotaçao = Math.PI / 2;
                    PacMove = PacManState.GoingDown;
                    position = nextPosition;
                }
            }
            if (room.Checkcomida(position) == 5)
            {
                room.DestroySquare(position);
                score += 1;            
            }
            if (room.Checkcomida(position) == 4)
            {
                room.DestroySquare(position);
                score += 5;
            }
            Rec = new Rectangle((int)Math.Round(position.X), (int)Math.Round(position.Y), TextureSize, TextureSize);
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

            spriteBatch.Draw(textures[currentFrame],new Vector2(position.X + 10, position.Y + 10),null,Color.White,(float)rotaçao,new Vector2(10,10),1f,SpriteEffects.None, 0f);
        }
    }
}


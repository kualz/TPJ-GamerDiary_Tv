using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PAC_Man.isto_ta_tipo_de_medo__building_;
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
        public enum PacManPower
        {
            Empower,
            normal
        };
        public PacManPower pacPow = PacManPower.normal;
        public PacManState PacMove;
        public Vector2 position;
        public float x;
        public float y;
        public SpriteFont timer1, timer2;
        public Texture2D[] textures;
        public Texture2D[] texturesEmpower;
        private float speed;
        private int TextureSize = 19;
        private Rectangle Rec;
        public double rotaçao;
        float intervalo= 0.08f, timer, timerPower;
        int currentFrame;
        public int score = 0;
        public float superspeed = 0;
        private Projeteis tiros;
        public bool flag = false;

        public objectpacman() 
        {
            speed = 100f;
            x = 250;
            y = 340;
            position = new Vector2(x, y);
        }

        public void Load(ContentManager content)
        {
            Projeteis.load(content);

            textures = new Texture2D[9];
            textures[0] = content.Load<Texture2D>("1.bmp");
            textures[1] = content.Load<Texture2D>("2.bmp");
            textures[2] = content.Load<Texture2D>("3.bmp");
            textures[3] = content.Load<Texture2D>("4.bmp");
            textures[4] = content.Load<Texture2D>("5.bmp");
            textures[5] = content.Load<Texture2D>("4.bmp");
            textures[6] = content.Load<Texture2D>("3.bmp");
            textures[7] = content.Load<Texture2D>("2.bmp");
            textures[8] = content.Load<Texture2D>("1.bmp");          

            texturesEmpower = new Texture2D[5];           

            timer1 = content.Load<SpriteFont>("MyFont");
            timer2 = content.Load<SpriteFont>("Myfont");
        }


        public void Update(GameTime gameTime, Room room)
        {        
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float PowerTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 nextPosition = position;
            timer += deltaTime;
            if (pacPow == PacManPower.Empower)
                timerPower += PowerTime;
            if (timerPower >= 3f)
            {
                pacPow = PacManPower.normal;
                superspeed = 0;
                timerPower = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (pacPow == PacManPower.Empower)
                {
                    tiros = new Projeteis(position, 200, PacMove);
                    flag = true;
                }
            }
            if (timer >= intervalo)
            {
                currentFrame++;
                if (currentFrame >= (9))
                {
                    currentFrame = 0;
                }
                timer = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                nextPosition = new Vector2(position.X - speed * deltaTime - superspeed, position.Y);
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
                nextPosition = new Vector2(position.X, position.Y - speed * deltaTime - superspeed);
                if (CheckCollisions(nextPosition).Count == 0) 
                {
                    rotaçao = -Math.PI / 2;
                    PacMove = PacManState.GoingUp;
                    position = nextPosition;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                nextPosition = new Vector2(position.X + speed * deltaTime + superspeed, position.Y);
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
                nextPosition = new Vector2(position.X, position.Y + speed * deltaTime + superspeed);
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
                pacPow = PacManPower.Empower;
                superspeed = 0.5f;
                room.DestroySquare(position);
                score += 5;
            }
            Rec = new Rectangle((int)Math.Round(position.X), (int)Math.Round(position.Y), TextureSize, TextureSize);
            if (flag == true)
                if (pacPow == PacManPower.Empower)
                    tiros.update(gameTime);
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
            if (pacPow == PacManPower.normal)
                spriteBatch.Draw(textures[currentFrame],new Vector2(position.X + 10, position.Y + 10),null,Color.White,(float)rotaçao,new Vector2(10,10),1f,SpriteEffects.None, 0f);
            if (pacPow == PacManPower.Empower)
            { 
                spriteBatch.Draw(textures[currentFrame], new Vector2(position.X + 10, position.Y + 10), null, Color.DarkRed, (float)rotaçao, new Vector2(10, 10), 1f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(timer1, string.Format("Power Time {0:0.00}", (3 - timerPower)), new Vector2(300, 620), Color.White);
            }
            if (flag == true)
                if (pacPow == PacManPower.Empower)
                    tiros.draw(spriteBatch);
            
        }
    }
}


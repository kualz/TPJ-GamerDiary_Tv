﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
    class objectpacman : IFocusable
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
            normal,
            untergetable
        };
        public PacManPower pacPow = PacManPower.normal;
        public PacManState PacMove;
        public Vector2 position;
        public float x;
        public float y;
        public SpriteFont timer1, timer2;
        public Texture2D[] textures;
        public Texture2D[] texturesEmpower;
        public SoundEffect coin1;
        public SoundEffect coin10;
        public SoundEffect megatiro;
        public SoundEffect teleport;
        private float speed;
        private int TextureSize = 19;
        private Rectangle Rec;
        public double rotaçao;
        private float intervalo= 0.08f, timer, timerPower;
        private int currentFrame;

        static public int score = 0;
        static public int lifes = 3; 

        public float superspeed = 0;
        private Projeteis tiros;
        public bool flag = false;
        public static bool gamestatechanger = false;
        public bool gamestatechangerToLost = false;
        private float timeUntargetble = 0;
        private float NewTimerUntargetble = 0;

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
            coin1 = content.Load<SoundEffect>("coin1");
            coin10 = content.Load<SoundEffect>("coin10");
            megatiro = content.Load<SoundEffect>("tiro");
            teleport = content.Load<SoundEffect>("teleport");
        }

        public void ResetPacVariables()
        {
            score = 0;
            lifes = 3;
            gamestatechanger = false;
        }

        public void Update(GameTime gameTime, Room room, Camera2D cam)
        {        
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float PowerTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float UntargetbleTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float TimeUntargetblenew = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 nextPosition = position;
            timer += deltaTime;


            #region timerUpdates

            NewTimerUntargetble += TimeUntargetblenew;
            if (NewTimerUntargetble >= 0.2f)
                NewTimerUntargetble = 0;

            if (pacPow == PacManPower.untergetable)
            {
                timeUntargetble += UntargetbleTime;
            }
            if (timeUntargetble >= 3)
            {
                pacPow = PacManPower.normal;
                timeUntargetble = 0;
            }


            if (pacPow == PacManPower.Empower)
                timerPower += PowerTime;
            if (timerPower >= 5f)
            {
                pacPow = PacManPower.normal;
                superspeed = 0;
                timerPower = 0;
            }
            #endregion

            #region inputUpdate
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (pacPow == PacManPower.Empower && tiros.returnVis() == false)
                {              
                    tiros = new Projeteis(nextPosition, 200, PacMove, cam);
                    
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
                    if (checkCollisionMOB(nextPosition).Count != 0 && pacPow != PacManPower.untergetable)
                    {
                        lifes--;
                        pacPow = PacManPower.untergetable;
                        if (lifes == 0)
                            gamestatechangerToLost = true;
                    }
                    if (pacPow == PacManPower.untergetable || pacPow == PacManPower.normal || pacPow == PacManPower.Empower)
                    {
                        rotaçao = Math.PI;
                        PacMove = PacManState.GoingLeft;
                        position = nextPosition;
                        if (position.X < 10 && position.Y > 279 && position.Y < 281) position = new Vector2(26 * 20, 280);
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                nextPosition = new Vector2(position.X, position.Y - speed * deltaTime - superspeed);
                
                if (CheckCollisions(nextPosition).Count == 0) 
                {
                    if (checkCollisionMOB(nextPosition).Count != 0 && pacPow != PacManPower.untergetable)
                    {
                        lifes--;
                        pacPow = PacManPower.untergetable;
                        if (lifes == 0)
                            gamestatechangerToLost = true;
                    }
                    if (pacPow == PacManPower.untergetable || pacPow == PacManPower.normal || pacPow == PacManPower.Empower)
                    {
                        rotaçao = -Math.PI / 2;
                        PacMove = PacManState.GoingUp;
                        position = nextPosition;
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                nextPosition = new Vector2(position.X + speed * deltaTime + superspeed, position.Y);
                
                if (CheckCollisions(nextPosition).Count == 0) 
                {
                    if (checkCollisionMOB(nextPosition).Count != 0 && pacPow != PacManPower.untergetable)
                    {
                        lifes--;
                        pacPow = PacManPower.untergetable;
                        if (lifes == 0)
                            gamestatechangerToLost = true;
                    }
                    if (pacPow == PacManPower.untergetable || pacPow == PacManPower.normal || pacPow == PacManPower.Empower)
                    {
                        rotaçao = 0;
                        PacMove = PacManState.GoingRight;
                        position = nextPosition;
                        if (position.X < 533 && position.X > 531 && position.Y > 279 && position.Y < 281) position = new Vector2(15, 280);
                    }         
                }       
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                nextPosition = new Vector2(position.X, position.Y + speed * deltaTime + superspeed);
                if (CheckCollisions(nextPosition).Count == 0) 
                {
                    if (checkCollisionMOB(nextPosition).Count != 0 && pacPow != PacManPower.untergetable)
                    {
                        lifes--;
                        pacPow = PacManPower.untergetable;
                        if (lifes == 0)
                            gamestatechangerToLost = true;
                    }
                    if (pacPow == PacManPower.untergetable || pacPow == PacManPower.normal || pacPow == PacManPower.Empower)
                    {
                        rotaçao = Math.PI / 2;
                        PacMove = PacManState.GoingDown;
                        position = nextPosition;
                    }
                    
                }
            }
            #endregion

            #region CheckComida

            if (checkCollisionMOB(nextPosition).Count != 0 && pacPow != PacManPower.untergetable)
            {
                lifes--;
                pacPow = PacManPower.untergetable;
                if (lifes == 0)
                    gamestatechangerToLost = true;
            }

            if (room.Checkcomida(position) == 5)
            {
                coin1.Play();
                room.DestroySquare(position);
                score += 1;            
            }
            if (room.Checkcomida(position) == 4)
            {
                if (pacPow == PacManPower.Empower)
                timerPower = 5;
                   
            
                else
                {
                    pacPow = PacManPower.Empower;
                    tiros = new Projeteis(new Vector2(270,320), 0, PacMove, cam);
                    superspeed = 0.3f;
                    coin10.Play();
                    room.DestroySquare(position);
                    score += 5;
                }
            }
            #endregion

            Rec = new Rectangle((int)Math.Round(position.X), (int)Math.Round(position.Y), TextureSize, TextureSize);
            if(tiros != null)
                    tiros.update(gameTime);
        }


        public Vector2 ReturnPosPacmanCamera()
        {
            Vector2 novo = new Vector2();
            novo.X = position.X + 10;
            novo.Y = position.Y + 50;
            return novo;
        }

        public bool gamestateLOST()
        {
            if (gamestatechangerToLost == true)
                return true;
            else return false;
        }

        public List<Rectangle> checkCollisionMOB(Vector2 pos)
        {
            List<Rectangle> collidingWith = new List<Rectangle>();
            Rectangle rect = new Rectangle((int)Math.Round(pos.X), (int)Math.Round(pos.Y), Rec.Width, Rec.Height);

            foreach (Mobs a in Collisions.Phantoms)
            {
                if (rect.Intersects(a.returnrecMob()) && rect != a.returnrecMob())
                {
                    collidingWith.Add(rect);
                }
            }
            return collidingWith;
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
                spriteBatch.DrawString(timer1, string.Format("{0:0.00}", (5 - timerPower)), new Vector2(position.X -2, position.Y + 20), Color.White,0.0f,Vector2.Zero,0.5f,SpriteEffects.None,0.0f);
            }
            if (pacPow == PacManPower.untergetable)
            {
                if (NewTimerUntargetble <= 0.1f)
                    spriteBatch.Draw(textures[currentFrame], new Vector2(position.X + 10, position.Y + 10), null, Color.Green, (float)rotaçao, new Vector2(10, 10), 1f, SpriteEffects.None, 0f);

                if (NewTimerUntargetble >= 0.1f)
                {
                    spriteBatch.Draw(textures[currentFrame], new Vector2(position.X + 10, position.Y + 10), null, Color.White, (float)rotaçao, new Vector2(10, 10), 1f, SpriteEffects.None, 0f);
                }

                spriteBatch.DrawString(timer1, string.Format("{0:0.00}", (3 - timeUntargetble)), new Vector2(position.X - 2, position.Y + 20), Color.White, 0.0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0.0f);
            }
            if (tiros != null)
             tiros.draw(spriteBatch);         
        }

        public Vector2 Position
        {
            get { return position; }
        }
    }
}


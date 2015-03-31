using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAC_Man.isto_ta_tipo_de_medo__building_
{
    class Projeteis : objectpacman
    {
        private Vector2 _position;
        bool visible = false, ExplosionSplash = false;
        private List<Projeteis> _Projeteis = new List<Projeteis>();
        private Rectangle Rec;
        protected Vector2 nextPosition;
        private float Pspeed;
        protected PacManState direction;
        static protected Texture2D projectileTEX;
        static public Texture2D[] splash;
        static public SoundEffect mob;
        static public SoundEffect ricochet;
        private float intervalo = 0.08f, timer;
        private int currentFrame = 0;
        private Vector2 originDraw;
        static Vector2 aux;
        static Rectangle rect;
        Camera2D _Cam;

        public Projeteis(Vector2 startposition, int Pspeed, PacManState direction,Camera2D cam)
        {
            this._position = startposition;
            this.Pspeed = Pspeed;
            this.direction = direction;
            visible = true;
            _Cam = cam;
        }

        static public void load(ContentManager content)
        {
            projectileTEX = content.Load<Texture2D>("Projetil");

            splash = new Texture2D[7];
            splash[0] = content.Load<Texture2D>("splash1");
            splash[1] = content.Load<Texture2D>("splash2");
            splash[2] = content.Load<Texture2D>("splash3");
            splash[3] = content.Load<Texture2D>("splash4");
            splash[4] = content.Load<Texture2D>("splash3");
            splash[5] = content.Load<Texture2D>("splash2");
            splash[6] = content.Load<Texture2D>("splash1");
            mob = content.Load<SoundEffect>("mob_boom");
            ricochet = content.Load<SoundEffect>("Ricochet");
           

        }

        public bool returnVis()
        {
            return visible;
        }

        public void update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timer += deltaTime;

            if(visible == true)
            {
                if (direction == PacManState.GoingDown)
                {
                    nextPosition = new Vector2(_position.X, (_position.Y + Pspeed * deltaTime));
                }
                if (direction == PacManState.GoingLeft)
                {
                    nextPosition = new Vector2((_position.X - Pspeed * deltaTime), _position.Y);
                }
                if (direction == PacManState.GoingRight)
                {
                    nextPosition = new Vector2((_position.X + Pspeed * deltaTime), _position.Y);
                }
                if (direction == PacManState.GoingUp)
                {
                    nextPosition = new Vector2(_position.X, (_position.Y - Pspeed * deltaTime));
                }
            }
            if (CheckCollisionsProjectile(nextPosition).Count != 0 )
            {
                rect = new Rectangle(0, 0, Rec.Width, Rec.Height);
                visible = false;
                ExplosionSplash = true;


                while (timer >= intervalo)
                {
                    currentFrame++;

                    if (currentFrame >= (7))
                    {
                        ExplosionSplash = false;
                        break;
                    }
                    timer = 0;
                }
            }
            
            if (CheckCollisionsProjectileMOBS(nextPosition) != null && visible == true)
            {   
                visible = false;
                CheckCollisionsProjectileMOBS(nextPosition).destroyFuckinMob();
                _Cam.ShakeItOff();
                mob.Play();
                nextPosition = new Vector2(0, 0);
            }
           
            if (_position.X < 533 && _position.X > 529 && _position.Y > 275 && _position.Y < 283) nextPosition = new Vector2(15, 280);
            if (_position.X < 15 && _position.Y > 275 && _position.Y < 285) nextPosition = new Vector2(26 * 20, 280);
            _position = nextPosition;
            aux = nextPosition;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            
            if (visible)
            {
                if (direction == PacManState.GoingDown)
                {
                    originDraw = new Vector2(-7,-10);
                }
                if (direction == PacManState.GoingLeft)
                {
                    originDraw = new Vector2(-5,-5);
                }
                if (direction == PacManState.GoingRight)
                {
                    originDraw = new Vector2(-12,-5);
                }
                if (direction == PacManState.GoingUp)
                {
                    originDraw = new Vector2(-5,-7);
                }
                spriteBatch.Draw(projectileTEX, _position, null, Color.White, 0, originDraw, 1, SpriteEffects.None, 0);
                Rec = new Rectangle((int)Math.Round(_position.X), (int)Math.Round(_position.Y), 15, 15);
            }
            if (ExplosionSplash == true && nextPosition != new Vector2(0, 0))
            {

                if (direction == PacManState.GoingDown)
                {
                    aux = new Vector2(aux.X + 10, aux.Y + 3);
                    spriteBatch.Draw(splash[currentFrame], aux, null, Color.White, (float)(Math.PI / 2), new Vector2(10, 10), 1f, SpriteEffects.None, 0f);
                
                }
                if (direction == PacManState.GoingLeft)
                {
                    aux = new Vector2(aux.X + 13, aux.Y + 8);
                    spriteBatch.Draw(splash[currentFrame], aux, null, Color.White, (float)Math.PI, new Vector2(10, 10), 1f, SpriteEffects.None, 0f);
                }
                if (direction == PacManState.GoingRight)
                {
                    aux = new Vector2(aux.X + 5, aux.Y + 8);
                    spriteBatch.Draw(splash[currentFrame], aux, null, Color.White, 0, new Vector2(10, 10), 1f, SpriteEffects.None, 0f);
                }
                if (direction == PacManState.GoingUp)
                {
                    aux = new Vector2(aux.X + 10, aux.Y + 10);                    
                    spriteBatch.Draw(splash[currentFrame], aux, null, Color.White, (float)(-Math.PI / 2), new Vector2(10, 10), 1f, SpriteEffects.None, 0f);
                }  
             
                
            }

        }


        public List<Rectangle> CheckCollisionsProjectile(Vector2 pos)
        {
            List<Rectangle> collidingWith = new List<Rectangle>();

            rect = new Rectangle((int)Math.Round(pos.X), (int)Math.Round(pos.Y), Rec.Width, Rec.Height);

            foreach (var rectangle in Collisions.Rectangles)
            {

                if (rect.Intersects(rectangle) && rect != rectangle)
                {
                   collidingWith.Add(rectangle);


                }
            }
            return collidingWith;

            
        }


        //isto supostamente ta a dar para a collisao do projetil com o mob!
        //agora temos de pensar como vamos fazer com o mob
        //como ele vai reagir
        public Mobs CheckCollisionsProjectileMOBS(Vector2 pos)
        {
            List<Rectangle> Collinding = new List<Rectangle>();
            rect = new Rectangle((int)Math.Round(pos.X), (int)Math.Round(pos.Y), Rec.Width, Rec.Height);
            
            foreach (Mobs Ghost in Collisions.Phantoms)
            {   
                if (rect.Intersects(Ghost.returnrecMob()) && rect != Ghost.returnrecMob())
                {
                    return Ghost;
                    
                }
            }
            return null;
        }





    }
}

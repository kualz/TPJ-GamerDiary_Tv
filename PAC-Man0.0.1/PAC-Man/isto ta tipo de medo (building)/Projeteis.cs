using Microsoft.Xna.Framework;
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
        bool visible = false;
        private List<Projeteis> _Projeteis = new List<Projeteis>();
        private Rectangle Rec;
        protected Vector2 nextPosition;
        private float Pspeed;
        protected PacManState direction;
        static protected Texture2D projectileTEX;
        Vector2 originDraw;

        public Projeteis(Vector2 startposition, int Pspeed, PacManState direction)
        {
            this._position = startposition;
            this.Pspeed = Pspeed;
            this.direction = direction;
            visible = true;
        }

        static public void load(ContentManager content)
        {
            projectileTEX = content.Load<Texture2D>("Projetil");
        }

        public bool returnVis()
        {
            return visible;
        }

        public void update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

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
                visible = false;
                nextPosition = new Vector2(0, 0);
            }
            if (CheckCollisionsProjectileMOBS(nextPosition) != null)
            {   
                visible = false;
                CheckCollisionsProjectileMOBS(nextPosition).destroyFuckinMob();
                nextPosition = new Vector2(0, 0);
            }
            _position = nextPosition;
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
                spriteBatch.Draw(projectileTEX, nextPosition, null, Color.White, 0, originDraw, 1, SpriteEffects.None, 0);
                Rec = new Rectangle((int)Math.Round(_position.X), (int)Math.Round(_position.Y), 15, 15);
            }
        }

        public void Firing()
        {

        }

        public List<Rectangle> CheckCollisionsProjectile(Vector2 pos)
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


        //isto supostamente ta a dar para a collisao do projetil com o mob!
        //agora temos de pensar como vamos fazer com o mob
        //como ele vai reagir
        public Mobs CheckCollisionsProjectileMOBS(Vector2 pos)
        {
            List<Rectangle> Collinding = new List<Rectangle>();
            Rectangle rect = new Rectangle((int)Math.Round(pos.X), (int)Math.Round(pos.Y), Rec.Width, Rec.Height);

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

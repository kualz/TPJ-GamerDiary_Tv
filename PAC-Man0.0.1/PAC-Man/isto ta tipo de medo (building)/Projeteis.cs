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
        Vector2 _position;
        bool visible = false;
        List<Projeteis> _Projeteis = new List<Projeteis>();
        Texture2D projectileTEX;
        Rectangle Rec;
        protected Vector2 nextPosition;
        int Pspeed;
        PacManState direction;

        public Projeteis(Vector2 position, int Pspeed, PacManState direction)
        {
            this._position = position;
            this.Pspeed = Pspeed;
            this.direction = direction;
            visible = true;
        }

        public void load(ContentManager contentManager)
        {
            projectileTEX = contentManager.Load<Texture2D>("Projetil");
        }

        public void update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(visible == true)
            {
                if (direction == PacManState.GoingDown)
                    nextPosition = new Vector2(position.X, position.Y + Pspeed * deltaTime);
                if (direction == PacManState.GoingLeft)
                    nextPosition = new Vector2(position.X - Pspeed * deltaTime, position.Y);
                if (direction == PacManState.GoingRight)
                    nextPosition = new Vector2(position.X + Pspeed * deltaTime, position.Y);
                if (direction == PacManState.GoingUp)
                    nextPosition = new Vector2(position.X, position.Y - Pspeed * deltaTime);
            }
            if(CheckCollisionsProjectile(nextPosition).Count != 0)
            {
                visible = false;
            }
            position = nextPosition;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                spriteBatch.Draw(projectileTEX, position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
                Rec = new Rectangle((int)Math.Round(position.X), (int)Math.Round(position.Y), 15, 15);
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







    }
}

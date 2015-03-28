using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace PAC_Man
{
    class MenuScene
    {
        public List<string> Options = new List<string>();
        public SpriteFont spriteFont;
        public Texture2D sprite;
        private int selectedOption;
        public bool isRunning = false;

        public MenuScene()
        {
            selectedOption = 0;
        }

        public void Load(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Bitmap4 - Copy");
            spriteFont = content.Load<SpriteFont>("MyFont");

            Options.Add("Continue");
            Options.Add("Start new Game");
            Options.Add("Exit");
        }

        public void Update(GameTime gameTime, Game1 game)
        {

            if(Input.IsPressed(Keys.Down))
            {
                selectedOption++;
                if (selectedOption >= Options.Count) selectedOption = 0;
            }
            if (Input.IsPressed(Keys.Up))
            {
                selectedOption--;
                if (selectedOption < 0) selectedOption = Options.Count - 1;
            }

            if(Input.IsPressed(Keys.Enter))
                switch (selectedOption)
                {
                    case 0:
                        //if(isRunning == true)
                            game.gamestate = Game1.GameState.running;
                        break;
                    case 1:
                        {
                            isRunning = true;
                            game.loadReset();
                            game.gamestate = Game1.GameState.running;
                        }
                        break;  
                    case 2:
                        game.Exit();
                        break;
                }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite,new Rectangle(80, 80, 190, 150), Color.CadetBlue);
            for (int i = 0; i < Options.Count; i++)
            {
                if (selectedOption != i)
                {
                    spriteBatch.DrawString(spriteFont, Options[i], new Vector2(100, 100 + i * 40), Color.Black);
                }
                else
                {
                    spriteBatch.DrawString(spriteFont, Options[i], new Vector2(100, 100 + i * 40), Color.Orange);
                }
            }
        }
    }
}

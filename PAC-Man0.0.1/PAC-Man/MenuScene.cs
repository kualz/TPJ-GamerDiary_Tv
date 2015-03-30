using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PAC_Man
{
    class MenuScene
    {
        public List<string> Options = new List<string>();
        public SpriteFont spriteFont;
        public Texture2D sprite;
        public Song menu;
        private int selectedOption;
        public Song songame;
        public bool isRunning = false;
        public bool songStart = false;

        public MenuScene()
        {
           
            selectedOption = 0;
        }

        public void Load(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Bitmap4 - Copy");
            spriteFont = content.Load<SpriteFont>("MyFont");

            menu = content.Load<Song>("Transistor");
            MediaPlayer.Play(menu);

            songame = content.Load<Song>("songame");


            Options.Add("Continue");
            Options.Add("Start new Game");
            Options.Add("Exit");
        }

        public void Update(GameTime gameTime, Game1 game)
        {




            if (Input.IsPressed(Keys.Down))
            {
                selectedOption++;
                if (selectedOption >= Options.Count) selectedOption = 0;
            }
            if (Input.IsPressed(Keys.Up))
            {
                selectedOption--;
                if (selectedOption < 0) selectedOption = Options.Count - 1;
            }

            if (Input.IsPressed(Keys.Enter))
                switch (selectedOption)
                {
                    case 0:
                        //if(isRunning == true)
                        game.gamestate = Game1.GameState.running;
                        MediaPlayer.Play(songame);

                        break;
                    case 1:
                        {
                            isRunning = true;

                            game.loadReset();
                            game.gamestate = Game1.GameState.running;
                            MediaPlayer.Play(songame);

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

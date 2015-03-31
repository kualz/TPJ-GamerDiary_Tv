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
        public static bool auxMenu = false;


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
            if (auxMenu == false)
            {
                if (Input.IsPressed(Keys.Down))
                {
                    selectedOption++;
                    if (selectedOption >= Options.Count ) selectedOption = 1;
                }
                if (Input.IsPressed(Keys.Up))
                {
                    selectedOption--;
                    if (selectedOption < 1) selectedOption = Options.Count -1;
                }
            }
            else
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
            }
            if (Input.IsPressed(Keys.Enter))
                switch (selectedOption)
                {
                    case 0:
                        {
                            MediaPlayer.Volume = 1f;
                            game.gamestate = Game1.GameState.running;
                        }
                        break;
                    case 1:
                        {
                            isRunning = true;

                            game.loadReset();
                            game.gamestate = Game1.GameState.running;
                            MediaPlayer.Play(songame);
                            auxMenu = true;

                        }
                        break;
                    case 2:
                        {
                            game.Exit();
                        }
                        break;
                }
           
            }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite,new Rectangle(80, 80, 190, 150), Color.CadetBlue);
            if (auxMenu == true)
            {
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
            else
            for (int i = 1; i < Options.Count; i++)
            {
                if (selectedOption != i)
                {
                    spriteBatch.DrawString(spriteFont, Options[i], new Vector2(100, 50 + i * 40), Color.Black);

                    
                }
                else
                {
                    spriteBatch.DrawString(spriteFont, Options[i], new Vector2(100, 50 + i * 40), Color.Orange);
                }
            }
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAC_Man
{
    class Room
    {
        private byte[,] board = 
                        {{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                         {1,4,5,5,5,5,5,5,5,5,5,5,5,1,1,5,5,5,5,5,5,5,5,5,5,5,4,1},
                         {1,5,1,1,1,1,5,1,1,1,1,1,5,1,1,5,1,1,1,1,1,5,1,1,1,1,5,1},
                         {1,5,1,9,9,1,5,1,9,9,9,1,5,1,1,5,1,9,9,9,1,5,1,9,9,1,5,1},
                         {1,5,1,1,1,1,5,1,1,1,1,1,5,1,1,5,1,1,1,1,1,5,1,1,1,1,5,1},
                         {1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1},
                         {1,5,1,1,1,1,5,1,1,5,1,1,1,1,1,1,1,1,5,1,1,5,1,1,1,1,5,1},
                         {1,5,1,1,1,1,5,1,1,5,1,1,1,1,1,1,1,1,5,1,1,5,1,1,1,1,5,1},
                         {1,5,5,5,5,5,5,1,1,5,5,5,5,1,1,5,5,5,5,1,1,5,5,5,5,5,5,1},
                         {1,1,1,1,1,1,5,1,1,1,1,1,0,1,1,0,1,1,1,1,1,5,1,1,1,1,1,1},
                         {9,9,9,9,9,1,5,1,1,1,1,1,0,1,1,0,1,1,1,1,1,5,1,9,9,9,9,9},
                         {9,9,9,9,9,1,5,1,1,0,0,0,0,0,0,0,0,0,0,1,1,5,1,9,9,9,9,9},
                         {9,9,9,9,9,1,5,1,1,0,1,1,1,1,1,1,1,1,0,1,1,5,1,9,9,9,9,9},
                         {1,1,1,1,1,1,5,1,1,0,1,2,2,2,2,2,2,1,0,1,1,5,1,1,1,1,1,1},
                         {7,0,0,0,0,0,5,0,0,0,1,2,2,2,2,2,2,1,0,0,0,5,0,0,0,0,0,7},
                         {1,1,1,1,1,1,5,1,1,0,1,2,2,2,2,2,2,1,0,1,1,5,1,1,1,1,1,1},
                         {9,9,9,9,9,1,5,1,1,0,1,1,1,1,1,1,1,1,0,1,1,5,1,9,9,9,9,9},
                         {9,9,9,9,9,1,5,1,1,0,0,0,0,0,0,0,0,0,0,1,1,5,1,9,9,9,9,9},
                         {9,9,9,9,9,1,5,1,1,0,1,1,1,1,1,1,1,1,0,1,1,5,1,9,9,9,9,9},
                         {1,1,1,1,1,1,5,1,1,0,1,1,1,1,1,1,1,1,0,1,1,5,1,1,1,1,1,1},
                         {1,5,5,5,5,5,5,5,5,5,5,5,5,1,1,5,5,5,5,5,5,5,5,5,5,5,5,1},
                         {1,5,1,1,1,1,5,1,1,1,1,1,5,1,1,5,1,1,1,1,1,5,1,1,1,1,5,1},
                         {1,5,1,1,1,1,5,1,1,1,1,1,5,1,1,5,1,1,1,1,1,5,1,1,1,1,5,1},
                         {1,5,5,5,1,1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1,1,5,5,5,1},
                         {1,1,1,5,1,1,5,1,1,5,1,1,1,1,1,1,1,1,5,1,1,5,1,1,5,1,1,1},
                         {1,1,1,5,1,1,5,1,1,5,1,1,1,1,1,1,1,1,5,1,1,5,1,1,5,1,1,1},
                         {1,5,5,5,5,5,5,1,1,5,5,5,5,1,1,5,5,5,5,1,1,5,5,5,5,5,5,1},
                         {1,5,1,1,1,1,1,1,1,1,1,1,5,1,1,5,1,1,1,1,1,1,1,1,1,1,5,1},
                         {1,5,1,1,1,1,1,1,1,1,1,1,5,1,1,5,1,1,1,1,1,1,1,1,1,1,5,1},
                         {1,4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,4,1},
                         {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}};

        private List<Rectangle> Colisoes = new List<Rectangle>();
        private int TextureSize = 20;
        private Rectangle Rec;
        private Texture2D[] FOOD;
        private Texture2D[] FOOD1;
        private Texture2D square;
        private Texture2D square2;
        private Texture2D square3;
        private Texture2D[] square4;
        private Random rand;
        private bool mazeCreated = false;
        private List<Texture2D> texturas = new List<Texture2D>();
        public Texture2D[] Portal;
        private Texture2D NoFOOD1;
        private int currentFrame = 0, currentFrameTexturas = 0, currentFrameBigFood = 0;
        private float timer, intervalo = 0.12f, timerTexturas, texturaFood;
        private int GenRandom = 0;

        public void Load(ContentManager content)
        {
            Portal = new Texture2D[3];
            Portal[0] = content.Load<Texture2D>("1portal");
            Portal[1] = content.Load<Texture2D>("2portal");
            Portal[2] = content.Load<Texture2D>("3portal");

            NoFOOD1 = content.Load<Texture2D>("Bitmap3");

            FOOD = new Texture2D[7];
            FOOD[0] = content.Load<Texture2D>("Bitmap2");
            FOOD[1] = content.Load<Texture2D>("Bitmap2.3");
            FOOD[2] = content.Load<Texture2D>("Bitmap2.2");
            FOOD[3] = content.Load<Texture2D>("Bitmap2.1");
            FOOD[4] = content.Load<Texture2D>("Bitmap2.2");
            FOOD[5] = content.Load<Texture2D>("Bitmap2.3");
            FOOD[6] = content.Load<Texture2D>("Bitmap2");

            FOOD1 = new Texture2D[3];
            FOOD1[0] = content.Load<Texture2D>("Bitmap3");
            FOOD1[1] = content.Load<Texture2D>("Bitmap3.1");
            FOOD1[2] = content.Load<Texture2D>("Bitmap3.2");

            square = content.Load<Texture2D>("square");

            square2 = content.Load<Texture2D>("square2");
            
            
            square3 = content.Load<Texture2D>("square3");



            square4 = new Texture2D[2];
            square4[0] = content.Load<Texture2D>("square4");
            square4[1] = content.Load<Texture2D>("square4.1");

            
            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    if (mazeCreated == false)
                    {
                        if (board[y, x] == 1)
                        {
                            GenRandom = RandomGen();
                            if (GenRandom == 0)
                                texturas.Add(square2);
                            if (GenRandom == 1)
                                texturas.Add(square3);
                            if (GenRandom == 2)
                                texturas.Add(square4[0]);
                            if (GenRandom == 3 || GenRandom == 4)
                                texturas.Add(square);
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int i = 0;
            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    if (board[y, x] == 1)
                    {
                        if (i < texturas.Count)
                        {
                            if (texturas[i] == texturas[4])
                                spriteBatch.Draw(square4[currentFrameTexturas], new Rectangle(x * 20, y * 20, 20, 20), Color.White);
                            else
                                spriteBatch.Draw(texturas[i], new Rectangle(x * 20, y * 20, 20, 20), Color.White);
                            i++;
                        }
                    }
                    if (board[y, x] == 2)
                        spriteBatch.Draw(square, new Rectangle(x * 20, y * 20, 20, 20), Color.White);
                    if (board[y, x] == 4)
                        spriteBatch.Draw(FOOD[currentFrameBigFood], new Vector2(x * TextureSize, y * TextureSize), Color.White);
                    if (board[y, x] == 5)
                        spriteBatch.Draw(FOOD1[currentFrame], new Rectangle(x * 20, y * 20, 20, 20), Color.White);
                    if (board[y, x] == 0)
                        spriteBatch.Draw(NoFOOD1, new Rectangle(x * 20, y * 20, 20, 20), Color.Black);
                    if (board[y,x] == 7)
                        spriteBatch.Draw(Portal[currentFrame], new Rectangle(x * 20, y * 20, 20, 20), Color.White);
                }
            }
            mazeCreated = true;
        }

        public void updateportal(GameTime gametime)
        {
            float deltaTime = (float)gametime.ElapsedGameTime.TotalSeconds;
            timerTexturas += deltaTime;
            timer += deltaTime;
            texturaFood += deltaTime;
            if (timer >= intervalo)
            {
                currentFrame++;
                if (currentFrame >= (3))
                {
                    currentFrame = 0;
                }
                timer = 0;
            }

            if (timerTexturas >= (0.5))
            {
                currentFrameTexturas++;
                if (currentFrameTexturas >= (2))
                {
                    currentFrameTexturas = 0;
                }
                timerTexturas = 0;
            }


            if (texturaFood >= (0.08))
            {
                currentFrameBigFood++;
                if (currentFrameBigFood >= (7))
                {
                    currentFrameBigFood = 0;
                }
                texturaFood = 0;
            }
        }


        public void InicializarColisoes()
        {
            for (int y = 0; y < board.GetLength(0); y++)
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    if (board[y, x] == 1)
                    {
                        Rec = new Rectangle(x * TextureSize, y * TextureSize, 20, 20);
                        Collisions.Rectangles.Add(Rec);
                    }
                    if (board[y, x] == 4)
                    {
                        Rec = new Rectangle(x * TextureSize, y * TextureSize, 20, 20);
                        Collisions.Food.Add(Rec);
                    }
                    if (board[y, x] == 5)
                    {
                        Rec = new Rectangle(x * TextureSize, y * TextureSize, 20, 20);
                        Collisions.Bigfood.Add(Rec);
                    }
                }
        }

        private int RandomGen()
        {
            int aux = 0;
            rand = new Random(Guid.NewGuid().GetHashCode());
            aux = rand.Next(0, 5);
            return aux;
        }

        public void DestroySquare(Vector2 pos)
        {
            board[(int)Math.Round(pos.Y / 20), (int)Math.Round(pos.X / 20)] = 0;
        }

        public int Checkcomida(Vector2 pos)
        {
            return board[(int)Math.Round(pos.Y / 20), (int)Math.Round(pos.X / 20)];
        }

        public bool WinTest()
        {int g = 0;
            for (int y = 0; y < board.GetLength(0); y++)
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    if (board[y, x] == 5 || board[y, x] == 4)
                        g++;
                }
            if (g == 0)
                return true;
            else return false;
        }

    }
}

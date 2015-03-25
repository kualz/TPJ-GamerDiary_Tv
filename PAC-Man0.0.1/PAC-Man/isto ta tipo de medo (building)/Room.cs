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
                         {0,0,0,0,0,0,5,0,0,0,1,2,2,2,2,2,2,1,0,0,0,5,0,0,0,0,0,0},
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
        private Texture2D FOOD;
        private Texture2D FOOD1;
        private Texture2D NoFOOD1;
        private Texture2D square;
        private Texture2D square2;
        private Texture2D square3;
        private Texture2D square4;
        private Random rand;
        private bool mazeCreated = false;
        List<Texture2D> texturas = new List<Texture2D>();

        public void Load(ContentManager content)
        {
            FOOD = content.Load<Texture2D>("Bitmap2");
            NoFOOD1 = content.Load<Texture2D>("Bitmap3 - Copy");
            FOOD1 = content.Load<Texture2D>("Bitmap3");
            square = content.Load<Texture2D>("square");
            square2 = content.Load<Texture2D>("square2");
            square3 = content.Load<Texture2D>("square3");
            square4 = content.Load<Texture2D>("square4");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int GenRandom = 0, i = 0;
            for (int y = 0; y < board.GetLength(0); y++)
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    if (mazeCreated == false)
                    {
                        if (board[y, x] == 1)
                        {
                            GenRandom = RandomGen();
                            if (GenRandom == 1)
                            {
                                spriteBatch.Draw(square2, new Rectangle(x * 20, y * 20, 20, 20), Color.White);
                                texturas.Add(square2);
                            }
                            if (GenRandom == 2)
                            {
                                spriteBatch.Draw(square3, new Rectangle(x * 20, y * 20, 20, 20), Color.White);
                                texturas.Add(square3);
                            }
                            if (GenRandom == 3)
                            {
                                spriteBatch.Draw(square4, new Rectangle(x * 20, y * 20, 20, 20), Color.White);
                                texturas.Add(square4);
                            }
                            if (GenRandom == 4 || GenRandom == 5 || GenRandom == 6)
                            {
                                spriteBatch.Draw(square, new Rectangle(x * 20, y * 20, 20, 20), Color.White);
                                texturas.Add(square);
                            }
                        }
                    }
                    else
                        if (board[y, x] == 1)
                        {
                            if (i < texturas.Count())
                            {
                                spriteBatch.Draw(texturas[i], new Rectangle(x * 20, y * 20, 20, 20), Color.White);
                                i++;
                            }
                        }
                    if (board[y, x] == 2)
                        spriteBatch.Draw(square, new Rectangle(x * 20, y * 20, 20, 20), Color.White);
                    if (board[y, x] == 4)
                        spriteBatch.Draw(FOOD, new Vector2(x * TextureSize, y * TextureSize), Color.White);
                    if (board[y, x] == 5)
                        spriteBatch.Draw(FOOD1, new Rectangle(x * 20, y * 20, 20, 20), Color.White);
                    if (board[y, x] == 0)
                        spriteBatch.Draw(NoFOOD1, new Rectangle(x * 20, y * 20, 20, 20), Color.White);
                }
            mazeCreated = true;
        }

        private int RandomGen()
        {
            int aux = 0;
            rand = new Random(Guid.NewGuid().GetHashCode());
            aux = rand.Next(1, 6);
            return aux;   
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

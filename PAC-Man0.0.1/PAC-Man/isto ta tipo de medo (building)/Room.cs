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
                         {9,9,9,9,9,1,5,1,1,0,1,1,1,2,2,1,1,1,0,1,1,5,1,9,9,9,9,9},
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
        private Texture2D square;

        public void Load(ContentManager content)
        {
            FOOD = content.Load<Texture2D>("Bitmap2");
            FOOD1 = content.Load<Texture2D>("Bitmap3");
            square = content.Load<Texture2D>("square");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < board.GetLength(0); y++)
                for (int x = 0; x < board.GetLength(1); x++)
                {

                    if (board[y, x] == 1)
                        spriteBatch.Draw(square, new Vector2(x * TextureSize, y * TextureSize), Color.Blue);
                    if (board[y, x] == 2)
                        spriteBatch.Draw(square, new Vector2(x * TextureSize, y * TextureSize), Color.White);
                    if (board[y, x] == 4)
                        spriteBatch.Draw(FOOD, new Vector2(x * TextureSize, y * TextureSize), Color.White);
                    if (board[y, x] == 5)
                        spriteBatch.Draw(FOOD1, new Vector2(x * TextureSize, y * TextureSize), Color.White);
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

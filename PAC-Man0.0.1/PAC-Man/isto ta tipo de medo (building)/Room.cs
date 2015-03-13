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
        private Rectangle Rec1 = new Rectangle();
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

                    if(board[y,x] == 1)
                        spriteBatch.Draw(square, new Vector2(x * 20, y * 20), Color.Blue);
                    if(board[y,x] == 2)
                            spriteBatch.Draw(square, new Vector2(x * 20, y * 20), Color.White);
                    if(board[y,x] == 4)
                        spriteBatch.Draw(FOOD, new Vector2(x * 20, y * 20), Color.White);
                    if(board[y,x] == 5)
                        spriteBatch.Draw(FOOD1, new Vector2(x * 20, y * 20), Color.White);                   
                }
        }

        public void InicializarColisoes()
        {
            for (int y = 0; y < board.GetLength(0); y++)
                for (int x = 0; x < board.GetLength(1); x++)
                    if (board[y, x] == 1)
                    {
                        Rec = new Rectangle(x * TextureSize, y * TextureSize, 20, 20);
                        Colisoes.Add(Rec);
                    }
        }

        public bool IsColliding(float _X, float _Y)
        {
            if (board[((_Y + 20) / 20), (_X / 20)] != 1)
                return true;
            else return false;
        }
    }
}

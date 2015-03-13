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
                         {1,5,1,1,1,1,5,1,1,1,1,1,5,1,1,5,1,1,1,1,1,5,1,1,1,1,5,1},
                         {1,5,1,1,1,1,5,1,1,1,1,1,5,1,1,5,1,1,1,1,1,5,1,1,1,1,5,1},
                         {1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1},
                         {1,5,1,1,1,1,5,1,1,5,1,1,1,1,1,1,1,1,5,1,1,5,1,1,1,1,5,1},
                         {1,5,1,1,1,1,5,1,1,5,1,1,1,1,1,1,1,1,5,1,1,5,1,1,1,1,5,1},
                         {1,5,5,5,5,5,5,1,1,5,5,5,5,1,1,5,5,5,5,1,1,5,5,5,5,5,5,1},
                         {1,1,1,1,1,1,5,1,1,1,1,1,0,1,1,0,1,1,1,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,1,1,1,0,1,1,0,1,1,1,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,0,0,0,0,0,0,0,0,0,0,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,0,1,1,1,2,2,1,1,1,0,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,0,1,2,2,2,2,2,2,1,0,1,1,5,1,1,1,1,1,1},
                         {0,0,0,0,0,0,5,0,0,0,1,2,2,2,2,2,2,1,0,0,0,5,0,0,0,0,0,0},
                         {1,1,1,1,1,1,5,1,1,0,1,2,2,2,2,2,2,1,0,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,0,1,1,1,1,1,1,1,1,0,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,0,0,0,0,0,0,0,0,0,0,1,1,5,1,1,1,1,1,1},
                         {1,1,1,1,1,1,5,1,1,0,1,1,1,1,1,1,1,1,0,1,1,5,1,1,1,1,1,1},
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
        private objectpacman trynew = new objectpacman();
        private Texture2D FOOD;
        private Texture2D FOOD1;
        private Texture2D square;

        public void Load(ContentManager content)
        {
            InicializarColisoes();
            FOOD = content.Load<Texture2D>("Bitmap2");
            FOOD1 = content.Load<Texture2D>("Bitmap3");
            square = content.Load<Texture2D>("square");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < board.GetLength(0); y++)
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    switch (board[y, x])
                    {
                        case 1:
                            spriteBatch.Draw(square, new Vector2(x * 20, y * 20), Color.Blue);
                            break;
                        case 2:
                            spriteBatch.Draw(square, new Vector2(x * 20, y * 20), Color.White);
                            break;
                        case 4:
                            spriteBatch.Draw(FOOD, new Vector2(x * 20, y * 20), Color.White);
                            break;
                        case 5:
                            spriteBatch.Draw(FOOD1, new Vector2(x * 20, y * 20), Color.White);
                            break;
                    }
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

        public bool IsColliding(Rectangle PacMan_rectangle)
        {
            //1 = down
            //2 = left
            //3 = right
            //4 = up
            switch (trynew.GetPacstate())
            {
                case 1:
                    {
                        for (int x = 0; x < Colisoes.Count(); x++)
                        {
                            Rec1 = Colisoes[x];
                            if (Rec1.Location.X == PacMan_rectangle.Location.X && Rec1.Location.Y == PacMan_rectangle.Location.Y + 20)
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                case 2:
                    {
                        for (int x = 0; x < Colisoes.Count(); x++)
                        {
                            Rec1 = Colisoes[x];
                            if (Rec1.Location.X == PacMan_rectangle.Location.X && Rec1.Location.Y == PacMan_rectangle.Location.Y)
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                    
                case 3:
                    {
                        for (int x = 0; x < Colisoes.Count(); x++)
                        {
                            Rec1 = Colisoes[x];
                            if (Rec1.Location.X == PacMan_rectangle.Location.X + 20 && Rec1.Location.Y == PacMan_rectangle.Location.Y)
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                case 4:
                    {
                        for (int x = 0; x < Colisoes.Count(); x++)
                        {
                            Rec1 = Colisoes[x];
                            if (Rec1.Location.X == PacMan_rectangle.Location.X && Rec1.Location.Y == PacMan_rectangle.Location.Y -20)
                            {
                                return true;
                            }        
                        }
                    }
                    return false;
            }
            return false;
        }
    }
}

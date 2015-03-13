using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PAC_Man
{
    class Collisions : Room
    {

        private Rectangle parent;


        public Collisions(Rectangle parent, int x, int y, int witdth, int height)
        {
            parent = new Rectangle(x, y, witdth, height);
        }




        static public bool canGoUp(int _X, int _Y)
        { 
            if (board[((_Y - 20) / 20), (_X / 20)] != 1)
                return true;
            else return false;
        }

        static public bool canGoDown(int _X, int _Y)
        {
            if (board[((_Y + 20) / 20), (_X / 20)] != 1)
                return true;
            else return false;
        }

        static public bool canGoleft(int _X, int _Y)
        {
            if (board[(_Y / 20), ((_X - 20) / 20)] != 1)
                return true;
            else return false;
        }

        static public bool canGoRight(int _X, int _Y)
        {
            if (board[(_Y / 20), ((_X + 20) / 20)] != 1)
                return true;
            else return false;
        }
    }
}

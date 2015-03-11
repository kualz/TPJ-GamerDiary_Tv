using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PAC_Man
{
    class Collisions : Game1
    {
        static public bool canGoUp(int _X, int _Y)
        {
            if (board[(_X / 20), ((_Y - 20) / 20)] == 4 ||
                board[(_X / 20), ((_Y - 20) / 20)] == 5 ||
                board[(_X / 20), ((_Y - 20) / 20)] == 0)
                return true;
            else return false;
        }

        static public bool canGoDown(int _X, int _Y)
        {
            if (board[(_X / 20), ((_Y + 20) / 20)] == 4 ||
                board[(_X / 20), ((_Y + 20) / 20)] == 5 ||
                board[(_X / 20), ((_Y + 20) / 20)] == 0)
                return true;
            else return false;
        }

        static public bool canGoleft(int _X, int _Y)
        {
            if (board[((_X - 20) / 20), (_Y / 20)] == 4 ||
                board[((_X - 20) / 20), (_Y / 20)] == 5 ||
                board[((_X - 20) / 20), (_Y / 20)] == 0)
                return true;
            else return false;
        }

        static public bool canGoRight(int _X, int _Y)
        {
            if (board[((_X + 20) / 20), (_Y / 20)] == 4 ||
                board[((_X + 20) / 20), (_Y / 20)] == 5 ||
                board[((_X + 20) / 20), (_Y / 20)] == 0)
                return true;
            else return false;
        }
    }
}

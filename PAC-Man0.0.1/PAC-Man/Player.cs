using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAC_Man
{
    class Player
    {
        private int Px;
        private int Py;

        public Player(int Px, int Py)
        {
            this.Px = Px;
            this.Py = Py;
        }

        public void Change_Py(int Value)
        {
            this.Py = (Value);
        }

        public void change_Px(int Value)
        {
            this.Px = (Value);
        }

        public int _Px()
        {
            return this.Px;
        }

        public int _Py()
        {
            return this.Py;
        }

        public void Incrementa_PX()
        {
            this.Px++;
        }

        public void Decrementa_PX()
        {
            this.Px--;
        }

        public void Incrementa_PY()
        {
            this.Py++;
        }

        public void Decrementa_PY()
        {
            this.Py--;
        }


    }
}

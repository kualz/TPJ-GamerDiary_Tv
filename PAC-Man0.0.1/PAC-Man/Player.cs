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
        public enum PlayerState
        {
            normal,
            empowered
        };
        public PlayerState state;
        public double speed;

        public Player(int Px, int Py)
        {
            this.Px = Px;
            this.Py = Py;
            this.state = PlayerState.normal;
            this.speed = 5;
        }
        
        public double Get_PacMan_Speed()
        {
            return this.speed;
        }

        public void Change_Speed()
        {
            if (speed == 5)
                speed = 2.5;
            else speed = 5;
        }

        public void Set_Player_State()
        {
            if (state == PlayerState.normal)
                state = PlayerState.empowered;
            else state = PlayerState.normal;
        }

        public PlayerState Get_PlayerState(){
            return state;
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

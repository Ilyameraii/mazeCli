using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeCli
{
    internal class Player
    {
        public char Skin;
        public int PosX;
        public int PosY;
        public int newX;
        public int newY;
        public Player()
        {
            Skin = Program.Skin;
            PosX = Program.StartX;
            PosY = Program.StartY;
        }
        public void Move(int direction)
        {
            switch (direction)
            {
                case Program.UP:
                    PosY -= 1;
                    break;
                case Program.RIGHT:
                    PosX += 1;
                    break;
                case Program.DOWN:
                    PosY += 1;
                    break;
                case Program.LEFT:
                    PosX -= 1;
                    break;
                default: break;
            }
        }
    }
}

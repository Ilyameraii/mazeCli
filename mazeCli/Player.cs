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
        public Player()
        { 
            Skin = Constants.Skin;
            PosX = Constants.StartX;
            PosY = Constants.StartY;
        }
        public void Move(int direction)
        {
            switch (direction)
            {
                case Constants.UP:
                    PosY -= 1;
                    break;
                case Constants.RIGHT:
                    PosX += 1;
                    break;
                case Constants.DOWN:
                    PosY += 1;
                    break;
                case Constants.LEFT:
                    PosX -= 1;
                    break;
                default: break;
            }
        }
    }
}

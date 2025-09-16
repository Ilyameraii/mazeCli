using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace mazeCli
{
    internal class MapRenderer
    {
        private char[,] Maze;
        private Player Player;
        private Point Finish;
        public MapRenderer(char[,] maze, Point Finish, Player player) {
            this.Maze = maze;
            this.Player = player;
            this.Finish = Finish;
        }

        public void MapRendering()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < Maze.GetLength(0); i++)
            {
                for (int j = 0; j < Maze.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j, i);
                    if (Maze[i, j] == ' ')
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.Write(Maze[i, j]);

                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Cyan;
            PlayerPrint();
            FinishPrint();
        }
        private void FinishPrint()
        {
            Console.SetCursorPosition(Finish.x, Finish.y);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = Constants.ColorOfFinish;
            Console.Write('x');
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void PlayerPrint()
        {
            Console.SetCursorPosition(Player.PosX, Player.PosY);
            Console.ForegroundColor = Constants.ColorOfPlayer;
            Console.Write(Player.Skin);
        }
        public void MoveRendering(int currentDirection)
        {
            Console.SetCursorPosition(Player.PosX, Player.PosY);
            Console.Write(' ');
            Player.Move(currentDirection);
            PlayerPrint();
        }
        public void EndRendering()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine(Art.art);

        }
    }
}

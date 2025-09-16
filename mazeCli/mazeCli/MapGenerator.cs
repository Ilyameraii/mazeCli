using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeCli
{
    internal class MapGenerator
    {
        public char[,] Generating(int width, int height)
        {
            char[,] maze = new char[width, height];
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i, j] = '#';
                }
            }
            int startX = Program.StartX;
            int startY = Program.StartY;
            var stack = new Stack<(int x, int y)>();
            stack.Push((startX, startY));
            maze[startY, startX] = ' ';

            while (stack.Count > 0)
            {
                var current = stack.Peek();
                int x = current.x;
                int y = current.y;
                var validDirections = GetValidDirections(x, y, maze);

                if (validDirections.Count > 0)
                {
                    var direction = validDirections[new Random().Next(validDirections.Count)];
                    int nextX = x + direction.dx;
                    int nextY = y + direction.dy;

                    maze[y + direction.dy/2, x + direction.dx/2] = ' ';
                    maze[nextY, nextX] = ' ';

                    stack.Push((nextX, nextY));
                }
                else
                {
                    stack.Pop();
                }
            }
            // находим точку финала (должна быть в самом возможном конце от игрока)
            int finalX=1;
            int finalY=1;
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i,j]==' ')
                    {
                        if(i+j > finalX + finalY)
                        {
                            finalX = j;
                            finalY = i;
                        }
                    }
                }
            }
            maze[finalY, finalX] = 'o';
            return maze;
        }
        private List<(int dx, int dy)> GetValidDirections(int x, int y, char[,] maze)
        {
            var directions = new List<(int dx, int dy)> { (0, -2), (2, 0), (0, 2), (-2, 0) };
            var validDirections = new List<(int, int)>();

            foreach (var dir in directions)
            {
                int newX = x + dir.dx;
                int newY = y + dir.dy;

                if (newX > 0 && newX < maze.GetLength(1) - 1 &&
                    newY > 0 && newY < maze.GetLength(0) - 1 &&
                    maze[newY, newX] == '#')
                {
                    validDirections.Add(dir);
                }
            }

            return validDirections;
        }
    }
}

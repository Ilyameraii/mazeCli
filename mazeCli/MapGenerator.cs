using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace mazeCli
{
    internal class MapGenerator
    {
        public Point Finish = new Point();
        public char[,] Generating(int width, int height)
        {
            // заполнение игровой карты "стенками"
            char[,] maze = new char[width, height];
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i, j] = '#';
                }
            }
            
            // координаты начала игры (где будет стоять игрок)
            int startX = Constants.StartX;
            int startY = Constants.StartY;

            // стэк понадобится для работы алгоритма
            var stack = new Stack<(int x, int y)>();
            stack.Push((startX, startY));
            maze[startY, startX] = ' ';

            //координаты финиша
            Finish.x = 0;
            Finish.y = 0;

            //максимальное число одновременно запомненных ходов стеком
            int maxCount = 0;

            // алгоритм для создания лабиринта (часть стенок заменяется пустым пространством так, чтобы образовался лабиринт)
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
                    
                    if (maxCount < stack.Count) // алогритм для нахождения самой дальней для игрока точки
                    {
                        maxCount = stack.Count;
                        Finish.x = stack.Peek().x;
                        Finish.y = stack.Peek().y;
                    }

                    stack.Pop();
                }
            }
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

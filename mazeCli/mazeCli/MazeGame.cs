using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeCli
{
    internal class MazeGame
    {
        public void GameProcess()
        {
            Console.CursorVisible = false;
            var mapGenerator = new MapGenerator();
            var player = new Player();
            var maze = mapGenerator.Generating(15, 25);
            var Finish = mapGenerator.Finish;
            var mapRenderer = new MapRenderer(maze,Finish, player);
            mapRenderer.MapRendering();
            while (true)
            {
                var keyInfo = Console.ReadKey(true); // true — не выводить символ в консоль
                int currentDirection = -1;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (player.PosY - 1 >= 0)
                            if (maze[player.PosY - 1, player.PosX] != '#')
                                currentDirection = Constants.UP;
                        break;
                    case ConsoleKey.RightArrow:
                        if (player.PosX + 1 < maze.GetLength(1))
                            if (maze[player.PosY, player.PosX + 1] != '#')
                                currentDirection = Constants.RIGHT;
                        break;
                    case ConsoleKey.DownArrow:
                        if (player.PosY + 1 < maze.GetLength(0))
                            if (maze[player.PosY + 1, player.PosX] != '#')
                                currentDirection = Constants.DOWN;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (player.PosX - 1 >= 0)
                            if (maze[player.PosY, player.PosX - 1] != '#')
                                currentDirection = Constants.LEFT;
                        break;
                }
                mapRenderer.MoveRendering(currentDirection);
                if (mapGenerator.Finish.x == player.PosX && mapGenerator.Finish.y == player.PosY)
                {
                    mapRenderer.EndRendering();
                    break;
                }
            }
        }
    }
}

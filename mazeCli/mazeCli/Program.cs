namespace mazeCli
{
    class Program
    {
        public const int UP = 0;
        public const int RIGHT = 1;
        public const int DOWN = 2;
        public const int LEFT = 3;

        public const int StartX = 1;
        public const int StartY = 1;
        public const char Skin = 'p';
        static void Main(string[] args)
        {
            var mapGenerator = new MapGenerator();
            var player = new Player();
            var maze = mapGenerator.Generating(15, 25);
            maze[StartY, StartX] = player.Skin;
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(player.PosX, player.PosY);
            while (true)
            {
                var keyInfo = Console.ReadKey(true); // true — не выводить символ в консоль
                int currentDirection = -1;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (player.PosY - 1 >= 0)
                            if (maze[player.PosY - 1, player.PosX] != '#')
                                currentDirection = UP;
                        break;
                    case ConsoleKey.RightArrow:
                        if (player.PosX + 1 < maze.GetLength(1))
                            if (maze[player.PosY, player.PosX + 1] != '#')
                                currentDirection = RIGHT;
                        break;
                    case ConsoleKey.DownArrow:
                        if (player.PosY + 1 < maze.GetLength(0))
                            if (maze[player.PosY + 1, player.PosX] != '#')
                                currentDirection = DOWN;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (player.PosX - 1 >= 0)
                            if (maze[player.PosY, player.PosX - 1] != '#')
                                currentDirection = LEFT;
                        break;
                }
                Console.SetCursorPosition(player.PosX, player.PosY);
                Console.Write(' ');
                player.Move(currentDirection);
                Console.SetCursorPosition(player.PosX, player.PosY);
                Console.Write(player.Skin);
                Console.SetCursorPosition(player.PosX, player.PosY);

            }
        }
    }
}
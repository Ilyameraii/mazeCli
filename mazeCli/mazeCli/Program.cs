namespace mazeCli
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MazeGame game = new MazeGame();
            game.GameProcess();
            Console.ReadLine();
        }
    }
}  
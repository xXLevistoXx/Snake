using System.Threading;
namespace Snake
{
    internal class Program
    {
        static void Main()
        {
            bool finish_game = false;
            Borders borders = new Borders();
            Snake snake = new Snake();
            Food food = new Food();
            Console.WriteLine("\t\t\t\tGame Snake\n\t\t\t" +
                              "   Press Enter To Start\n\t\t\t" +
                              "     Use WASD To Move\n\t\t" +
                              "You Can Play This Game Only On Enlish Keyboard");
            Console.Read();
            while (!finish_game)
            {
                try
                {
                    borders.drowBorders();
                    Console.SetCursorPosition(20, 1);
                    Console.Write("Score: {0}", snake.score);
                    snake.Input();
                    food.drawFood();
                    snake.drowSnake();
                    snake.moveSnake();
                    snake.eat(food.foodLocation(), food);
                    snake.isDead();
                    snake.hitWall(borders);
                }
                catch (SnakeException e)
                {
                    
                    Console.WriteLine(e.Message);
                    finish_game = true;
                    Console.SetCursorPosition(borders.Width, borders.Height);

                }
            }
        }
    }
}
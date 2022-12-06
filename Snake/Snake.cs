using System;
using System.Collections.Generic;
namespace Snake
{
    public class Snake
    {
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'w';
        char dir = 'u';

        public List<Position> snakeBody { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int score { get; set; }
        public Snake()
        {
            x = 10;
            y = 10;
            score = 0;

            snakeBody = new List<Position>();
            snakeBody.Add(new Position(x, y));
        }

        public void drowSnake()
        {
            foreach(Position pos in snakeBody)
            {
                Console.SetCursorPosition(pos.x, pos.y);
                Console.Write("+");
            }
            Console.SetCursorPosition(x, y);
            Console.Write("#");
        }
        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

        private void direction()
        {
            if (key == 'w' && dir != 'd')
            {
                dir = 'u';
            } 
            else if (key == 's' && dir != 'u')
            {
                dir = 'd';
            }
            else if(key == 'd' && dir != 'l')
            {
                dir = 'r';
            }
            else if(key == 'a' && dir != 'r')
            {
                dir = 'l';
            }
        }

        public void moveSnake()
        {
            direction();

            if (dir == 'u')
            {
                y--;
            }
            else if (dir == 'd')
            {
                y++;
            }
            else if (dir == 'l')
            {
                x--;
            }
            else if (dir == 'r')
            {
                x++;
            }

            snakeBody.Add(new Position(x, y));
            snakeBody.RemoveAt(0);
            Thread.Sleep(50);
        }

        public void eat(Position food, Food f)
        {
            Position head = snakeBody[snakeBody.Count - 1];
            if(head.x == food.x && head.y == food.y)
            {
                Console.Beep(600, 300);
                snakeBody.Add(new Position(x, y));
                f.foodNewLocation();
                score++;
            }
        }

        public void isDead()
        {
            Position head = snakeBody[snakeBody.Count - 1];
            for(int i = 0; i < snakeBody.Count - 2; i++)
            {
                Position sb = snakeBody[i];
                if (head.x == sb.x && head.y == sb.y)
                {
                    Console.Beep(450, 400);
                    throw new SnakeException("Game Over");
                }
            }
        }

        public void hitWall(Borders borders)
        {
            Position head = snakeBody[snakeBody.Count - 1];

            if (head.x == borders.Width || head.x <= 0 || head.y == borders.Height || head.y <= 0)
            {
                Console.Beep(450, 400);
                throw new SnakeException("Game Over");
            }

        }
    }
}

using System;
namespace Snake
{
    public class Food
    {
        public Position food_Pos = new Position();
        Random random= new Random();
        Borders borders = new Borders();
        public Food()
        {
            food_Pos.x = random.Next(5, borders.Width);
            food_Pos.y = random.Next(5, borders.Height);
        }

        public void drawFood()
        {
            Console.SetCursorPosition(food_Pos.x, food_Pos.y);
            Console.Write(".");
        }

        public Position foodLocation()
        {
            return food_Pos;
        }

        public void foodNewLocation()
        {
            food_Pos.x = random.Next(5, borders.Width);
            food_Pos.y = random.Next(5, borders.Height);
        }
    }
}

using System;

namespace patterns
{
    public class Rectangle
    {

        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle()
        {

        }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)} : {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        public new int Width
        {
            set
            {
                base.Width = base.Height = value;
            }
        }

        public new int Height
        {
            set
            {
                base.Height = base.Width = value;
            }
        }

    }

    class Program
    {
        static public int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc} has area {Area(rc)}"); // result 6

            Square sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}"); // result 16

            Rectangle sq2 = new Square();
            sq2.Width = 4;
            Console.WriteLine($"{sq2} has area {Area(sq2)}"); // result 0

        }
    }
}

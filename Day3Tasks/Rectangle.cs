namespace Day3Tasks
{
    public class Rectangle
    {        
        public int TopLeftX { get; }
        public int TopLeftY { get; }
        public int Width { get; }
        public int Height { get; }

        public Rectangle(int topLeftX, int topLeftY, int width, int height)
        {
            TopLeftX = topLeftX;
            TopLeftY = topLeftY;
            Width = width;
            Height = height;
        }
    }
}

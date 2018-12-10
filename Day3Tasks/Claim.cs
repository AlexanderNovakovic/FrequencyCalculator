namespace Day3Tasks
{
    public class Claim
    {
        public int Id { get; }
        public Rectangle Rectangle { get; }

        public Claim(int id, Rectangle rectangle)
        {
            Id = id;
            Rectangle = rectangle;
        }
    }
}

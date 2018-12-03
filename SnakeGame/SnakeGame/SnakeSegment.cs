namespace SnakeGame
{
    class SnakeSegment
    {
        public SnakeDirection Direction;

        public SnakeSegment(SnakeDirection direction)
        {
            Direction = direction;
        }

        public SnakeSegment() { }
    }

    class SnakeHeadSegment : SnakeSegment
    {
        public SnakeHeadSegment(SnakeDirection direction)
        {
            Direction = direction;
        }
    }

}

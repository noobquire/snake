namespace SnakeGame
{
    public enum SnakeDirection : byte
    {
        Up, Down, Left, Right, Default
    }

    public static class SnakeDirectionExtension
    {
        public static SnakeDirection Reverse(this SnakeDirection direction)
        {
            switch (direction)
            {
                case SnakeDirection.Up:
                    return SnakeDirection.Down;
                case SnakeDirection.Down:
                    return SnakeDirection.Up;
                case SnakeDirection.Left:
                    return SnakeDirection.Right;
                case SnakeDirection.Right:
                    return SnakeDirection.Left;
                default:
                    return SnakeDirection.Default;
            }
        }
    }
}

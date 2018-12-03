using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame
{
    public class Level
    {
        #region Settings



        #endregion

        public bool Playing;
        public SnakeDirection Direction = SnakeDirection.Up;
        private readonly object[,] _grid;
        private readonly int _scorePerFood;
        public int Score;
        private Queue<Point> _snake = new Queue<Point>();
        public Level(object[,] walls, int scorePerFood)
        {
            _scorePerFood = scorePerFood;
            _grid = new object[walls.GetLength(0), walls.GetLength(1)];
            for (int i = 0; i < walls.GetLength(0); i++)
            {
                for (int j = 0; j < walls.GetLength(1); j++)
                {
                    _grid[i, j] = walls[i, j];
                }
            }

            int snakeOriginX = walls.GetLength(0) / 2;
            int snakeOriginY = walls.GetLength(1) / 2;
            _grid[snakeOriginX, snakeOriginY] = new SnakeHeadSegment(SnakeDirection.Up);
            _snake.Enqueue(new Point(snakeOriginX, snakeOriginY));
            AddFood(snakeOriginX - 2, snakeOriginY);
            Playing = true;
        }

        public void Update(SnakeDirection newDirection = SnakeDirection.Default)
        {
            if ((newDirection != Direction && newDirection != Direction.Reverse() && newDirection != SnakeDirection.Default) || Score == 0 && newDirection != SnakeDirection.Default)
            {
                Direction = newDirection;
            }

            Point head = _snake.Last();
            Point tail = _snake.Peek();
            int newX = 0, newY = 0;
            switch (Direction)
            {
                case SnakeDirection.Up:
                    newX = head.X - 1;
                    newY = head.Y;
                    break;
                case SnakeDirection.Down:
                    newX = head.X + 1;
                    newY = head.Y;
                    break;
                case SnakeDirection.Left:
                    newX = head.X;
                    newY = head.Y - 1;
                    break;
                case SnakeDirection.Right:
                    newX = head.X;
                    newY = head.Y + 1;
                    break;
            }
            try
            {
                if (_grid[newX, newY] == null)
                {
                    _grid[tail.X, tail.Y] = null;
                    _grid[newX, newY] = new SnakeSegment();
                    _snake.Enqueue(new Point(newX, newY));
                    _snake.Dequeue();
                }
                else if (_grid[newX, newY] is Food)
                {

                    _grid[newX, newY] = new SnakeSegment();
                    _snake.Enqueue(new Point(newX, newY));
                    AddFood();
                    Score += _scorePerFood;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    GameOver();
                }

            }
            catch (IndexOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                GameOver();

            }

        }


        public void Draw()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("▒▒");
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                sb.Append("▒▒");
            }
            sb.Append("▒▒");
            sb.Append('\n');
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                sb.Append("▒▒");

                for (int j = 0; j < _grid.GetLength(1); j++)
                {

                    if (_grid[i, j] is SnakeHeadSegment)
                    {
                        sb.Append("██");
                    }
                    else if (_grid[i, j] is SnakeSegment)
                    {
                        sb.Append("██");
                    }
                    else if (_grid[i, j] is WallSegment)
                    {
                        sb.Append("▒▒");
                    }
                    else if (_grid[i, j] is Food)
                    {
                        sb.Append("<>");
                    }
                    else
                    {
                        sb.Append("  ");
                    }

                }
                sb.Append("▒▒");
                sb.Append('\n');
            }
            sb.Append("▒▒");
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                sb.Append("▒▒");
            }
            sb.Append("▒▒");
            sb.Append($"\nScore: {Score}");
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write(sb);
        }

        public void AddFood()
        {

            Random rand = new Random();
            int foodX, foodY;
            while (true)
            {
                foodX = rand.Next(0, _grid.GetLength(0));
                foodY = rand.Next(0, _grid.GetLength(1));
                if (_grid[foodX, foodY] == null)
                {
                    _grid[foodX, foodY] = new Food();
                    break;
                }
            }


        }

        public void AddFood(int x, int y)
        {
            if (_grid[x, y] == null)
            {
                _grid[x, y] = new Food();
            }
            else
            {
                throw new ArgumentException("Cell is already filled");
            }
        }

        public void GameOver()
        {
            Playing = false;
        }

    }


}



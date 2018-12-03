using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public static class LevelGenerator
    {
        public static void Level1(ref object[,] walls)
        {
            for (int i = 0; i < walls.GetLength(0); i++)
            {
                for (int j = 0; j < walls.GetLength(1); j++)
                {
                    walls[i, j] = null;
                }
            }
        } // Box

        public static void Level2(ref object[,] walls)
        {
            for (int x = 4; x <= 20; x++)
            {
                walls[x, 8] = WallSegment.Wall;
            }

            for (int x = 4; x <= 20; x++)
            {
                walls[x, 16] = WallSegment.Wall;
            }
        } // Pillars

        public static void Level3(ref object[,] walls)
        {
            for (int i = 1; i <= walls.GetLength(0); i++)
            {
                for (int j = 1; j <= walls.GetLength(1); j++)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        walls[i - 1, j - 1] = WallSegment.Wall;
                    }
                }
            }
        } // Chessboard

        public static void Level4(ref object[,] walls)
        {
            for (int x = 5; x <= 19; x++)
            {
                walls[x, 5] = WallSegment.Wall;
            }
            for (int x = 5; x <= 17; x++)
            {
                walls[x, 7] = WallSegment.Wall;
            }
            for (int y = 8; y <= 10; y++)
            {
                walls[17, y] = WallSegment.Wall;
            }
            for (int y = 6; y <= 10; y++)
            {
                walls[19, y] = WallSegment.Wall;
            }

            for (int x = 5; x <= 19; x++)
            {
                walls[x, 19] = WallSegment.Wall;
            }
            for (int x = 7; x <= 19; x++)
            {
                walls[x, 17] = WallSegment.Wall;
            }
            for (int y = 14; y <= 18; y++)
            {
                walls[5, y] = WallSegment.Wall;
            }
            for (int y = 14; y <= 16; y++)
            {
                walls[7, y] = WallSegment.Wall;
            }

            walls[11, 11] = WallSegment.Wall;
            walls[11, 13] = WallSegment.Wall;
            walls[13, 11] = WallSegment.Wall;
            
walls[13, 13] = WallSegment.Wall;
        } // Pipes

        public static void Level5(ref object[,] walls)
        {
            for (int x = 2; x <= 22; x++)
            {
                walls[x, 2] = WallSegment.Wall;
            }
            for (int x = 7; x <= 17; x++)
            {
                walls[x, 7] = WallSegment.Wall;
            }
            for (int x = 7; x <= 17; x++)
            {
                walls[x, 17] = WallSegment.Wall;
            }
            for (int x = 2; x <= 22; x++)
            {
                walls[x, 22] = WallSegment.Wall;
            }

            for (int y = 5; y <= 19; y++)
            {
                walls[4, y] = WallSegment.Wall;
            }
            for (int y = 5; y <= 19; y++)
            {
                walls[20, y] = WallSegment.Wall;
            }
            for (int y = 10; y <= 14; y++)
            {
                walls[9, y] = WallSegment.Wall;
            }
            for (int y = 10; y <= 14; y++)
            {
                walls[15, y] = WallSegment.Wall;
            }

            walls[12, 11] = WallSegment.Wall;
            walls[12, 13] = WallSegment.Wall;
        } // Recursion
    }
}

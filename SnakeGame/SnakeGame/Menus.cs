using System;
using System.Threading;

namespace SnakeGame
{
    public static class Menus
    {
        public static void MainMenu()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine("███████████████████████████████████████████\r\n██                                       ██\r\n██  ██████ ██   ██  ████  ██  ██ ██████  ██\r\n██  ██     ███  ██ ██  ██ ██ ██  ██      ██\r\n██  ██████ ██ █ ██ ██  ██ ████   ████    ██\r\n██      ██ ██  ███ ██████ ██ ██  ██      ██\r\n██  ██████ ██   ██ ██  ██ ██  ██ ██████  ██\r\n██                                       ██\r\n███████████████████████████████████████████\r\n╔═════════════════════════════════════════╗\r\n║        1) Choose level to play          ║\r\n╚═════════════════════════════════════════╝\r\n╔═════════════════════════════════════════╗\r\n║            2) Play campaign             ║\r\n╚═════════════════════════════════════════╝\r\n╔═════════════════════════════════════════╗\r\n║          3) Play random level           ║\r\n╚═════════════════════════════════════════╝\r\n╔═════════════════════════════════════════╗\r\n║                0) Exit                  ║\r\n╚═════════════════════════════════════════╝\r\n        USE NUMBER KEYS TO CHOOSE          ");
                bool choosing = true;
            while (choosing)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                choosing = false;
                switch (key.KeyChar)
                {
                    case '0':
                        Environment.Exit(0);
                        break;
                    case '1':
                        ChooseLevel(ChooseDifficulty());
                        break;
                    case '2':
                        LevelLoader.StartCampaign(ChooseDifficulty());
                        break;
                    case '3':
                        LevelLoader.StartRandom(ChooseDifficulty());
                        break;
                    default:
                        choosing = true;
                        break;
                }
            }
        }



        public static SnakeDifficulty ChooseDifficulty()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine(
                "╔══════════════════════════════╗\r\n║                              ║\r\n║  Сhoose difficulty to play:  ║\r\n║                              ║\r\n╚══════════════════════════════╝\r\n╔══════════════════════════════╗\r\n║            1) Easy           ║\r\n╚══════════════════════════════╝\r\n╔══════════════════════════════╗\r\n║          2) Medium           ║\r\n╚══════════════════════════════╝\r\n╔══════════════════════════════╗\r\n║           3) Hard            ║\r\n╚══════════════════════════════╝\r\n╔══════════════════════════════╗\r\n║         0) Go back           ║\r\n╚══════════════════════════════╝\r\n   USE NUMBER KEYS TO CHOOSE   ");
            bool choosing = true;
            while (choosing)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                choosing = false;
                switch (key.KeyChar)
                {
                    case '0':
                        MainMenu();
                        break;
                    case '1':
                        return SnakeDifficulty.Easy;
                    case '2':
                        return SnakeDifficulty.Medium;
                    case '3':
                        return SnakeDifficulty.Hard;
                    default:
                        choosing = true;
                        break;
                }
            }

            return SnakeDifficulty.Easy;
        }

        public static void ChooseLevel(SnakeDifficulty difficulty)
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine(
                "╔══════════════════════════════╗\r\n║                              ║\r\n║     Сhoose level to play:    ║\r\n║                              ║\r\n╚══════════════════════════════╝\r\n╔══════════════════════════════╗\r\n║            1) Box            ║\r\n╚══════════════════════════════╝\r\n╔══════════════════════════════╗\r\n║          2) Pillars          ║\r\n╚══════════════════════════════╝\r\n╔══════════════════════════════╗\r\n║        3) Chessboard         ║\r\n╚══════════════════════════════╝\r\n╔══════════════════════════════╗\r\n║           4) Pipes           ║\r\n╚══════════════════════════════╝\r\n╔══════════════════════════════╗\r\n║         5) Recursion         ║\r\n╚══════════════════════════════╝\r\n╔══════════════════════════════╗\r\n║          0) Go back          ║\r\n╚══════════════════════════════╝\r\n   USE NUMBER KEYS TO CHOOSE    ");
            bool choosing = true;
            object[,] walls = new object[25, 25];
            int level = 0;
            while (choosing)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                choosing = false;

                switch (key.KeyChar)
                {
                    case '0':
                        MainMenu();
                        break;
                    case '1':
                        level = 0;
                        LevelGenerator.Level1(ref walls);
                        break;
                    case '2':
                        level = 1;
                        LevelGenerator.Level2(ref walls);
                        break;
                    case '3':
                        level = 2;
                        LevelGenerator.Level3(ref walls);
                        break;
                    case '4':
                        level = 3;
                        LevelGenerator.Level4(ref walls);
                        break;
                    case '5':
                        level = 4;
                        LevelGenerator.Level5(ref walls);
                        break;
                    default:
                        choosing = true;
                        break;
                }
            }

            LevelLoader.StartLevel(difficulty, walls, level);
        }

        public static void LevelCompleted(int score)
        {
            Console.Clear();
            Console.WriteLine(
                "            ██     ██████ ██  ██ ██████ ██\r\n            ██     ██     ██  ██ ██     ██\r\n            ██     ████   ██  ██ ████   ██\r\n            ██     ██     ██  ██ ██     ██\r\n            ██████ ██████  ████  ██████ ██████\r\n\r\n██████ ██████ ██      ██ ██████ ██     ██████ ██████ ██████\r\n██     ██  ██ ████  ████ ██  ██ ██     ██       ██   ██\r\n██     ██  ██ ██  ██  ██ ██████ ██     ████     ██   ████\r\n██     ██  ██ ██      ██ ██     ██     ██       ██   ██\r\n██████ ██████ ██      ██ ██     ██████ ██████   ██   ██████\r\n                                                           ");

            string spaces = "";
            for (int i = 0; i < (47 * score.ToString().Length) / 4; i++)
            {
                spaces += ' ';
            }

            Console.Write(spaces);
            Console.Write($"YOUR SCORE: {score}");
            Console.Write(spaces);
            Console.WriteLine("\n                 PRESS ANY KEY TO CONTINUE                 ");
            Console.ReadKey();
        }


        public static void GameOverScreen(int score, int best)
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine(
                "  _______  _______  __   __  _______  \r\n|       ||   _   ||  |_|  ||       | \r\n|    ___||  |_|  ||       ||    ___| \r\n|   | __ |       ||       ||   |___  \r\n|   ||  ||       ||       ||    ___| \r\n|   |_| ||   _   || ||_|| ||   |___  \r\n|_______||__| |__||_|   |_||_______| \r\n _______  __   __  _______  ______   \r\n|       ||  | |  ||       ||    _ |  \r\n|   _   ||  |_|  ||    ___||   | ||  \r\n|  | |  ||       ||   |___ |   |_||_ \r\n|  |_|  ||       ||    ___||    __  |\r\n|       | |     | |   |___ |   |  | |\r\n|_______|  |___|  |_______||___|  |_|");
            int whiteSpaces1 = (25 - score.ToString().Length) / 2;
            string spaces1 = "";
            for (int i = 0; i < whiteSpaces1; i++)
            {
                spaces1 += " ";
            }

            Console.WriteLine();
            Console.Write(spaces1);
            Console.Write($"YOUR SCORE: {score} ");
            Console.Write(spaces1);

            Console.WriteLine($"\n                BEST: {best}");
            Console.WriteLine("PRESS ANY KEY TO EXIT TO MAIN MENU");
            Console.ReadKey();
            MainMenu();
        }
    }
}

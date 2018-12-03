using System;

namespace SnakeGame
{
    public static class LevelLoader
    {
        private static int _campaignScore;
        private static bool _playingCampaign;
        public static void StartCampaign(SnakeDifficulty difficulty)
        {
            _campaignScore = 0;
            object[,] walls = new object[25, 25];
            _playingCampaign = true;
            int maxScore = 0;
            while (_playingCampaign)
            {
                maxScore += 10;
                LevelGenerator.Level1(ref walls);
                StartLevel(difficulty, walls, 0, maxScore);
                if (!_playingCampaign) return;
                maxScore += 10;
                LevelGenerator.Level1(ref walls);
                LevelGenerator.Level2(ref walls);
                StartLevel(difficulty, walls, 1, maxScore);
                if (!_playingCampaign) return;
                maxScore += 10;
                LevelGenerator.Level1(ref walls);
                LevelGenerator.Level3(ref walls);
                StartLevel(difficulty, walls, 2, maxScore);
                if (!_playingCampaign) return;
                maxScore += 10;
                LevelGenerator.Level1(ref walls);
                LevelGenerator.Level4(ref walls);
                StartLevel(difficulty, walls, 3, maxScore);
                if (!_playingCampaign) return;
                maxScore += 10;
                LevelGenerator.Level1(ref walls);
                LevelGenerator.Level5(ref walls);
                StartLevel(difficulty, walls, 4, maxScore);
                if (!_playingCampaign) return;
            }
            Menus.GameOverScreen(_campaignScore, LeaderboardManager.GetBestCampaignScore());


        }
        public static void StartRandom(SnakeDifficulty difficulty)
        {
            Random random = new Random();
            object[,] walls = new object[25, 25];
            int level = random.Next(1, 6);
            switch (level)
            {
                case 1:
                    LevelGenerator.Level1(ref walls);
                    break;
                case 2:
                    LevelGenerator.Level2(ref walls);
                    break;
                case 3:
                    LevelGenerator.Level3(ref walls);

                    break;
                case 4:
                    LevelGenerator.Level4(ref walls);

                    break;
                case 5:
                    LevelGenerator.Level5(ref walls);
                    break;
            }
            StartLevel(difficulty, walls, levelId: level - 1);
        }

        public static void StartLevel(SnakeDifficulty difficulty, object[,] walls, int levelId, int maxScore = 0)
        {
            int speed;
            int scorePerFood;
            switch (difficulty)
            {
                case SnakeDifficulty.Easy:
                    speed = 300;
                    scorePerFood = 1;
                    break;
                case SnakeDifficulty.Medium:
                    speed = 200;
                    scorePerFood = 2;
                    break;
                case SnakeDifficulty.Hard:
                    speed = 100;
                    scorePerFood = 3;
                    break;
                default:
                    speed = 400;
                    scorePerFood = 0;
                    break;
            }
            Level level = new Level(walls, scorePerFood);
            SnakeDirection newDirection = SnakeDirection.Default;
            bool showGameOver = true;
            System.Timers.Timer timer = new System.Timers.Timer()
            {
                Interval = speed,
                AutoReset = true,
            };

            timer.Elapsed += (sender, e) =>
            {
                if (level.Score >= maxScore && maxScore != 0)
                {
                    level.Playing = false;
                    timer.Enabled = false;
                    _campaignScore += level.Score;
                    showGameOver = false;
                    Menus.LevelCompleted(_campaignScore);
                    
                }
                else if (level.Playing)
                {
                    // ReSharper disable once AccessToModifiedClosure
                    level.Update(newDirection);
                    // ReSharper disable once AccessToModifiedClosure
                    // ReSharper disable once RedundantCheckBeforeAssignment
                    if (newDirection != SnakeDirection.Default)
                    {
                        newDirection = SnakeDirection.Default;
                    }

                    level.Draw();
                }
                else
                {
                    timer.Enabled = false;


                    if (_playingCampaign)
                    {
                        _campaignScore += level.Score;

                        if (_campaignScore > LeaderboardManager.GetBestCampaignScore())
                        {
                            LeaderboardManager.SetBestCampaignScore(_campaignScore);
                        }
                        showGameOver = false;
                        _playingCampaign = false;
                        
                        
                        
                    }

                }
            };
            Console.Clear();
            level.Draw();
            bool waitingToStart = true;
            while (waitingToStart)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                waitingToStart = false;
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        newDirection = SnakeDirection.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        newDirection = SnakeDirection.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        newDirection = SnakeDirection.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        newDirection = SnakeDirection.Right;
                        break;
                    default:
                        waitingToStart = true;
                        break;
                }
            }
            timer.Enabled = true;

            while (level.Playing)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        newDirection = SnakeDirection.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        newDirection = SnakeDirection.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        newDirection = SnakeDirection.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        newDirection = SnakeDirection.Right;
                        break;
                }
            }
            

            if (showGameOver)
            {
                if (LeaderboardManager.GetBestScoreByLevel(levelId) < level.Score)
                {
                    LeaderboardManager.SetBestScoreByLevel(levelId, level.Score);
                }
                Menus.GameOverScreen(level.Score, LeaderboardManager.GetBestScoreByLevel(levelId));
            }
            
        }


    }

}


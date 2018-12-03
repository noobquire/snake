using System.Dynamic;
using System.IO;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace SnakeGame
{
    public static class LeaderboardManager
    {
        public static int NormalBest
        {
            get
            {
                string path = @"D:\leaderboard.txt";
                if (File.Exists(path))
                {
                    string text = File.ReadAllText(path);
                    dynamic info = JsonConvert.DeserializeObject(text);
                    return info.normalBest;
                }

                return 0;

            }
            set
            {
                string path = @"D:\leaderboard.txt";

                    dynamic info = new ExpandoObject();
                    info.normalBest = value;
                    var newData = JsonConvert.SerializeObject(info);
                    File.WriteAllText(path, newData);
            }
        }

        public static int GetBestScoreByLevel(int levelId)
        {
            string path = @"D:\leaderboard.txt";
            try
            {
                if (File.Exists(path))
                {
                    string text = File.ReadAllText(path);
                    dynamic info = JsonConvert.DeserializeObject(text);
                    switch (levelId)
                    {
                        case 0:
                            return info.Level1Best;
                        case 1:
                            return info.Level2Best;
                        case 2:
                            return info.Level3Best;
                        case 3:
                            return info.Level4Best;
                        case 4:
                            return info.Level5Best;
                        default:
                            return 0;

                    }
                }
            }
            catch (RuntimeBinderException)
            {
                return 0;
            }
            

            return 0;
        }

        public static int GetBestCampaignScore()
        {
            string path = @"D:\leaderboard.txt";
            try
            {
                if (File.Exists(path))
                {
                    string text = File.ReadAllText(path);
                    dynamic info = JsonConvert.DeserializeObject(text);
                    return info.campaignBest;
                }
            }
            catch (RuntimeBinderException)
            {
                return 0;
            }
            

            return 0;
        }

        public static void SetBestCampaignScore(int newBest)
        {

            string path = @"D:\leaderboard.txt";

            dynamic info = new ExpandoObject();
            info.campaignBest = newBest;
            var newData = JsonConvert.SerializeObject(info);
            File.WriteAllText(path, newData);
        }

        public static void SetBestScoreByLevel(int level, int newBest)
        {
            string path = @"D:\leaderboard.txt";

            dynamic info = JsonConvert.DeserializeObject(File.ReadAllText(path));
            switch (level)
            {
                case 0:
                    info.Level1Best = newBest;
                    break;
                case 1:
                    info.Level2Best = newBest;
                    break;
                case 2:
                    info.Level3Best = newBest;
                    break;
                case 3:
                    info.Level4Best = newBest;
                    break;
                case 4:
                    info.Level5Best = newBest;
                    break;

            }
            var newData = JsonConvert.SerializeObject(info);
            File.WriteAllText(path, newData);
        }

    }
}

/* Program Code: PROG2370 Game Programming
 * 
 * Project name: HKoFinalProject
 * 
 * Purpose: To create a game using Monogame
 * 
 * Written By: Heuijin Ko
 * 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HKoFinalProject
{
    /// <summary>
    /// A class of Shared
    /// </summary>
    public class Shared
    {
        public static Vector2 stage;

        public static int TOTAL_LEVEL = 3;
        public static int TOTAL_PLAY = 3;
        public static int currentLevel = 1;
        public static int isPlaySameLevel = 1;
        public static bool isNextLevel;
        public static int MAX_SPEED;
        public static int ENEMY;
        public static int ENERGY;
        public static bool isPause = false;
        public static bool isHighScore = false;
        private const string FILENAME = "scores.txt";


        private static int highScore = 0;

        /// <summary>
        /// Set game level
        /// </summary>
        public static void GameLevelInitialize()
        {
            MAX_SPEED = currentLevel;

            if (currentLevel == 1)
            {
                ENEMY = 20;
                ENERGY = 10;
            }
            else if (currentLevel == 2)
            {
                ENEMY = 25;
                ENERGY = 15;
            }
            else if (currentLevel == 3)
            {
                ENEMY = 30;
                ENERGY = 20;
            }
        }

        public static void SetHighScore(int curScore)
        {
            if (curScore > highScore)
                highScore = curScore;
        }

        public static int GetHighScore()
        {
            return highScore;
        }

        public static void RecordScores()
        {
            StreamWriter writer;
            FileInfo file = new FileInfo(FILENAME);

            if (!file.Exists)
            {
                File.Create(FILENAME);
            }

            try
            {
                writer = new StreamWriter(FILENAME);
                writer.WriteLine(highScore.ToString());
            }
            catch (Exception)
            {
                return;
            }

            if (writer != null)
                writer.Close();
        }
    }
}

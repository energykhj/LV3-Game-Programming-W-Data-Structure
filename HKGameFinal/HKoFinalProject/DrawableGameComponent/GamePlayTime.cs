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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HKoFinalProject
{
    /// <summary>
    /// A class of GamePlayTime
    /// </summary>
    public class GamePlayTime : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private string currentTime;
        private Vector2 position;
        bool isTimerOn = false;
        float timeCounter; // 30 seconds

        public float TimeCounter { get => timeCounter; set => timeCounter = value; }
        public string CurrentTime { get => currentTime; set => currentTime = value; }

        /// <summary>
        /// Constructor of the GamePlayTime
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="spriteBatch">spriteBatch</param>
        /// <param name="font">timer font</param>
        /// <param name="timeCounter">timeCounter</param>
        /// <param name="position">position</param>
        public GamePlayTime(Game game,
            SpriteBatch spriteBatch,
            SpriteFont font,
            float timeCounter,
            Vector2 position) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.timeCounter = timeCounter;
            this.position = position;
            this.isTimerOn = true;
        }
        /// <summary>
        /// An override Draw method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, currentTime, position, Color.Red);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// An override Update method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Update(GameTime gameTime)
        {
            float tempTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (isTimerOn)
            {
                if (timeCounter > 0)
                {
                    timeCounter -= tempTime;
                }
                else if (timeCounter < 0)
                {
                    timeCounter = 0;
                    isTimerOn = false;
                }

                currentTime = $"Time remain: " +
                    $"{string.Format("{0:f1}", timeCounter)}";
            }
            base.Update(gameTime);
        }
    }
}

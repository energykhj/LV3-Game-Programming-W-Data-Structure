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
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace HKoFinalProject
{
    /// <summary>
    /// A class of Crash
    /// </summary>
    public class Crash : DrawableGameComponent
    {
        private const int FRAME_COUNT = 5;

        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;

        private List<Rectangle> frames;
        private int frameSize;
        private int frameIndex = -1;

        public Vector2 Position { get => position; set => position = value; }
        /// <summary>
        /// Constructor of Crash
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="spriteBatch">spriteBatch</param>
        /// <param name="tex">tex</param>
        /// <param name="position">tex</param>
        public Crash(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 positio) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.Position = position;

            // get each frame's size
            frameSize = tex.Width / FRAME_COUNT; 

            this.stopShowFrames();

            //make animation
            makeSingleImg2Frames();
        }
        /// <summary>
        ///  An override Draw method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Draw(GameTime gameTime)
        {
            if (frameIndex >= 0)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(tex, Position, 
                    frames[frameIndex], Color.White);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
        /// <summary>
        ///  An override Update method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Update(GameTime gameTime)
        {
            frameIndex++;
            if (frameIndex > FRAME_COUNT * FRAME_COUNT - 1)
            {
                frameIndex = -1;
                stopShowFrames();
            }

            base.Update(gameTime);
        }
        /// <summary>
        /// Show frame method
        /// </summary>
        public void startShowFrames()
        {
            this.Enabled = true;
            this.Visible = true;
        }
        /// <summary>
        /// Stop frame method
        /// </summary>
        public void stopShowFrames()
        {
            this.Enabled = false;
            this.Visible = false;
        }
        /// <summary>
        /// A single image is divided of several frames 
        /// </summary>
        private void makeSingleImg2Frames()
        {
            frames = new List<Rectangle>();
            for (int i = 0; i < FRAME_COUNT; i++)
            {
                for (int j = 0; j < FRAME_COUNT; j++)
                {
                    int xPos = j * (int)frameSize;
                    int yPos = i * (int)frameSize;
                    Rectangle r = new Rectangle(xPos, yPos, (int)frameSize, (int)frameSize);

                    frames.Add(r);
                }
            }
        }
    }
}

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
    /// A class of the GameMessage
    /// </summary>
    public class GameMessage : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Color color;
        private string message;
        private Vector2 position;
        public Vector2 Position { get => position; set => position = value; }
        public string Message { get => message; set => message = value; }
        /// <summary>
        /// Constructor of the GameMessage
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="spriteBatch">spriteBatch</param>
        /// <param name="font">font</param>
        /// <param name="color">color</param>
        public GameMessage(Game game,
            SpriteBatch spriteBatch,
            SpriteFont font,
            Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.color = color;           
        }
        /// <summary>
        ///  An override Draw method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, message, position, color);
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}

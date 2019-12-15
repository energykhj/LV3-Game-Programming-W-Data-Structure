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
    /// A class of the GameSceneBackground
    /// </summary>
    public class GameSceneBackground : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        /// <summary>
        /// Constructor of the GameSceneBackground
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="spriteBatch">spriteBatch</param>
        /// <param name="tex">tex</param>
        public GameSceneBackground(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            position = new Vector2((Shared.stage.X - tex.Width) / 2, 
                    (Shared.stage.Y - tex.Height) / 2);
           // position = new Vector2(512, 470);
        }
        /// <summary>
        ///  An override Draw method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}

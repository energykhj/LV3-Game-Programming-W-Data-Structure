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
    /// A class of BackgroundScene
    /// </summary>
    public class BackgroundScene : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        public float Rotation { get; set; } = 0f;
        private float rotationSpeed = 0.005f;
        private Rectangle srcRect;
        private Vector2 origin;
        public float Scale { get; set; } = 1;
        /// <summary>
        /// Constructor of BackgroundScene
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="spriteBatch">spriteBatch</param>
        /// <param name="tex">tex</param>
        /// <param name="position">position</param>
        public BackgroundScene(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;

            this.position = new Vector2(Shared.stage.X / 2, Shared.stage.Y / 2);

            srcRect = new Rectangle(0, 0, tex.Width, tex.Height);
            origin = new Vector2(tex.Width / 2, tex.Height / 2);
        }
        /// <summary>
        ///  An override Draw method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, srcRect, 
                Color.White, Rotation, origin, Scale,
                SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        /// <summary>
        ///  An override Update method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Update(GameTime gameTime)
        {
            Rotation += rotationSpeed;
            base.Update(gameTime);
        }
    }
}

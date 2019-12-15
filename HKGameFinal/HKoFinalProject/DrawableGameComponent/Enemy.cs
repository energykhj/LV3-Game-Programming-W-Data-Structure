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
    /// A class of Enemy object
    /// </summary>
    public class Enemy : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public Vector2 position;
        public Vector2 speed;

        private Rectangle srcRect;

        public Enemy(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;

            srcRect = new Rectangle(0, 0, tex.Width, tex.Height);
            //origin = new Vector2(tex.Width / 2, tex.Height / 2);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, srcRect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            this.position += this.speed;
            // handle top wall
            if (position.Y < 0)
            {
                speed.Y = Math.Abs(speed.Y);
            }
            //right wall
            if (position.X + tex.Width > Shared.stage.X)
            {
                speed.X = -Math.Abs(speed.X);
            }

            //left wall
            if (position.X < 0)
            {
                speed.X = Math.Abs(speed.X);
            }

            //bottom wall
            if (position.Y > Shared.stage.Y)
            {
                speed.Y = -Math.Abs(speed.Y);

            }
            base.Update(gameTime);
        }

        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, 
                (int)position.Y, tex.Width, tex.Height);

        }
    }
}

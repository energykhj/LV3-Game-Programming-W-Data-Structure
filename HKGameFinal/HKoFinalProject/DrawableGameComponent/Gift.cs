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
    public class Gift : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;

        private float rotationSpeed = 0.1f;

        public float Rotation { get; set; } = 0f;
        private Rectangle srcRect;
        private Vector2 origin;

        public float Scale { get; set; } = 1;
        /// <summary>
        /// Constructor of the Gift object
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="spriteBatch">spriteBatch</param>
        /// <param name="tex">Gift texture</param>
        /// <param name="position">position</param>
        /// <param name="speed">speed</param>
        /// <param name="stage">stage</param>
        public Gift(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed,
            Vector2 stage) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;

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
            // without rotation
            spriteBatch.Draw(tex, position, srcRect, Color.White, Rotation, 
                origin, Scale, SpriteEffects.None, 0);
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
        /// <summary>
        /// Boundary of the gift
        /// </summary>
        /// <returns></returns>
        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, 
                tex.Width, tex.Height);

        }
    }
}

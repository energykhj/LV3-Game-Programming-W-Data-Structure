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
    /// A class of Ship object
    /// </summary>
    public class Ship : DrawableGameComponent
    {
        private const int SHIP_SPEED = 5;
        private SpriteBatch spriteBatch;
        private Rectangle rectangle;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speedX;
        private Vector2 speedY;
        private int energy_score;
        private bool crash;
        private bool takeEnergy;

        public bool Crash { get => crash; set => crash = value; }
        public bool TakeEnergy { get => takeEnergy; set => takeEnergy = value; }
        public Rectangle Rectangle { get => rectangle; set => rectangle = value; }
        public int Energy_score { get => energy_score; set => energy_score = value; }

        /// <summary>
        /// Constructor of the Ship
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="spriteBatch">game</param>
        /// <param name="tex">Ship texture</param>
        /// <param name="energy">energy rate</param>
        /// <param name="crash">bool crash</param>
        /// <param name="takeEnergy">bool get energy</param>
        public Ship(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            int energy_score,
            bool crash,
            bool takeEnergy) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.energy_score = energy_score;
            this.crash = crash;
            this.takeEnergy = takeEnergy;
            position = new Vector2((Shared.stage.X - tex.Width) / 2, 
                (Shared.stage.Y - tex.Height) / 2);
            speedX = new Vector2(SHIP_SPEED, 0);
            speedY = new Vector2(0, SHIP_SPEED);
        }
        /// <summary>
        /// An override draw method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Draw(GameTime gameTime)
        {
            if (true)//health > 10)
            {
                spriteBatch.Draw(tex, position, Color.White);
            }
            base.Draw(gameTime);
        }
        /// <summary>
        /// An override Update method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right))
            {
                position += speedX;
                if (position.X + tex.Width > Shared.stage.X)
                {
                    position.X = Shared.stage.X - tex.Width;
                }
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                position -= speedX;
                if (position.X < 0)
                {
                    position.X = 0;
                }
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                position += speedY;
                if (position.Y + tex.Height > Shared.stage.Y)
                {
                    position.Y = Shared.stage.Y - tex.Height;
                }
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                position -= speedY;
                if (position.Y < 0)
                {
                    position.Y = 0;
                }
            }

            base.Update(gameTime);
        }
        /// <summary>
        /// Boundary for the ship
        /// </summary>
        /// <returns></returns>
        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, 
                tex.Width, tex.Height);

        }
    }
}

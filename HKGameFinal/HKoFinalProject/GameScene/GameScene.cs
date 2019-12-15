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
    ///  An abstract class of GameScene
    /// </summary>
    public abstract class GameScene : DrawableGameComponent
    {
        private List<GameComponent> components;

        public List<GameComponent> Components { get => components; set => components = value; }

        /// <summary>
        /// A virtual method that shows the game component
        /// </summary>
        public virtual void show()
        {
            this.Visible = true;
            this.Enabled = true;
        }
        /// <summary>
        ///  A virtual method that hide the game component
        /// </summary>
        public virtual void hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        /// <summary>
        /// Constructor of GameScene
        /// </summary>
        /// <param name="game">game</param>
        public GameScene(Game game) : base(game)
        {
            components = new List<GameComponent>();
            hide();
        }
        /// <summary>
        /// An override draw method 
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent comp = null;
            foreach (GameComponent item in components)
            {
                if (item is DrawableGameComponent)
                {
                    comp = (DrawableGameComponent)item;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                }
            }

            base.Draw(gameTime);
        }
        /// <summary>
        /// An override update method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent  item in components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }
    }
}

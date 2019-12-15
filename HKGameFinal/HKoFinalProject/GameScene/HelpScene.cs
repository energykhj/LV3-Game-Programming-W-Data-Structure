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
    /// A Class of HelpScene
    /// </summary>
    public class HelpScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D helpTex;
        private GameSceneBackground help;
        /// <summary>
        /// A constructor for HelpScene object
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="spriteBatch">spriteBatch</param>
        public HelpScene(Game game, 
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            helpTex = game.Content.Load<Texture2D>("Images/helpImage");
            help = new GameSceneBackground(game, spriteBatch, helpTex);
            this.Components.Add(help);
        }
    }
}

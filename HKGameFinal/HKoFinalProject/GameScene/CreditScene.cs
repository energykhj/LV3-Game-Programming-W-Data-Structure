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
    /// A Class of CreditScene
    /// </summary>
    public class CreditScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D creditTex;
        private GameSceneBackground credit;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="spriteBatch">spriteBatch</param>
        public CreditScene(Game game,
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            creditTex = game.Content.Load<Texture2D>("Images/Credit");
            credit = new GameSceneBackground(game, spriteBatch, creditTex);
            this.Components.Add(credit);
        }
    }
}

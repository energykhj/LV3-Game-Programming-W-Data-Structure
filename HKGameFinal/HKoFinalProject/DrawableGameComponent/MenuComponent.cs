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
    /// A class of MenuComponent
    /// </summary>
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont, hilightFont;
        private List<string> menuItems;
        private int selectedIndex = 0;
        private Vector2 position;
        private Color regularColor = Color.Yellow;
        private Color hilightColor = Color.Red;
        public int SelectedIndex { get => selectedIndex; set => selectedIndex = value; }

        private KeyboardState oldState;

        /// <summary>
        /// Constructor of MenuComponent
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="spriteBatch">spriteBatch</param>
        /// <param name="regularFont">unselected menu font</param>
        /// <param name="hilightFont">selected menu font</param>
        /// <param name="menus">Menu array</param>
        public MenuComponent(Game game,
            SpriteBatch spriteBatch,
            SpriteFont regularFont,
            SpriteFont hilightFont,
            string[] menus) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.hilightFont = hilightFont;

            menuItems = menus.ToList();
            position = new Vector2(Shared.stage.X/2, Shared.stage.Y/2);
        }

        /// <summary>
        /// An override draw method 
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = position;

            spriteBatch.Begin();
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (selectedIndex == i)
                {
                    spriteBatch.DrawString(hilightFont, menuItems[i], tempPos,
                        hilightColor);
                    tempPos.Y += hilightFont.LineSpacing;

                }
                else
                {
                    spriteBatch.DrawString(regularFont, menuItems[i], tempPos,
                        regularColor);
                    tempPos.Y += regularFont.LineSpacing;
                }
            }
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// An override update method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Count)
                {
                    selectedIndex = 0;
                }
            }

            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                selectedIndex--;
                if (selectedIndex == -1)
                {
                    selectedIndex = menuItems.Count - 1;
                }
            }

            oldState = ks;
            base.Update(gameTime);
        }
    }
}

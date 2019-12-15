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
    /// A class of StartScene
    /// </summary>
    public class StartScene : GameScene
    {
        private MenuComponent menu;
        private SpriteBatch spriteBatch;
        private GameMessage gameTitleMessage;
        private GameMessage classTitleMessage;

        string[] menuItems = {"Start Game", "High Score", "Help", "Credit", "Quit"};
        public MenuComponent Menu { get => menu; set => menu = value; }
        /// <summary>
        /// Constructor of StartScene
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="spriteBatch">spriteBatch</param>
        public StartScene(Game game,
            SpriteBatch spriteBatch) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = spriteBatch;

            // load the menu resources
            SpriteFont regularFont = game.Content.Load<SpriteFont>("Fonts/RegularFont");
            SpriteFont hilightFont = game.Content.Load<SpriteFont>("Fonts/HilightFont");

            menu = new MenuComponent(game, spriteBatch, regularFont, hilightFont, menuItems);
            this.Components.Add(menu);
            
            // load the game title resource
            SpriteFont titleFont = game.Content.Load<SpriteFont>("fonts/TitleFont");
            SpriteFont messageFont = game.Content.Load<SpriteFont>("fonts/MessageFont");

            gameTitleMessage = new GameMessage(game, spriteBatch, titleFont, Color.LightGoldenrodYellow);
            gameTitleMessage.Message = "FINAL PROJECT";
            Vector2 messageSize = titleFont.MeasureString(gameTitleMessage.Message);
            gameTitleMessage.Position = new Vector2((Shared.stage.X - messageSize.X) / 2, (Shared.stage.Y / 2)-200);
            this.Components.Add(gameTitleMessage);

            classTitleMessage = new GameMessage(game, spriteBatch, messageFont, Color.LightGoldenrodYellow);
            classTitleMessage.Message = "PROG2370 Game Programming";
            messageSize = messageFont.MeasureString(classTitleMessage.Message);
            classTitleMessage.Position = new Vector2((Shared.stage.X - messageSize.X) / 2, (Shared.stage.Y / 2) - 120);
            this.Components.Add(classTitleMessage);
        }

    }
}

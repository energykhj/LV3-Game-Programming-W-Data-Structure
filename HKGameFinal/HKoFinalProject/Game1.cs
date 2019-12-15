/* Program Code: PROG2370 Game Programming
 * 
 * Project name: HKoFinalProject
 * 
 * Purpose: To create a game using Monogame
 * 
 * Written By: Heuijin Ko
 * 
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace HKoFinalProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        private const int SCREEN_WIDTH = 1024;
        private const int SCREEN_HEIGHT = 768;

        //declare all scenes here
        private BackgroundScene bg;
        //start Scene
        private StartScene startScene;
        //actionScene
        private ActionScene actionScene;
        //helpScene
        private HelpScene helpScene;
        //credit Scene
        private CreditScene creditScene;
        //etc.
        
        private Song intro;
        private Song gameBGM;

        private enum Menu
        {
            STARTGAME,
            HIGHSCORE,
            HELP,
            CREDIT,
            EXIT
        }
        /// <summary>
        /// Constructor of the Game1
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);

            Shared.isPause = false;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Add spined background
            Texture2D bgTex = this.Content.Load<Texture2D>("images/Back");
            bg = new BackgroundScene(this, spriteBatch, bgTex, Vector2.Zero);
            this.Components.Add(bg);
            
            //BGM           
            intro = this.Content.Load<Song>("Sounds/intro");
            MediaPlayer.IsRepeating = true;
            //Game Background song
            gameBGM = this.Content.Load<Song>("Sounds/game");

            //instantiate StartScene
            startScene = new StartScene(this, spriteBatch);
            this.Components.Add(startScene);
            startScene.show();

            //instantiate ActionScene
            actionScene = new ActionScene(this, spriteBatch);
            this.Components.Add(actionScene);

            //instantiate HelpScene
            helpScene = new HelpScene(this, spriteBatch);
            this.Components.Add(helpScene);

            //instantiate CreditScene
            creditScene = new CreditScene(this, spriteBatch);
            Components.Add(creditScene);

            //enable only one startscene
            startScene.show();
            MediaPlayer.Play(intro);

          //  ReturnToMenu();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            KeyboardState ks = Keyboard.GetState();
            int selectedIndex = startScene.Menu.SelectedIndex;

            // if screen is menu
            if (startScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Enter))
                {
                    if (selectedIndex == (int)Menu.STARTGAME)
                    {
                        startScene.hide();
                        MediaPlayer.Stop();

                        LoadContent();
                        MediaPlayer.Play(gameBGM);
                        HideAllScenes();
                        actionScene.show();
                    }
                    else if (selectedIndex == (int)Menu.CREDIT)
                    {
                        startScene.hide();
                        creditScene.show();
                    }
                    else if (selectedIndex == (int)Menu.HELP)
                    {
                        startScene.hide();
                        helpScene.show();
                    }
                    else if (selectedIndex == (int)Menu.EXIT)
                    {
                        Exit();
                    } 
                }
                               
            }
            else if (helpScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    startScene.show();
                    helpScene.hide();
                }
            }
            else if (creditScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    startScene.show();
                    creditScene.hide();
                }
            }
            // if screen is not a menu
            else
            //if (actionScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    Shared.currentLevel = 1;
                    Shared.isPlaySameLevel = 1;

                    MediaPlayer.Stop();
                    HideAllScenes();
                    startScene.show();
                    MediaPlayer.Play(intro);
                }

                if (ks.IsKeyDown(Keys.Space))
                {
                    if (Shared.currentLevel > Shared.TOTAL_LEVEL)
                    {
                        Shared.currentLevel = 1;
                        Shared.isPlaySameLevel = 1;
                        actionScene.hide();
                    }                    
                    else
                    {
                        actionScene.hide();
                        if (Shared.isNextLevel)
                        {
                            Shared.isPlaySameLevel = 1;
                            Shared.isNextLevel = false;
                        }
                        else
                        {
                            // Meaning that game is failed. 
                            if (Shared.isPlaySameLevel > Shared.TOTAL_PLAY)
                            {
                                Shared.currentLevel = 1;
                                Shared.isPlaySameLevel = 1;
                            }
                        }
                    }
                    actionScene = new ActionScene(this, spriteBatch);
                    this.Components.Add(actionScene);
                    actionScene.show();
                    MediaPlayer.Play(gameBGM);
                }
            }
                        
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        /// <summary>
        /// hide all scenes
        /// </summary>
        private void HideAllScenes()
        {
            GameScene gs = null;
            foreach (GameComponent item in Components)
            {
                if (item is GameScene)
                {
                    gs = (GameScene)item;
                    gs.hide();
                }
            }
        }        
    }
}

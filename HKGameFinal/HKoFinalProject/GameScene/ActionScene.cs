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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HKoFinalProject
{
    /// <summary>
    /// A class of the ActionScene
    /// </summary>
    public class ActionScene : GameScene
    {
        //counts 30sec for level clear bonus
        private const float GAME_DURATION = 30.0f;     
        private const bool ENEMY_COLLISION = true;

        private int ENERGY_SCORE = 200;             

        private SpriteBatch spriteBatch;        
        private Crash crash;
        private Ship ship;

        private GameMessage levelMessage;
        private GameMessage gameOverMessage;
        private GameMessage levelCompleteMessage;
        private GameMessage gameCompleteMessage;
        private GameMessage scoreMessage;
        private GameMessage highScoreMessage;
        private Vector2 messageSize;

        private Enemy enemy;
        private Vector2 enemySpeed;
        private Vector2 enemyPos;

        private Gift gift;
        private Vector2 giftSpeed;
        private Vector2 giftPos;

        private GamePlayTime timer;
        private Vector2 timerPos;

        private bool isCrash = false;
        private bool isTakeEnergy = false;

        private int energyCount;
        
        private Song levelUp;
        private Song gameFailSound;
        private Song gameOver;
        private Song crashSound;
        private Song takeEnergySound;
        private Song bgmSound;

        Texture2D shipTex;
        Vector2 remainShip;

        /// <summary>
        /// Constructor of the ActionScene
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="spriteBatch">spriteBatch</param>
        /// <param name="sound">sound</param>
        public ActionScene(Game game,
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            //this.sound = sound;

            energyCount = Shared.ENERGY;
            Shared.isNextLevel = false;

            shipTex = game.Content.Load<Texture2D>("Images/ship");
            Texture2D giftTex = game.Content.Load<Texture2D>("Images/gift");
            Texture2D enemyTex = game.Content.Load<Texture2D>("Images/enemy");            
            Texture2D expTex = game.Content.Load<Texture2D>("Images/explosion");
            Texture2D crashTex = game.Content.Load<Texture2D>("Images/boom");
            Texture2D bgTex = game.Content.Load<Texture2D>("images/Back");

            bgmSound = game.Content.Load<Song>("Sounds/game");
            crashSound = game.Content.Load<Song>("Sounds/boom");
            takeEnergySound = game.Content.Load<Song>("Sounds/item");
            levelUp = game.Content.Load<Song>("Sounds/levelup");
            gameOver = game.Content.Load<Song>("Sounds/gameOver");
            gameFailSound = game.Content.Load<Song>("Sounds/intro");

            ship = new Ship(game, spriteBatch, shipTex, ENERGY_SCORE, isCrash, isTakeEnergy);
            MediaPlayer.Play(bgmSound);
            // Set game level
            Shared.GameLevelInitialize();

            #region Game Object Generation
            int maxSpawnX = 800;
            int maxSpawnY = 600;

            Random r = new Random(120);
            //ramdomly enemy generate
            for (int i = 0; i < Shared.ENEMY; i++)
            {
                int speedX = r.Next(1, Shared.MAX_SPEED);
                int speedY = r.Next(1, Shared.MAX_SPEED);
                int signX = r.Next(0, 2);
                int signY = r.Next(0, 2);

                if (signX == 1) speedX = -speedX;
                if (signY == 1) speedY = -speedY;

                int xp = r.Next(0, maxSpawnX);
                int yp = r.Next(0, maxSpawnY);

                enemySpeed = new Vector2((float)speedX, (float)speedY);
                enemyPos = new Vector2(xp, yp);                
                enemy = new Enemy(game, spriteBatch, enemyTex, enemyPos, enemySpeed);
                this.Components.Add(enemy);

                crash = new Crash(game, spriteBatch, expTex, Vector2.Zero);
                this.Components.Add(crash);

                CollisionManager cm = new CollisionManager(game, enemy, ship,
                    bgmSound, crashSound, crash, ENEMY_COLLISION); 
                this.Components.Add(cm);
            }

            //ramdomly gift generate
            for (int i = 0; i < Shared.ENERGY; i++)
            {
                int speedX = r.Next(1, Shared.MAX_SPEED);
                int speedY = r.Next(1, Shared.MAX_SPEED);
                int signX = r.Next(0, 2);
                int signY = r.Next(0, 2);

                if (signX == 1) speedX = -speedX;
                if (signY == 1) speedY = -speedY;

                int xp = r.Next(0, maxSpawnX);
                int yp = r.Next(0, maxSpawnY);

                giftSpeed = new Vector2((float)speedX, (float)speedY);
                giftPos = new Vector2(xp, yp);
                gift = new Gift(game, spriteBatch, giftTex, giftPos, giftSpeed, Shared.stage);
                this.Components.Add(gift);

                crash = new Crash(game, spriteBatch, crashTex, giftPos);
                this.Components.Add(crash);

                CollisionManager cm = new CollisionManager(game, gift, ship, bgmSound,
                    takeEnergySound, crash, !ENEMY_COLLISION);
                this.Components.Add(cm);
            }

            #endregion

            #region Game Message Initialization
            SpriteFont infoFont = game.Content.Load<SpriteFont>("fonts/infoFont");
            SpriteFont messageFont = game.Content.Load<SpriteFont>("fonts/MessageFont");
            
            //timer
            timerPos = new Vector2((Shared.stage.X - infoFont.MeasureString("Time remain: 30.0").X)/2, 10);
            timer = new GamePlayTime(game, spriteBatch, infoFont, GAME_DURATION, timerPos);
            this.Components.Add(timer);

            // level message
            levelMessage = new GameMessage(game, spriteBatch, infoFont, Color.Yellow);
            levelMessage.Message = string.Format("Level {0}", Shared.currentLevel);
            levelMessage.Position = new Vector2(Shared.stage.X - infoFont.MeasureString(levelMessage.Message).X - 40, 30);
            this.Components.Add(levelMessage);

            // score message
            scoreMessage = new GameMessage(game, spriteBatch, infoFont, Color.Yellow);
            scoreMessage.Message = string.Format("Energy Score: {0:D3}", 0);
            scoreMessage.Position = new Vector2(50 + infoFont.LineSpacing, 25);
            this.Components.Add(scoreMessage);

            // high score message
            highScoreMessage = new GameMessage(game, spriteBatch, infoFont, Color.Yellow);
            highScoreMessage.Message = string.Format("High Score: {0:D3}", 0);
            //highScoreMessage.Position = new Vector2(50 + infoFont.LineSpacing, 15);
            highScoreMessage.Position = new Vector2(Shared.stage.X - infoFont.MeasureString(highScoreMessage.Message).X - 40, 10);
            this.Components.Add(highScoreMessage);

            // level complete message
            levelCompleteMessage = new GameMessage(game, spriteBatch, messageFont, Color.LightGoldenrodYellow);
            levelCompleteMessage.Message = "LEVEL COMPLETE\nSPACE TO NEXT LEVEL";
            messageSize = messageFont.MeasureString(levelCompleteMessage.Message);
            levelCompleteMessage.Position = new Vector2((Shared.stage.X - messageSize.X) / 2, (Shared.stage.Y - messageSize.Y) / 2);
            this.Components.Add(levelCompleteMessage);
            levelCompleteMessage.Enabled = false;
            levelCompleteMessage.Visible = false;

            // game complete message
            gameCompleteMessage = new GameMessage(game, spriteBatch, messageFont, Color.LightGoldenrodYellow);
            gameCompleteMessage.Message = "CONGRATURATION!!\n\nGAME COMPLETE\nSPACE TO RE-PLAY, ESC TO MENU";
            messageSize = messageFont.MeasureString(gameCompleteMessage.Message);
            gameCompleteMessage.Position = new Vector2((Shared.stage.X - messageSize.X) / 2, (Shared.stage.Y - messageSize.Y) / 2);
            this.Components.Add(gameCompleteMessage);
            gameCompleteMessage.Enabled = false;
            gameCompleteMessage.Visible = false;

            // game over message
            gameOverMessage = new GameMessage(game, spriteBatch, messageFont, Color.OrangeRed);
            gameOverMessage.Message = "GAME OVER\nSPACE TO RE-PLAY, ESC TO MENU";
            messageSize = messageFont.MeasureString(gameOverMessage.Message);
            gameOverMessage.Position = new Vector2((Shared.stage.X - messageSize.X) / 2, (Shared.stage.Y - messageSize.Y) / 2);
            this.Components.Add(gameOverMessage);
            gameOverMessage.Enabled = false;
            gameOverMessage.Visible = false;

            #endregion
        }
        /// <summary>
        ///  An override Draw method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            int shipCount = 3;
            shipCount -= Shared.isPlaySameLevel;

            for (int i = 0; i < shipCount; i++)
            {
                remainShip = new Vector2((70 * i+1) / 2, 20);
                spriteBatch.Draw(shipTex, remainShip, Color.White);
            }
            ship.Draw(gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        /// <summary>
        ///  An override Update method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Update(GameTime gameTime)
        {
            if (ship.Crash)
            {
                ship.Energy_score -= 40; 
                ship.Crash = false;
            }
            else if (ship.TakeEnergy)
            {
                ship.Energy_score += 5;
                ship.TakeEnergy = false;
                energyCount--;
            }
            
            if (ship.Energy_score < 40)  ship.Energy_score = 0;

            // get scores
            highScoreMessage.Message = string.Format("High Score: {0:D3}", Shared.GetHighScore());
            scoreMessage.Message = string.Format("Energy Score: {0:D3}", ship.Energy_score);

            if (ship.Energy_score < 10 || timer.TimeCounter == 0)
            //if (ship.Energy_score < 10 || timer.CurrentTime == "0")
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(gameFailSound);

                gameOverMessage.Message = "GAME FAIL\nSPACE TO RE-PLAY, ESC TO MENU";
                Shared.isPlaySameLevel++;

                // can play up to 3 times in the same level if game is failed.
                if (Shared.isPlaySameLevel > 3)    
                {
                    MediaPlayer.Stop();
                    MediaPlayer.Play(gameOver);
                    MediaPlayer.IsRepeating = false;
                    gameOverMessage.Message = "GAME OVER\nSPACE TO RE-PLAY, ESC TO MENU";
                }

                gameOverMessage.Enabled = true;
                gameOverMessage.Visible = true;
                this.Enabled = false;
            }
            else
            {
                // Get all Energy
                if (energyCount == 0)
                {
                    MediaPlayer.Stop();
                    if (Shared.isPlaySameLevel > Shared.TOTAL_PLAY) MediaPlayer.Play(gameOver);
                    else MediaPlayer.Play(levelUp);
                    Shared.SetHighScore(ship.Energy_score);

                    Shared.isNextLevel = true;
                    Shared.currentLevel++;

                    if (Shared.currentLevel > Shared.TOTAL_LEVEL)
                    {
                        gameCompleteMessage.Enabled = true;
                        gameCompleteMessage.Visible = true;
                    }
                    else
                    {
                        levelCompleteMessage.Enabled = true;
                        levelCompleteMessage.Visible = true;
                    }

                    this.Enabled = false;
                }
            }

            ship.Update(gameTime);
            base.Update(gameTime);
        }
        
    }
}

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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace HKoFinalProject
{
    /// <summary>
    /// A class of CollisionManager 
    /// </summary>
    public class CollisionManager : GameComponent
    {
        private Enemy enemy;
        private Ship ship;
        private Gift gift;
        private Crash explosion;
        private Song backSound;
        private Song giftSound;
        private Song crashSound;
        private bool type;  // collision type
        /// <summary>
        /// Constructor for the enemy and ship 
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="enemy">enemy</param>
        /// <param name="ship">ship</param>
        /// <param name="sound">sound</param>
        /// <param name="explosion">explosion</param>
        /// <param name="type">object is enemy or not</param>
        public CollisionManager(Game game,
            Enemy enemy,
            Ship ship,
            Song backSound,
            Song crashSound,
            Crash explosion,
            bool type) : base(game)
        {
            this.enemy = enemy;
            this.ship = ship;
            this.backSound = backSound;
            this.crashSound = crashSound;
            this.explosion = explosion;
            this.type = type;
        }
        /// <summary>
        /// Constructor for the gift and ship 
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="gift">gift</param>
        /// <param name="ship">ship</param>
        /// <param name="sound">sound</param>
        /// <param name="explosion">explosion</param>
        /// <param name="type">object is enemy or not</param>
        public CollisionManager(Game game,
           Gift gift,
           Ship ship,
           Song backSound,
           Song giftSound,
           Crash explosion,
           bool type) : base(game)
        {
            this.gift = gift;
            this.ship = ship;
            this.backSound = backSound;
            this.giftSound = giftSound;
            this.explosion = explosion;
            this.type = type;
        }
        /// <summary>
        /// An override Update method
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Update(GameTime gameTime)
        {
            // if enemy
            if (type)
            {
                if (enemy.getBound().Intersects(ship.getBound()))
                {
                    explosion.Position = new Vector2(enemy.getBound().X - 20, enemy.getBound().Y - 20);
                    if (enemy.Visible)
                    {
                        explosion.startShowFrames();
                        MediaPlayer.Play(crashSound);
                        MediaPlayer.IsRepeating = false;
                        ship.Crash = true;
                    }
                    enemy.Visible = false;
                    enemy.Enabled = false;
                }
            }
            // if gift
            else
            {
                if (gift.getBound().Intersects(ship.getBound()))
                {
                    explosion.Position = new Vector2(gift.getBound().X - 70, gift.getBound().Y - 70);

                    if (gift.Visible)
                    {
                        explosion.startShowFrames();
                        MediaPlayer.Play(giftSound);
                        MediaPlayer.IsRepeating = false;
                        ship.TakeEnergy = true;
                    }
                    gift.Visible = false;
                    gift.Enabled = false;

                }
            }
            base.Update(gameTime);
        }
    }
}

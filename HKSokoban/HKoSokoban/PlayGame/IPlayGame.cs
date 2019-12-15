/* Interface, IPlayGame.cs
 * Assignment 2
 * Play form for Sokoban
 * 
 * Revision History
 *      $ Heuijin Ko, Oct 23, 2019: Created 
 *      $ Heuijin Ko, Oct 24, 2019: Revised
 *      
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKAssignment2.PlayGame
{
    public enum Direction { LEFT, RIGHT, UP, DOWN };
    public enum ImageType
    {
        NONE = 0,
        HERO = 1,
        WALL = 2,
        BOX = 3,
        GOAL = 4,
        DBOX = 5
    }
    /// <summary>
    /// Interface for the game
    /// </summary>
    public interface IPlayGame
    {
        /// <summary>
        /// Moving
        /// </summary>
        /// <param name="direction"></param>
        void Move(Direction direction);
        /// <summary>
        /// get move count
        /// </summary>
        /// <returns></returns>
        string GetMoveCount();
        /// <summary>
        /// get push count
        /// </summary>
        /// <returns></returns>
        string GetPushCount();

    }
}

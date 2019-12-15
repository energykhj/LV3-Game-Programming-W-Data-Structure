/* PlayGame.cs
 * Assignment 2
 * Play form for Sokoban
 * Revision History
 *      $ Heuijin Ko, Oct 23, 2019: Created 
 *      $ Heuijin Ko, Oct 24, 2019: Revised
 *      $ Heuijin Ko, Nov 1, 2019: Revised
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKAssignment2.PlayGame
{
    /// <summary>
    /// Class to game control
    /// </summary>
    public class PlayGame : IPlayGame
    {
        // To get grid columns and rows from a file.
        const int GRID_ROWS_COLS = 2;

        private int pushCount = 0;
        private int moveCount = 0;
        
        private Tile[,] tiles;
        private int[,] goalPos;
        private int HeroX;
        private int HeroY;

        private int boxOnGoal = 0;
        public int BoxOnGoal { get => boxOnGoal; set => boxOnGoal = value; }

        /// <summary>
        /// Constructor for PlayGame
        /// </summary>
        /// <param name="tiles">Initialize tiles</param>
        /// <param name="goalPos">Intitialize goal positon</param>
        /// <param name="heroX">Intitialize hero row position</param>
        /// <param name="heroY">Intitialize hero col position</param>
        public PlayGame(Tile[,] tiles, 
            int[,] goalPos,
            int heroX, 
            int heroY)
        {
            this.tiles = tiles;
            this.goalPos = goalPos;
            HeroX = heroX;
            HeroY = heroY;
        }
        /// <summary>
        /// get move count
        /// </summary>
        /// <returns></returns>
        public string GetMoveCount()
        {
            return moveCount.ToString();
        }
        /// <summary>
        /// get push count
        /// </summary>
        /// <returns></returns>
        public string GetPushCount()
        {
            return pushCount.ToString();
        }
        /// <summary>
        /// Get image by the tool type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Image GetImageType(int type)
        {
            Image img =   Properties.Resources.none;            

            switch (type)
            {
                case 0:
                    img = Properties.Resources.none;
                    break;
                case 1:
                    img = Properties.Resources.hero;
                    break;
                case 2:
                    img = Properties.Resources.wall;
                    break;
                case 3:
                    img = Properties.Resources.box;
                    break;
                case 4:
                    img = Properties.Resources.goal;
                    break;
                case 5:
                    img = Properties.Resources.darkBox;
                    break;
                default:
                    break;
            }
            return img;
        }
        /// <summary>
        /// get specific tile information
        /// </summary>
        /// <param name="row">specific row postion of tiles</param>
        /// <param name="col">specific col postion of tiles</param>
        /// <returns></returns>
        private Tile GetTile(int row, int col)
        {
            return tiles[row, col];
        }
        /// <summary>
        /// Moving by derection, LEFT/RIGHT/UP/DOWN
        /// </summary>
        /// <param name="direction">Direction key</param>
        public void Move(Direction direction)
        {
            if (direction == Direction.LEFT)
            {
                if ((HeroY > 0) && !IsWall(HeroX, HeroY - 1))
                {                    
                    if (CanMove(HeroX, HeroY - 1))
                    {
                        MoveTile(GetTile(HeroX, HeroY), 
                            GetTile(HeroX, --HeroY));

                        ClearTile(HeroX, HeroY + 1);
                        moveCount++;
                    }
                    else if (CanMove(HeroX, HeroY - 2))
                    {
                        MoveTile(GetTile(HeroX, HeroY - 1), 
                            GetTile(HeroX, HeroY - 2));

                        MoveTile(GetTile(HeroX, HeroY),
                            GetTile(HeroX, --HeroY));

                        ClearTile(HeroX, HeroY + 1);
                        moveCount++;
                        pushCount++;
                    }
                    ResetType(HeroX, HeroY + 1);
                    CheckGoal();
                }
            }
            else if (direction == Direction.RIGHT)
            {
                if (HeroY < tiles.GetUpperBound(1) && !IsWall(HeroX, HeroY + 1))
                {
                    if (CanMove(HeroX, HeroY + 1))
                    {
                        MoveTile(GetTile(HeroX, HeroY), 
                            GetTile(HeroX, ++HeroY));

                        ClearTile(HeroX, HeroY - 1);
                        moveCount++;
                    }
                    else if (CanMove(HeroX, HeroY + 2))
                    {
                        MoveTile(GetTile(HeroX, HeroY + 1), 
                            GetTile(HeroX, HeroY + 2));

                        MoveTile(GetTile(HeroX, HeroY), 
                            GetTile(HeroX, ++HeroY));

                        ClearTile(HeroX, HeroY - 1);
                        moveCount++;
                        pushCount++;
                    }
                    ResetType(HeroX, HeroY - 1);
                    CheckGoal();
                }
            }
            else if (direction == Direction.UP)
            {
                if ((HeroX > 0) && !IsWall(HeroX - 1 , HeroY))
                {
                    if (CanMove(HeroX - 1, HeroY))
                    {
                        MoveTile(GetTile(HeroX, HeroY), 
                            GetTile(--HeroX, HeroY));

                        ClearTile(HeroX + 1, HeroY);
                        moveCount++;
                    }
                    else if (CanMove(HeroX - 2, HeroY))
                    {   
                        MoveTile(GetTile(HeroX - 1, HeroY), 
                            GetTile(HeroX - 2, HeroY));

                        MoveTile(GetTile(HeroX, HeroY), 
                            GetTile(--HeroX, HeroY));

                        ClearTile(HeroX + 1, HeroY);
                        moveCount++;
                        pushCount++;
                    }
                    ResetType(HeroX + 1, HeroY);
                    CheckGoal();
                }
            }
            else if (direction == Direction.DOWN)
            {
                if (HeroX < tiles.GetUpperBound(1) && !IsWall(HeroX + 1, HeroY))
                {
                    if (CanMove(HeroX + 1, HeroY)) 
                    {
                        MoveTile(GetTile(HeroX, HeroY), GetTile(++HeroX, HeroY));
                        ClearTile(HeroX - 1, HeroY);
                        moveCount++;
                    }
                    else if (CanMove(HeroX + 2, HeroY))
                    {
                        MoveTile(GetTile(HeroX + 1, HeroY), 
                            GetTile(HeroX + 2, HeroY));

                        MoveTile(GetTile(HeroX, HeroY), 
                            GetTile(++HeroX, HeroY));  

                        ClearTile(HeroX - 1, HeroY); 
                        moveCount++;
                        pushCount++;
                    }
                    ResetType(HeroX - 1, HeroY);
                    CheckGoal();
                }
            }
        }
        /// <summary>
        /// check whether hero can move.
        /// If postion is nothing or goal, hero can move.
        /// </summary>
        /// <param name="row">Row to be moved</param>
        /// <param name="col">Cow to be moved</param>
        /// <returns></returns>
        private bool CanMove(int row, int col)
        {
            return ((tiles[row, col].TOOLTYPE == (int)ImageType.NONE) ||
                        (tiles[row, col].TOOLTYPE == (int)ImageType.GOAL)) ? 
                        true : false;
        }
        /// <summary>
        /// Check whether next is wall. If wall, return true
        /// </summary>
        /// <param name="row">Row to be moved</param>
        /// <param name="col">Col to be moved</param>
        /// <returns></returns>
        private bool IsWall(int row, int col)
        {
            return (GetTile(row, col).TOOLTYPE == (int)ImageType.WALL) ?
                    true : false;
        }
        /// <summary>
        /// Moving a tile
        /// </summary>
        /// <param name="curTile">Current Tile</param>
        /// <param name="nextTile">Next tilt to be moved</param>
        /// <returns></returns>
        private void MoveTile(Tile curTile, Tile nextTile)
        {
            nextTile.TOOLTYPE = curTile.TOOLTYPE;
            nextTile.Image = GetImageType(curTile.TOOLTYPE);
        }
        /// <summary>
        /// Check whether current position is goal
        /// </summary>
        private void CheckGoal()
        {
            boxOnGoal = 0;
            for (int i = 0; i <= goalPos.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= goalPos.GetUpperBound(1); j++)
                {
                    if ((goalPos[i, j] == (int)ImageType.GOAL) && 
                        (tiles[i, j].TOOLTYPE == (int)ImageType.BOX))
                    {
                        boxOnGoal++;
                        tiles[i, j].Image = GetImageType((int)ImageType.DBOX);
                    }
                }
            }
        }
        /// <summary>
        /// Clear previous tile after move
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void ClearTile(int x, int y)
        {
            tiles[x, y].Image = null;
            tiles[x, y].TOOLTYPE = 0;
        }
        /// <summary>
        /// If the tool type is goal, redraw the goal icon
        /// </summary>
        /// <param name="goalX"></param>
        /// <param name="goalY"></param>
        private void ResetType(int goalX, int goalY)
        {
            if (goalPos[goalX, goalY] == (int)ImageType.GOAL)
            {
                tiles[goalX, goalY].Image = 
                    GetImageType((int)ImageType.GOAL);
                tiles[goalX, goalY].TOOLTYPE = (int)ImageType.GOAL;
            }
        }
    }
}

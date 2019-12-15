/* PlayForm.cs
 * Assignment 2
 * Play form for Sokoban
 * 
 * Revision History
 *      $ Heuijin Ko, Oct 23, 2019: Created 
 *      $ Heuijin Ko, Oct 24, 2019: revised
 *      
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKAssignment2.PlayGame
{
    /// <summary>
    /// Play Form for Sokoban
    /// </summary>
    public partial class PlayForm : Form
    {
        private PlayGame PG;
        // Minimum size for playing games
        const int GRID_MIN_SIZE = 5;

        private string[] fileLevel;
        private bool isGameLoad = false;
        private int goalCount = 0;


        /// <summary>
        /// Constructor of the form
        /// </summary>
        public PlayForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load game level file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = loadFile.ShowDialog();
            switch (r)
            {
                case DialogResult.OK:
                    lblNumberOfMoves.Text = "0";
                    lblNumberOfPushes.Text = "0";
                    lblMsg.Text = "";

                    if (LoadFile(loadFile.FileName))
                    {
                        isGameLoad = true;
                        DrawGrid();
                    }
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// The game file load
        /// </summary>
        /// <param name="filename">File name selected from the user</param>
        private bool LoadFile(string filename)
        {
            string fileLine = "";
            try
            {
                using (StreamReader sr = File.OpenText(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        fileLine += sr.ReadLine() + ",";
                    }
                    sr.Close();
                    fileLevel = fileLine.Split(',');
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in file load",
                                "Error: " + ex.Message,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);                
            }

            return false;
        }
    
        /// <summary>
        /// Draw grid to play
        /// </summary>
        /// <param name="col">total coloums of grid</param>
        /// <param name="row">total rows of grid</param>
        private void DrawGrid()
        {
            int gridRow = int.Parse(fileLevel[0]);
            int gridCol = int.Parse(fileLevel[1]);
            if ((gridCol >= GRID_MIN_SIZE) && (gridRow >= GRID_MIN_SIZE))
            {
                pnPlayground.Controls.Clear();

                // Find the size of a grid to be drawn.
                int gridSize = this.pnPlayground.Width / gridCol;

                // Adjust the size of the grid 
                // if total size larger than the panel size 
                while ((gridSize * gridRow) > this.pnPlayground.Height)
                {
                    gridSize--;
                }
                // Find start position x, y to be drawn
                // To display the grid in the center of the panel
                int gridStartX = 
                    (this.pnPlayground.Width - (gridSize * gridCol)) / 2;
                int gridStartY = 
                    (this.pnPlayground.Height - (gridSize * gridRow)) / 2;

                // Crateing each grid button
                MakeTile(gridSize, gridStartX, gridStartY);
            }

        }
        /// <summary>
        /// Making each grid button
        /// </summary>
        /// <param name="tileSize">a tile size</param>
        /// <param name="gridStartX">start position for the top</param>
        /// <param name="gridStartY">start position for the left</param>
        public void MakeTile(int tileSize, int gridStartX, int gridStartY)
        {
            goalCount = 0;
            int heroX = -1;
            int heroY = -1;
            int rowCnt = int.Parse(fileLevel[0]);
            int colCnt = int.Parse(fileLevel[1]);
            Tile[,] tiles = new Tile[rowCnt, colCnt];
            int[,] goalPos = new int[rowCnt, colCnt];

            for (int i = 2; i < fileLevel.Length-2; i++)
            {
                Tile t = new Tile();
                t.ROW = int.Parse(fileLevel[i]);
                t.COL = int.Parse(fileLevel[++i]);
                t.TOOLTYPE = int.Parse(fileLevel[++i]);
                tiles[t.ROW, t.COL] = t;            

                t.Height = tileSize;
                t.Width = tileSize;

                t.Location =
                    new System.Drawing.Point(tileSize * t.COL + gridStartX,
                    tileSize * t.ROW + gridStartY);

                t.Image = PlayGame.GetImageType(t.TOOLTYPE);
                t.SizeMode = PictureBoxSizeMode.StretchImage;
                t.BorderStyle = BorderStyle.Fixed3D;
                
                try
                {
                    if (t.TOOLTYPE == (int)ImageType.HERO)
                    {
                        heroX = t.ROW;
                        heroY = t.COL;
                        t.BringToFront();
                    }
                    else if (t.TOOLTYPE == (int)ImageType.GOAL)
                    {
                        goalCount++;
                        goalPos[t.ROW, t.COL] = (int)ImageType.GOAL;
                        t.SendToBack();
                    }
                    pnPlayground.Controls.Add(t);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            PG = new PlayGame(tiles, goalPos, heroX, heroY);
        }
        
        
        /// <summary>
        /// Click the left button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (!IsGameLoad()) return;
            PG.Move(Direction.LEFT);
            lblNumberOfMoves.Text = PG.GetMoveCount();
            lblNumberOfPushes.Text = PG.GetPushCount();
            getCheckGoalPlace();
        }
        /// <summary>
        /// Click the right button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (!IsGameLoad()) return;
            PG.Move(Direction.RIGHT);
            lblNumberOfMoves.Text = PG.GetMoveCount();
            lblNumberOfPushes.Text = PG.GetPushCount();
            getCheckGoalPlace();
        }
        /// <summary>
        /// Click the up button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (!IsGameLoad()) return;
            PG.Move(Direction.UP);
            lblNumberOfMoves.Text = PG.GetMoveCount();
            lblNumberOfPushes.Text = PG.GetPushCount();
            getCheckGoalPlace();
        }
        /// <summary>
        /// Click the down button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (!IsGameLoad()) return;
            PG.Move(Direction.DOWN);
            lblNumberOfMoves.Text = PG.GetMoveCount();
            lblNumberOfPushes.Text = PG.GetPushCount();
            getCheckGoalPlace();
        }
        /// <summary>
        /// Check game is end. If game ended, clear the the tiles.
        /// </summary>
        private void getCheckGoalPlace()
        {
            if (PG.BoxOnGoal == goalCount)
            {
                lblMsg.Text = "Game end!!";
                MessageBox.Show($"Game end!!\nTotal Movees: " +
                    $"{PG.GetMoveCount()}\n" +
                    $"Total Pushes: {PG.GetPushCount()}");

                pnPlayground.Controls.Clear();
            }
        }
        /// <summary>
        /// Check the game is load
        /// </summary>
        /// <returns></returns>
        private bool IsGameLoad()
        {
            if (!isGameLoad)
            {
                MessageBox.Show("Load the game file first.");
                return false;
            }
            if (PG.BoxOnGoal == goalCount)
            {
                MessageBox.Show("Game was end. You can load another game.");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Arrow buttons linked to each button event
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                btnUp.PerformClick();
                return true;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                btnDown.PerformClick();
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                btnLeft.PerformClick();
                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                btnRight.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

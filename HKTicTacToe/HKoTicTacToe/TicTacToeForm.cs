/* TicTacTeForm.cs
 * Assignment 3
 * Form for TicTacToe
 * Revision History
 *      $ Heuijin Ko, Nov 13, 2019: Created 
 *      $ Heuijin Ko, Nov 17, 2019: Revised
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKoAssignment3
{ 
    /// <summary>
    /// Tic Tac Toe form 
    /// </summary>
    public partial class TicTacToeForm : Form
    {
        enum Sign
        {
            ORIGIN = 0,
            BLACK = 1,
            NONE = 2
        }
        
        const int GRID_COUNT = 3;
        const int MAX_TURN = 9;

        private int TOGGLE_SIGN = (int)Sign.ORIGIN;
        private int eachTurn = 0;

        Tile[,] tiles = new Tile[GRID_COUNT, GRID_COUNT];

        /// <summary>
        /// Default constructor
        /// </summary>
        public TicTacToeForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Form load, call DrawGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TicTacToeForm_Load(object sender, EventArgs e)
        {
            lblTurn.Text = "Spider Man Turn";
            DrawGrid();
        }
        /// <summary>
        /// Draw 3x3 grid, each tile initialize 
        /// </summary>
        private void DrawGrid()
        {
            // Find the size of a grid to be drawn.
            int gridSize = this.pnPlayground.Width / GRID_COUNT;

            for (int y = 0; y < GRID_COUNT; y++)
            {
                for (int x = 0; x < GRID_COUNT; x++)
                {
                    // Create a tile with properties
                    Tile t = new Tile
                    {
                        Height = gridSize,
                        Width = gridSize,

                        Location =
                        new System.Drawing.Point(gridSize * x,
                        gridSize * y),

                        SizeMode = PictureBoxSizeMode.CenterImage,
                        BorderStyle = BorderStyle.FixedSingle,

                        ROW = y,
                        COL = x,
                        TOOLTYPE = (int)Sign.NONE 
                    };

                    // Added event
                    t.Click += GridCell_Click;
                    tiles[t.ROW, t.COL] = t;
                    try
                    {
                        this.pnPlayground.Controls.Add(t);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        /// <summary>
        /// Store the image type and value of a specific cell.
        /// </summary>
        /// <param name="sender">DrawGrid</param>
        /// <param name="e">EventArgs</param>
        private void GridCell_Click(object sender, EventArgs e)
        {
            Tile t = (Tile)sender;
            int contentType = -1;
            string winnerMsg = "";

            // preoccupied cell will not change its image
            if (t.TOOLTYPE != (int)Sign.NONE) return;

            if (TOGGLE_SIGN == (int)Sign.ORIGIN)
            {
                contentType = (int)Sign.ORIGIN;
                TOGGLE_SIGN = (int)Sign.BLACK;
                winnerMsg = "Spider Man";
                lblTurn.Text = "Black Spider Man Turn";
            }
            else if (TOGGLE_SIGN == (int)Sign.BLACK)
            {
                contentType = (int)Sign.BLACK;
                TOGGLE_SIGN = (int)Sign.ORIGIN;
                winnerMsg = "Black Spider Man";
                lblTurn.Text = "Spider Man Turn";
            }

            t.TOOLTYPE = contentType;
            t.Image = iconList.Images[t.TOOLTYPE];
            eachTurn++;
            if (CheckMatch(t))
            {
                lblTurn.Text = winnerMsg + " wins";
                MessageBox.Show(
                    string.Format("{0} wins", winnerMsg), this.Text);
                Restart();
            }
                        
            if (eachTurn == MAX_TURN)
            {
                MessageBox.Show("Draw", this.Text);
                Restart();
            }
        }        
        /// <summary>
        /// Check sign for each line, Row/Column/Left-Right Diagonal
        /// </summary>
        /// <param name="tile">Selected tile</param>
        /// <returns>If matched, return true</returns>
        private bool CheckMatch(Tile tile)
        {
            int matchCount = 3;
            int matchRow = 0;
            int matchColumn = 0;
            int matchDiagonal = 0;

            // check row
            for (int i = 0; i < GRID_COUNT; i++)
            {
                if (tiles[i, tile.COL].TOOLTYPE == tile.TOOLTYPE)
                    matchRow++;
            }

            if (matchRow == matchCount) return true;

            // check column
            for (int i = 0; i < GRID_COUNT; i++)
            {
                if (tiles[tile.ROW, i].TOOLTYPE == tile.TOOLTYPE)
                    matchColumn++;
            }
            if (matchColumn == matchCount) return true;

            // check right Diagonal
            // [0,0] [1,1] [2,2]
            for (int i = 0; i < GRID_COUNT; i++)
            {
                if (tiles[i, i].TOOLTYPE == tile.TOOLTYPE)
                    matchDiagonal++;
            }
            if (matchDiagonal == matchCount) return true;
            matchDiagonal = 0;

            // check left Diagonal
            // [0,2] [1,1] [2,0]
            int col = GRID_COUNT;
            for (int r = 0; r < GRID_COUNT; r++)
            {
                if (tiles[r, --col].TOOLTYPE == tile.TOOLTYPE)
                    matchDiagonal++;
            }

            if (matchDiagonal == matchCount) return true;

            return false;
        }
        /// <summary>
        /// Control clear and ready to restart
        /// </summary>
        private void Restart()
        {
            eachTurn = 0;
            TOGGLE_SIGN = (int)Sign.ORIGIN;
            lblTurn.Text = "Spider Man Turn";
            pnPlayground.Controls.Clear();
            DrawGrid();
        }
    }
}

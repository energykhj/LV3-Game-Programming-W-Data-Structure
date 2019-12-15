/* DesignForm.cs
 * Assignment 1
 * Design form for Sokoban
 * 
 * Revision History
 *      $ Heuijin Ko, Sept 15, 2019: Created 
 *      $ Heuijin Ko, Sept 16, 2019: revised
 *      $ Heuijin Ko, Sept 18, 2019: revised 
 *          - added a Tile class
 *      
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKAssignment2
{
    /// <summary>
    /// Form for design level
    /// </summary>
    public partial class DesignForm : Form
    {
        // Declaring enume variable for storing image information.
        enum ImageType
        {
            NONE = 0,
            HERO = 1,
            WALL = 2,
            BOX = 3,
            GOAL = 4
        }
        ImageType imageType = ImageType.NONE;        

        // Booean value whether the grid has been generated.
        private bool GENERATED = false;

        // Stores the values ​​of rows and columns entered from the user. 
        private int COLS = -1;
        private int ROWS = -1;

        public DesignForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Click tht generate button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            this.Panel.Controls.Clear();

            try
            {
                COLS = int.Parse(txtCols.Text);
                ROWS = int.Parse(txtRows.Text);

                if (COLS > 20 || ROWS > 20 || COLS == 0 || ROWS == 0)
                {
                    MessageBox.Show("The grid must be greater than 0 and " +
                                "less than or equal to 20.",
                                "Information",
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
                    GENERATED = false;
                    txtCols.Focus();
                }
                else
                {
                    DrawGrid(COLS, ROWS);
                    GENERATED = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please provide valid data for " +
                                "rows and columns(Both must be integers).", 
                                "Error: " + ex.Message,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                GENERATED = false;
            }            
        }
        /// <summary>
        /// Dynamically draw a grid with the values ​​of 
        /// rows and columns entered from the user.
        /// </summary>
        /// <param name="iCols">Columns to be drawn</param>
        /// <param name="iRows">Rows to be drawn</param>
        private void DrawGrid(int iCols, int iRows)
        {           
            if ((iCols > 0) && (iRows > 0))
            {
                // Find the size of a grid to be drawn.
                int gridSize = this.Panel.Width / iCols;

                // Adjust the size of the grid 
                // if total size larger than the panel size 
                while ((gridSize * iRows) > this.Panel.Height)
                {
                    gridSize--;
                }

                // Find start position x, y to be drawn
                // To display the grid in the center of the panel
                int startX = (this.Panel.Width - (gridSize * iCols)) / 2;
                int startY = (this.Panel.Height - (gridSize * iRows)) / 2;
                
                for (int y = 0; y < iRows; y++)
                {
                    for (int x = 0; x < iCols; x++)
                    {
                        // Create a tile with properties
                        Tile aTile = new Tile
                        {
                            Height = gridSize,
                            Width = gridSize,

                            Location =
                            new System.Drawing.Point(gridSize * x + startX,
                            gridSize * y + startY),

                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BorderStyle = BorderStyle.Fixed3D,

                            ROW = y,
                            COL = x
                        };

                        // Added event
                        aTile.Click += GridCell_Click;

                        try
                        {
                            this.Panel.Controls.Add(aTile);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
            Tile btnDynamic = (Tile)sender;
            int contentType = -1;

            switch (imageType)
            {
                case ImageType.NONE:
                    btnDynamic.Image = null;
                    contentType = (int)ImageType.NONE;
                    break;
                case ImageType.HERO:
                    btnDynamic.Image = Properties.Resources.hero;                 
                    contentType = (int)ImageType.HERO;
                    break;
                case ImageType.WALL:
                    btnDynamic.Image = Properties.Resources.wall;
                    contentType = (int)ImageType.WALL;
                    break;
                case ImageType.BOX:
                    btnDynamic.Image = Properties.Resources.box;
                    contentType = (int)ImageType.BOX;
                    break;
                case ImageType.GOAL:
                    btnDynamic.Image = Properties.Resources.goal;
                    contentType = (int)ImageType.GOAL;
                    break;
                default:
                    break;
            }
            btnDynamic.TOOLTYPE = contentType;
        }
        /// <summary>
        /// Store the none type button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNone_Click(object sender, EventArgs e)
        {
            imageType = ImageType.NONE;
        }
        /// <summary>
        /// Store the hero type button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHero_Click(object sender, EventArgs e)
        {
            imageType = ImageType.HERO;
        }
        /// <summary>
        /// Store the wall type button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWall_Click(object sender, EventArgs e)
        {
            imageType = ImageType.WALL;
        }
        /// <summary>
        /// Store the box type button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBox_Click(object sender, EventArgs e)
        {
            imageType = ImageType.BOX;
        }
        /// <summary>
        /// Store the destination type button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGoal_Click(object sender, EventArgs e)
        {
            imageType = ImageType.GOAL;
        }
        /// <summary>
        /// Call the Save File dialog box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!GENERATED)
            {
                MessageBox.Show("The grid was not created.", 
                                "Error",
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                btnGenerate.Focus();
            }
            else
            {
                DialogResult r = saveFileDialog1.ShowDialog();
                switch (r)
                {
                    case DialogResult.OK:
                        try
                        {
                            string filename = saveFileDialog1.FileName;
                            saveFile(filename);
                            MessageBox.Show("File saved successfully ", 
                                            "Success",
                                            MessageBoxButtons.OK, 
                                            MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error in file save", 
                                            "Error: " + ex.Message, 
                                            MessageBoxButtons.OK, 
                                            MessageBoxIcon.Error);
                        }
                        break;
                    default:
                        break;
                } 
            }
        }
        /// <summary>
        /// Create a file with each tile information.
        /// </summary>
        /// <param name="fileName">Filename that received from user </param>
        private void saveFile(string fileName)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName);

                sw.WriteLine(ROWS);
                sw.WriteLine(COLS);

                foreach (Control ctl in this.Panel.Controls)
                {
                    if (ctl is PictureBox)
                    {
                        Tile tile = (Tile)ctl;
                        sw.WriteLine(tile.ROW);
                        sw.WriteLine(tile.COL);
                        sw.WriteLine(tile.TOOLTYPE);
                    }
                }

                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

/* MainForm.cs
 * Assignment 2
 * Control form for design, play, and exit
 * 
 * Revision History
 *      $ Heuijin Ko, Sept 15, 2019: Created 
 *      $ Heuijin Ko, Oct 24, 2019: Revised 
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

namespace HKAssignment2
{
    /// <summary>
    /// A class for Main Pannel form.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Constructor of the form.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Call the design form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDesign_Click(object sender, EventArgs e)
        {
            DesignForm DF = new DesignForm();
            DF.ShowDialog();
        }
        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Call the game form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            PlayGame.PlayForm PF = new PlayGame.PlayForm();
            PF.Show();
        }
    }
}

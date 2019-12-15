/* Tile.cs
 * Assignment 3
 * Class that contains information for each tile
 * 
 * Revision History
 *      $ Heuijin Ko, Sept 18, 2019: Created 
 *      
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKoAssignment3
{
    /// <summary>
    /// Contains an each tile information 
    /// </summary>
    public class Tile : PictureBox
    {
        public int ROW { get; set; }
        public int COL { get; set; }
        public int TOOLTYPE { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Tile()
        {
            ROW = 0;
            COL = 0;
            TOOLTYPE = 0;
        }
    }
}

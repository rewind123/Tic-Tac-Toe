using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// values of each box in the current game
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        ///  cell not in use
        /// </summary>
        Free,
        /// <summary>
        /// cell contains 0
        /// </summary>
        Zero,
        /// <summary>
        /// cell contains an X
        /// </summary>
        Cross
    }
}

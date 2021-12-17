using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    class Vector
    {
        /// <summary>
        /// Entity X Coordinates
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Entity Y Coordinates
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Entity coordinates constructor
        /// </summary>
        /// <param name="x">The x coordinates</param>
        /// <param name="y">The y coordinates</param>
        public Vector(int x, int y)
        {
            // Initialize the `X` coordinates with the given value
            X = x;

            // Initialize the `Y` coordinates with the given value
            Y = y;
        }
    }
}

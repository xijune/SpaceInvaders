/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : This class is used for vectors

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class Vector
    /// </summary>
    class Vector
    {
        #region Attributs
        #endregion

        #region Propriétés des attributs
        /// <summary>
        /// Entity X Coordinates
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Entity Y Coordinates
        /// </summary>
        public int Y { get; set; }
        #endregion

        #region Constructeurs
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
        #endregion

        #region Methodes
        #endregion
    }
}

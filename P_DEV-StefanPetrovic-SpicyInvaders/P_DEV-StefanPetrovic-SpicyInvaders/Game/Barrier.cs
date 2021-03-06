/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : Barrier Class corresponds to an ingame barrier object

using System;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class Barrier
    /// </summary>
    class Barrier
    {
        #region Attributs
        /// <summary>
        /// Barrier Height
        /// </summary>
        const int _BARRIER_HEIGHT = 4;
        /// <summary>
        /// Barrier Width
        /// </summary>
        const int _BARRIER_WIDTH = 8;
        /// <summary>
        /// Barrier sprite
        /// </summary>
        private string[] _sprite;
        /// <summary>
        /// Barrier Grid
        /// </summary>
        private int[][] _barrierGrid;
        /// <summary>
        /// The coordinate for the ship
        /// </summary>
        private Vector _coordinates;
        #endregion

        #region Propriétés des attributs
        /// <summary>
        /// The coordinate for the ship
        /// </summary>
        public Vector Coordinates => _coordinates;
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructor for the barrier class
        /// </summary>
        /// <param name="x">The starting x position</param>
        /// <param name="y">The starting y position</param>
        public Barrier(int x, int y)
        {
            _sprite = new string[4]
            {
                "  ▄▄▄▄  ",
                "▄██████▄",
                "██▀▀▀▀██",
                "▀      ▀"
            };

            _coordinates = new Vector(x, y);

            _barrierGrid = new int[_BARRIER_HEIGHT][];

            for (int i = 0; i < _BARRIER_HEIGHT; i++)
            {
                _barrierGrid[i] = new int[_BARRIER_WIDTH];

                for (int j = 0; j < _BARRIER_WIDTH; j++)
                {
                    _barrierGrid[i][j] = _sprite[i][j] == ' ' ? 0 : 1;
                }
            }
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Set's the color for the barriers
        /// </summary>
        public void SetColor()
        {
            for (int i = 0; i < _BARRIER_HEIGHT; i++)
            {
                Buffer.WriteWithColor(0, _coordinates.Y + i - 1, " ", ConsoleColor.Green);
            }
        }

        /// <summary>
        /// Writes the barriers to the buffer
        /// </summary>
        public void Write()
        {
            // Set the color to green
            Buffer.SetColor(ConsoleColor.Green);

            for (int i = 0; i < _BARRIER_HEIGHT; i++)
            {
                Buffer.Delete(_coordinates.X, _coordinates.Y + i - 1, _sprite[i]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myValue"></param>
        /// <param name="myMin"></param>
        /// <param name="myMax"></param>
        /// <returns></returns>
        public int Clamp(int myValue, int myMin, int myMax)
        {
            if (myMin <= myValue && myValue <= myMax) { return myValue; }
            if (myValue < myMin) { return myMin; }
            if (myValue > myMax) { return myMax; }
            else { return 0; }
        }

        /// <summary>
        /// Returns true if the bullet is on the same position as an undestroyed piece of barrier
        /// </summary>
        /// <param name="bulletCoordinate">The bullet coordinate</param>
        /// <returns>True if the bullet is on the same position as an undestroyed piece of barrier</returns>
        public bool IsNotDestroyed(Vector bulletCoordinate) =>
            bulletCoordinate.X >= _coordinates.X &&
            bulletCoordinate.X < _coordinates.X + _BARRIER_WIDTH &&
            (_barrierGrid[Clamp(bulletCoordinate.Y - _coordinates.Y + 1, 0, 3)][bulletCoordinate.X - _coordinates.X] == 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bulletCoordinate">The bullet coordinate</param>
        public void SetDestroyed(Vector bulletCoordinate)
        {
            _barrierGrid[Clamp(bulletCoordinate.Y - _coordinates.Y + 1, 0, 3)][bulletCoordinate.X - _coordinates.X] = 0;
        }
        #endregion
    }
}

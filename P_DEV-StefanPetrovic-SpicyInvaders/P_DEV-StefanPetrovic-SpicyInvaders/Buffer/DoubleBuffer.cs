/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : Class for the doubleBuffer

using System;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class DoubleBuffer
    /// </summary>
    class DoubleBuffer
    {
        #region Attributs
        /// <summary>
        /// Current pixel
        /// </summary>
        public Pixel[,] current;
        /// <summary>
        /// Next pixel
        /// </summary>
        private Pixel[,] _next;
        /// <summary>
        /// Aux pixel
        /// </summary>
        private Pixel[,] _aux;
        /// <summary>
        /// Current chars
        /// </summary>
        private char[] _charsCurrent;
        #endregion

        #region Propriétés des attributs
        /// <summary>
        /// XDim
        /// </summary>
        public int XDim => _next.GetLength(0);
        /// <summary>
        /// YDim
        /// </summary>
        public int YDim => _next.GetLength(1);
        /// <summary>
        /// Pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Pixel this[int x, int y]
        {
            get => current[x, y];
            set => _next[x, y] = value;
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructor for the doubleBuffer class
        /// </summary>
        /// <param name="x">The starting x position</param>
        /// <param name="y">The starting y position</param>
        public DoubleBuffer(int x, int y)
        {
            current = new Pixel[x, y];
            _next = new Pixel[x, y];

            _charsCurrent = new char[x];

            Clear();
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Clear method
        /// </summary>
        public void Clear()
        {
            Array.Clear(_next, 0, XDim * YDim - 1);
            Array.Clear(current, 0, XDim * YDim - 1);

            for (int i = 0; i < YDim; i++)
            {
                for (int j = 0; j < XDim; j++)
                {
                    _next[j, i].pixelChar = ' ';
                    current[j, i].pixelChar = ' ';
                    _charsCurrent[i] = ' ';
                }

                Console.WriteLine(_charsCurrent);
            }
        }
        /// <summary>
        /// Swap method
        /// </summary>
        public void Swap()
        {
            _aux = current;
            current = _next;
            _next = _aux;
        }
        /// <summary>
        /// Display method
        /// </summary>
        public void Display()
        {
            Console.SetCursorPosition(0, 0);

            ConsoleColor currentForeground = ConsoleColor.White;

            for (int y = 0; y < YDim; y++)
            {
                if (!current[0, y].pixelColor.Equals(currentForeground))
                {
                    currentForeground = current[0, y].pixelColor;
                    Console.ForegroundColor = currentForeground;
                }

                for (int x = 0; x < XDim; x++)
                {
                    _charsCurrent[x] = current[x, y].pixelChar;
                }
                Console.WriteLine(_charsCurrent);
            }
        }
        #endregion
    }
}

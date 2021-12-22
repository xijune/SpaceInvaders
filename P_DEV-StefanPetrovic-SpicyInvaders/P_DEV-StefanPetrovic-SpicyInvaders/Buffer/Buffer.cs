/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : Class for the buffer

using System;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class Buffer
    /// </summary>
    class Buffer
    {
        #region Attributs
        /// <summary>
        /// Instantiate a new double buffer
        /// </summary>
        private static DoubleBuffer buffer2D = new DoubleBuffer(100, 59);
        /// <summary>
        /// Instantiate a new default pixel
        /// </summary>
        private static Pixel currentPixel = new Pixel();
        #endregion

        #region Propriétés des attributs
        #endregion

        #region Constructeurs
        #endregion

        #region Methodes
        /// <summary>
        /// Writes to the console
        /// </summary>
        /// <param name="x">String x position</param>
        /// <param name="y">String Y position</param>
        /// <param name="str">What to write in that location</param>
        public static void Write(int x, int y, string str)
        {
            // Goes through every char on the given string
            for (int i = 0; i < str.Length; i++)
            {
                // Set's the char for the current pixel
                currentPixel.pixelChar = str[i];

                // Writes that pixel to the buffer
                buffer2D[x + i, y] = currentPixel;
            }
        }

        /// <summary>
        /// Delete a string from the current buffer
        /// </summary>
        /// <param name="x">String x position</param>
        /// <param name="y">String Y position</param>
        /// <param name="str">The string</param>
        public static void Delete(int x, int y, string str)
        {
            // Goes through every char on the given string
            for (int i = 0; i < str.Length; i++)
            {
                // Set's the char for the current pixel
                currentPixel.pixelChar = str[i];

                // Writes that pixel to the buffer
                buffer2D.current[x + i, y] = currentPixel;
            }

            // Write to the buffer
            Buffer.Write(x, y, str);
        }

        /// <summary>
        /// Set the pixel color to a specific color
        /// </summary>
        /// <param name="color">The color to set it to</param>
        public static void SetColor(ConsoleColor color)
        {
            // Set the pixel color to the `color` color
            currentPixel.pixelColor = color;
        }

        /// <summary>
        /// Writes to the buffer with a specific color
        /// </summary>
        /// <param name="coordinate">The location to write to</param>
        /// <param name="str">What to write in that location</param>
        /// <param name="color">What color to write in</param>
        public static void WriteWithColor(int x, int y, string str, ConsoleColor color)
        {
            // Set's the color to write
            SetColor(color);

            // Writes to the buffer in the given position
            Write(x, y, str);
        }

        /// <summary>
        /// Displays what was written to the buffer
        /// </summary>
        public static void DisplayRender()
        {
            // Swap buffer to write and display
            buffer2D.Swap();

            // Display what was written to the buffer
            buffer2D.Display();
        }

        /// <summary>
        /// Clears the 'next' frame to be rendered
        /// </summary>
        public static void ClearBuffer()
        {
            // Clear the buffer
            buffer2D.Clear();
        }
        #endregion
    }
}

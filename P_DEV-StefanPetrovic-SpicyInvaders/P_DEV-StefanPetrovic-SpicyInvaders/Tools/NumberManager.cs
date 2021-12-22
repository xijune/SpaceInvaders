/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : This class manage all the number that will be displayed in game and displays them when necessary

using System;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class NumberManager
    /// </summary>
    public static class NumberManager
    {
        #region Attributs
        /// <summary>
        /// Number rows
        /// </summary>
        const int _NUMBER_ROWS = 3;
        /// <summary>
        /// Score X position
        /// </summary>
        const int _SCORE_X_POS = 8;
        /// <summary>
        /// Life X position
        /// </summary>
        const int _LIFES_X_POS = 87;
        /// <summary>
        /// Level X position
        /// </summary>
        const int _LEVELS_X_POS = 52;

        /// <summary>
        /// Sprite for the number 0
        /// </summary>
        private static string[] _zero = new string[] {
            "╔╗",
            "║║",
            "╚╝" };

        /// <summary>
        /// Sprite for the number 1
        /// </summary>
        private static string[] _one = new string[] {
            " ╗",
            " ║",
            " ╩"};

        /// <summary>
        /// Sprite for the number 2
        /// </summary>
        private static string[] _two = new string[] {
            "╔╗",
            "╔╝",
            "╚╝"};

        /// <summary>
        /// Sprite for the number 3
        /// </summary>
        private static string[] _three = new string[] {
            "╔╗",
            " ╣",
            "╚╝"};

        /// <summary>
        /// Sprite for the number 4
        /// </summary>
        private static string[] _four = new string[] {
            "╗╗",
            "╚╣",
            " ╩"};

        /// <summary>
        /// Sprite for the number 5
        /// </summary>
        private static string[] _five = new string[] {
            "╔╗",
            "╚╗",
            "╚╝"};

        /// <summary>
        /// Sprite for the number 6
        /// </summary>
        private static string[] _six = new string[] {
            "╔╗",
            "╠╗",
            "╚╝"};

        /// <summary>
        /// Sprite for the number 7
        /// </summary>
        private static string[] _seven = new string[] {
            "╔╗",
            " ║",
            " ╩"};

        /// <summary>
        /// Sprite for the number 8
        /// </summary>
        private static string[] _eight = new string[] {
            "╔╗",
            "╠╣",
            "╚╝"};

        /// <summary>
        /// Sprite for the number 9
        /// </summary>
        private static string[] _nine = new string[] {
            "╔╗",
            "╚╣",
            " ╩"};

        /// <summary>
        /// Creates a new string array of arrays to save all the number sprites
        /// </summary>
        private static string[][] digits = new string[][]
        { _zero, _one, _two, _three, _four, _five, _six, _seven, _eight, _nine};
        #endregion

        #region Propriétés des attributs
        #endregion

        #region Constructeurs
        #endregion

        #region Methodes
        /// <summary>
        /// Write the score to the buffer
        /// </summary>
        /// <param name="score">The current score the player has</param>
        public static void WriteScore(int score)
        {
            // Write the score to the buffer
            Write(score, 6, _SCORE_X_POS);
        }

        /// <summary>
        /// Delete the score on the buffer
        /// </summary>
        public static void DeleteScore()
        {
            // Delete the score from the buffer
            Delete(6, _SCORE_X_POS);
        }

        /// <summary>
        /// Write the number of lifes to the buffer
        /// </summary>
        /// <param name="lifes">The current number of lifes the player has</param>
        public static void WriteLifes(int lifes)
        {
            // Write the number of lifes to the buffer
            Write(lifes, 0, _LIFES_X_POS);
        }

        /// <summary>
        /// Delete the lifes on the buffer
        /// </summary>
        public static void DeleteLifes()
        {
            // Delete the number of lifes from the buffer
            Delete(0, _LIFES_X_POS);
        }

        /// <summary>
        /// Write the current level the player is in to the buffer
        /// </summary>
        /// <param name="level">The current level the player is in</param>
        public static void WriteLevel(int level)
        {
            // Write the current level the player is in to the buffer
            Write(level, 2, _LEVELS_X_POS);
        }

        /// <summary>
        /// Delete the number of levels the buffer
        /// </summary>
        public static void DeleteLevel()
        {
            // Delete the number of levels from the buffer
            Delete(2, _LEVELS_X_POS);
        }

        /// <summary>
        /// Writes all numbers to the buffer
        /// </summary>
        /// <param name="value">The value it self (number of lifes, score, etc...)</param>
        /// <param name="format">Used to know how many numbers will represent the value</param>
        /// <param name="x">The X position to write the numbers</param>
        private static void Write(int value, int format, int x)
        {
            // Save the passed value into a string
            string numberstr = value.ToString();

            // Create a new int `xOffset`
            int xOffset = 0;

            // If the length of the string is less than the format
            if (numberstr.Length < format)
            {
                // Loop the ammount of time necessary
                for (int i = 0; i < format - numberstr.Length; i++)
                {
                    // Write the number 0
                    WriteNumber(0, xOffset, x);

                    // Increase the x offset by 2
                    xOffset += 2;
                }
            }

            // Goes through every char on the `numberstr` string
            for (int i = 0; i < numberstr.Length; i++)
            {
                // Cause we know the string only has numbers convert each char back to a int
                // To be written to the buffer
                WriteNumber(int.Parse(numberstr[i].ToString()), xOffset, x);

                // Increase the x offset by 2
                xOffset += 2;
            }
        }

        /// <summary>
        /// Deletes the number from the buffer
        /// </summary>
        /// <param name="format">Used to know how many numbers will represent the value</param>
        /// <param name="x">The X position to write the numbers</param>
        private static void Delete(int format, int x)
        {
            // Create a new int `xOffset`
            int xOffset = 0;

            // Loops the ammount of numbers
            for (int i = 0; i <= format; i++)
            {
                // Loops the ammount of rows
                for (int j = 0; j < _NUMBER_ROWS; j++)
                {
                    // Deletes the number from the buffer
                    Buffer.Delete(x + xOffset, j + 2, "  ");
                }

                // Increase the x offset by 2
                xOffset += 2;
            }
        }

        /// <summary>
        /// Writes the number to the buffer
        /// </summary>
        /// <param name="value">
        /// The value it self (number of lifes, score, etc...)</param>
        /// <param name="xOffset">
        /// Offset the number to the right depending on the number of numbers</param>
        /// <param name="x">The x value where the number will be displayed</param>
        private static void WriteNumber(int value, int xOffset, int x)
        {
            // Loops 3 times...
            for (int i = 0; i < _NUMBER_ROWS; i++)
            {
                // Change the color depending on the row
                Buffer.WriteWithColor(0, i + 2, " ", i == 0 ?
                    ConsoleColor.White :
                    i == 1 ?
                    ConsoleColor.Blue :
                    ConsoleColor.DarkBlue);

                // Write each string to the buffer
                Buffer.Write(x + xOffset, i + 2, digits[value][i]);
            }
        }
        #endregion
    }
}

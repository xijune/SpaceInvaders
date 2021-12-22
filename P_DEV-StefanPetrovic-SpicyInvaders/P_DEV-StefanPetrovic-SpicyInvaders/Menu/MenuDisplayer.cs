/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : Display Text to menus

using System;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class MenuDisplayer
    /// </summary>
    public class MenuDisplayer
    {
        #region Attributs
        /// <summary>
        /// Constant of the Y value to render the selection button
        /// </summary>
        private const int Y_SELECTION = 15;
        /// <summary>
        /// Constant of the X value to render all button
        /// </summary>
        private const int X_SELECTION = 38;
        /// <summary>
        /// Constant of the Y value to render the play button
        /// </summary>
        private const int PLAY_Y_SELECTION = 9;
        /// <summary>
        /// Constant of the Y value to render the score button
        /// </summary>
        private const int SCORE_Y_SELECTION = 12;
        /// <summary>
        /// Constant of the Y value to render the about button
        /// </summary>
        private const int ABOUT_Y_SELECTION = 15;
        /// <summary>
        /// Constant of the Y value to render the option button
        /// </summary>
        private const int OPTION_Y_SELECTION = 18;
        /// <summary>
        /// Constant of the Y value to render the exit button
        /// </summary>
        private const int EXIT_Y_SELECTION = 21;
        #endregion

        #region Propriétés des attributs
        #endregion

        #region Constructeurs
        #endregion

        #region Methodes
        /// <summary>
        /// PlayButton method
        /// </summary>
        /// <param name="i">int</param>
        /// <param name="a">ConsoleColor</param>
        public static void PlayButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + PLAY_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + PLAY_Y_SELECTION + i, Sprites.playString[i]);
        }
        /// <summary>
        /// ScoreButton method
        /// </summary>
        /// <param name="i">int</param>
        /// <param name="a">ConsoleColor</param>
        public static void ScoreButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + SCORE_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + SCORE_Y_SELECTION + i, Sprites.scoreString[i]);
        }
        /// <summary>
        /// AboutButton method
        /// </summary>
        /// <param name="i">int</param>
        /// <param name="a">ConsoleColor</param>
        public static void AboutButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + ABOUT_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + ABOUT_Y_SELECTION + i, Sprites.aboutString[i]);
        }
        /// <summary>
        /// OptionButton method
        /// </summary>
        /// <param name="i">int</param>
        /// <param name="a">ConsoleColor</param>
        public static void OptionButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + OPTION_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + OPTION_Y_SELECTION + i, Sprites.optionString[i]);
        }
        /// <summary>
        /// ExitButton method
        /// </summary>
        /// <param name="i">int</param>
        /// <param name="a">ConsoleColor</param>
        public static void ExitButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + EXIT_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + EXIT_Y_SELECTION + i, Sprites.exitString[i]);
        }
        /// <summary>
        /// DifficultyButton method
        /// </summary>
        /// <param name="i">int</param>
        /// <param name="a">ConsoleColor</param>
        public static void DifficultyButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + ABOUT_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + ABOUT_Y_SELECTION + i, Sprites.difficultyString[i]);
        }
        /// <summary>
        /// EasyButton method
        /// </summary>
        /// <param name="i">int</param>
        /// <param name="a">ConsoleColor</param>
        public static void EasyButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + 2 + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + 2 + i, Sprites.easyString[i]);
        }
        /// <summary>
        /// HardButton method
        /// </summary>
        /// <param name="i">int</param>
        /// <param name="a">ConsoleColor</param>
        public static void HardButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + 2 + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + 2 + i, Sprites.hardString[i]);
        }
        /// <summary>
        /// SoundButton method
        /// </summary>
        /// <param name="i">int</param>
        /// <param name="a">ConsoleColor</param>
        public static void SoundButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + PLAY_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + PLAY_Y_SELECTION + i, Sprites.soundString[i]);
        }
        /// <summary>
        /// OnButton method
        /// </summary>
        /// <param name="i">int</param>
        /// <param name="a">ConsoleColor</param>
        public static void OnButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + 2 + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + 2 + i, Sprites.onString[i]);
        }
        /// <summary>
        /// OffButton method
        /// </summary>
        /// <param name="i">int</param>
        /// <param name="a">ConsoleColor</param>
        public static void OffButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + 2 + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + 2 + i, Sprites.offString[i]);
        }
        /// <summary>
        /// ClearOnEasy method
        /// </summary>
        /// <param name="i">int</param>
        public static void ClearOnEasy(int i)
        {
            Buffer.Write(X_SELECTION, Y_SELECTION + 2 + i, "                      ");
        }
        /// <summary>
        /// AboutInfos method
        /// </summary>
        /// <param name="i">int</param>
        /// <param name="a">ConsoleColor</param>
        public static void AboutInfos(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + i, " ", a);
            Buffer.Write(15, Y_SELECTION + i, Sprites.aboutinfo[i]);
        }
        #endregion
    }
}

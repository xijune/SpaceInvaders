/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : Display Text to menus

using System;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    public class MenuDisplayer
    {
        #region Attributs
        // Constant of the Y value to render the selection button
        private const int Y_SELECTION = 15;
        // Constant of the X value to render all button
        private const int X_SELECTION = 38;
        // Constant of the Y value to render the play button
        private const int PLAY_Y_SELECTION = 9;
        // Constant of the Y value to render the score button
        private const int SCORE_Y_SELECTION = 12;
        // Constant of the Y value to render the about button
        private const int ABOUT_Y_SELECTION = 15;
        // Constant of the Y value to render the option button
        private const int OPTION_Y_SELECTION = 18;
        // Constant of the Y value to render the exit button
        private const int EXIT_Y_SELECTION = 21;
        #endregion

        #region Propriétés des attributs
        #endregion

        #region Constructeurs
        #endregion

        #region Methodes
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a"></param>
        public static void PlayButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + PLAY_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + PLAY_Y_SELECTION + i, Sprites.playString[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a"></param>
        public static void ScoreButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + SCORE_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + SCORE_Y_SELECTION + i, Sprites.scoreString[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a"></param>
        public static void AboutButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + ABOUT_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + ABOUT_Y_SELECTION + i, Sprites.aboutString[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a"></param>
        public static void OptionButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + OPTION_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + OPTION_Y_SELECTION + i, Sprites.optionString[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a"></param>
        public static void ExitButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + EXIT_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + EXIT_Y_SELECTION + i, Sprites.exitString[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a"></param>
        public static void DifficultyButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + ABOUT_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + ABOUT_Y_SELECTION + i, Sprites.difficultyString[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a"></param>
        public static void EasyButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + 2 + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + 2 + i, Sprites.easyString[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a"></param>
        public static void HardButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + 2 + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + 2 + i, Sprites.hardString[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a"></param>
        public static void SoundButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + PLAY_Y_SELECTION + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + PLAY_Y_SELECTION + i, Sprites.soundString[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a"></param>
        public static void OnButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + 2 + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + 2 + i, Sprites.onString[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a"></param>
        public static void OffButton(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + 2 + i, " ", a);
            Buffer.Write(X_SELECTION, Y_SELECTION + 2 + i, Sprites.offString[i]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        public static void ClearOnEasy(int i)
        {
            Buffer.Write(X_SELECTION, Y_SELECTION + 2 + i, "                      ");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a"></param>
        public static void AboutInfos(int i, ConsoleColor a)
        {
            Buffer.WriteWithColor(0, Y_SELECTION + i, " ", a);
            Buffer.Write(15, Y_SELECTION + i, Sprites.aboutinfo[i]);
        }
        #endregion
    }
}

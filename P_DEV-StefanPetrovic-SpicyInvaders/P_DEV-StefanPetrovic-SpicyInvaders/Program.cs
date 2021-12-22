/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : Main program

using System;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class Program
    /// </summary>
    class Program
    {
        #region Attributs
        #endregion

        #region Propriétés des attributs
        #endregion

        #region Constructeurs
        #endregion

        #region Methodes
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Hides the console cursor to not be visible
            //Console.CursorVisible = false;

            // Set the window size for the console
            Console.SetWindowSize(101, 60);

            // Instantiate a new Menu
            Menu menu = new Menu();

            // Render the menu
            menu.RenderMenu();
        }
        #endregion
    }
}

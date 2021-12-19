using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    public class AboutMenu
    {
        #region Attributs
        // Constant of the X value to render all button
        private const int _X_SELECTION = 38;
        // If the quit button is selected
        private bool _exitSelected;
        // If the option menu is selected
        private bool _isAbout;
        #endregion

        #region Propriétés des attributs
        public bool ExitSelected
        {
            get
            {
                return _exitSelected;
            }
            set
            {
                _exitSelected = value;
            }
        }
        public bool IsAbout
        {
            get
            {
                return _isAbout;
            }
            set
            {
                _isAbout = value;
            }
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructor for the menu class
        /// </summary>
        public AboutMenu()
        {
            // The exit button selected
            _exitSelected = true;
            // The about menu selected
            _isAbout = true;
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Renders all the sprites in the menu
        /// </summary>
        public void RenderMenu()
        {
            while (_isAbout)
            {
                // Display Title
                for (int i = 0; i < Sprites.titleAboutString.Length; i++)
                {
                    Buffer.WriteWithColor(0, 5 + i, " ", ConsoleColor.Yellow);
                    Buffer.Write(_X_SELECTION - 6, 5 + i, Sprites.titleAboutString[i]);
                }
                // Display Buttons
                for (int i = 0; i < Sprites.playString.Length; i++)
                {
                    MenuDisplayer.ExitButton(i, ConsoleColor.White);
                }
                // Display Texts
                for (int i = 0; i < Sprites.aboutinfo.Length; i++)
                {
                    MenuDisplayer.AboutInfos(i, ConsoleColor.White);
                }
                // Display Button Selector
                for (int i = 0; i < Sprites.playString.Length; i++)
                {
                    // If we have the quit button selected
                    if (_exitSelected)
                    {
                        MenuDisplayer.ExitButton(i, ConsoleColor.Red);
                    }
                }
                // Tells the double buffer to render the frame
                Buffer.DisplayRender();
                // Gets the input from the user
                GetInput();
            }
            // Clears the buffer
            Buffer.ClearBuffer();
        }
        /// <summary>
        /// Check the input from the user
        /// </summary>
        private void GetInput()
        {
            // Check what's the user input
            switch (Console.ReadKey(true).Key)
            {
                // If the user pressed the down arrow key
                case ConsoleKey.DownArrow:
                    // If the exit button is selected
                    if (_exitSelected)
                    {
                        // Change what button is selected
                        _exitSelected = true;
                    }
                    break;
                // If the user pressed the up arrow key
                case ConsoleKey.UpArrow:
                    // If the exit button is selected
                    if (_exitSelected)
                    {
                        // Change what button is selected
                        _exitSelected = true;
                    }
                    break;
                // If the user pressed enter
                case ConsoleKey.Enter:
                    // If the exit button is selected
                    if (_exitSelected)
                    {
                        // Change what menu is selected
                        _isAbout = false;
                    }
                    break;
            }
            // Render the menu
            RenderMenu();
        }
        #endregion
    }
}

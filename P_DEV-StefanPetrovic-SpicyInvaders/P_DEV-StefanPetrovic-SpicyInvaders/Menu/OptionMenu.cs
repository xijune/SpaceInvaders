/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : Option Menu

using System;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class OptionMenu
    /// </summary>
    public class OptionMenu
    {
        #region Attributs
        /// <summary>
        /// Constant of the X value to render all button
        /// </summary>
        private const int _X_SELECTION = 38;
        /// <summary>
        /// If the quit button is selected
        /// </summary>
        private bool _exitSelected;
        /// <summary>
        /// If the sound button is selected
        /// </summary>
        private bool _soundSelected;
        /// <summary>
        /// If the difficulty button is selected
        /// </summary>
        private bool _difficultySelected;
        /// <summary>
        /// If the sound is on selected
        /// </summary>
        private bool _onSelected;
        /// <summary>
        /// If the sound is off selected
        /// </summary>
        private bool _offSelected;
        /// <summary>
        /// If the option menu is selected
        /// </summary>
        private bool _easySelected;
        /// <summary>
        /// If the option menu is selected
        /// </summary>
        private bool _hardSelected;
        /// <summary>
        /// If the option menu is selected
        /// </summary>
        private bool _isOption;
        #endregion

        #region Propriétés des attributs
        /// <summary>
        /// Getter, setter on _exitSelected
        /// </summary>
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
        /// <summary>
        /// Getter, setter on _soundSelected
        /// </summary>
        public bool SoundSelected
        {
            get
            {
                return _soundSelected;
            }
            set
            {
                _soundSelected = value;
            }
        }
        /// <summary>
        /// Getter, setter on _difficultySelected
        /// </summary>
        public bool DifficultySelected
        {
            get
            {
                return _difficultySelected;
            }
            set
            {
                _difficultySelected = value;
            }
        }
        /// <summary>
        /// Getter, setter on _isOption
        /// </summary>
        public bool IsOption
        {
            get
            {
                return _isOption;
            }
            set
            {
                _isOption = value;
            }
        }
        /// <summary>
        /// Getter, setter on _onSelected
        /// </summary>
        public bool OnSelected
        {
            get
            {
                return _onSelected;
            }
            set
            {
                _onSelected = value;
            }
        }
        /// <summary>
        /// Getter, setter on _offSelected
        /// </summary>
        public bool OffSelected
        {
            get
            {
                return _offSelected;
            }
            set
            {
                _offSelected = value;
            }
        }
        /// <summary>
        /// Getter, setter on _easySelected
        /// </summary>
        public bool EasySelected
        {
            get
            {
                return _easySelected;
            }
            set
            {
                _easySelected = value;
            }
        }
        /// <summary>
        /// Getter, setter on _hardSelected
        /// </summary>
        public bool HardSelected
        {
            get
            {
                return _hardSelected;
            }
            set
            {
                _hardSelected = value;
            }
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructor for the menu class
        /// </summary>
        public OptionMenu()
        {
            // The sound button selected
            _soundSelected = true;

            // The difficulty button unselected
            _difficultySelected = false;

            // The exit button unselected
            _exitSelected = false;

            // The option menu selected
            _isOption = true;

            // The sound on selected
            _onSelected = true;

            // The difficulty easy selected
            _easySelected = true;
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Renders all the sprites in the menu
        /// </summary>
        public void RenderMenu()
        {
            while (_isOption)
            {
                // Display Title
                for (int i = 0; i < Sprites.titleOptionString.Length; i++)
                {
                    Buffer.WriteWithColor(0, 5 + i, " ", ConsoleColor.Yellow);
                    Buffer.Write(_X_SELECTION - 6, 5 + i, Sprites.titleOptionString[i]);
                }
                // Display Buttons
                for (int i = 0; i < Sprites.playString.Length; i++)
                {
                    MenuDisplayer.SoundButton(i, ConsoleColor.White);
                    MenuDisplayer.DifficultyButton(i, ConsoleColor.White);
                    MenuDisplayer.ExitButton(i, ConsoleColor.White);
                }
                // Display Button Selector
                for (int i = 0; i < Sprites.playString.Length; i++)
                {
                    // If we have the sound button selected
                    if (_soundSelected)
                    {
                        MenuDisplayer.ClearOnEasy(i);
                        MenuDisplayer.SoundButton(i, ConsoleColor.Red);
                        MenuDisplayer.DifficultyButton(i, ConsoleColor.White);
                        // If we have the sound on selected
                        if (_onSelected)
                        {
                            MenuDisplayer.OnButton(i, ConsoleColor.DarkBlue);
                        }
                        // If we have the sound off selected
                        else if (_offSelected)
                        {
                            MenuDisplayer.OffButton(i, ConsoleColor.DarkBlue);
                        }
                    }
                    // If we have the difficulty button selected
                    else if (_difficultySelected)
                    {
                        MenuDisplayer.ClearOnEasy(i);
                        MenuDisplayer.DifficultyButton(i, ConsoleColor.Red);
                        MenuDisplayer.SoundButton(i, ConsoleColor.White);
                        MenuDisplayer.ExitButton(i, ConsoleColor.White);
                        // If we have the easy mod selected
                        if (_easySelected)
                        {
                            MenuDisplayer.EasyButton(i, ConsoleColor.DarkBlue);
                        }
                        // If we have the hard mod selected
                        else if (_hardSelected)
                        {
                            MenuDisplayer.HardButton(i, ConsoleColor.DarkBlue);
                        }
                    }
                    // If we have the quit button selected
                    else if (_exitSelected)
                    {
                        MenuDisplayer.ClearOnEasy(i);
                        MenuDisplayer.ExitButton(i, ConsoleColor.Red);
                        MenuDisplayer.DifficultyButton(i, ConsoleColor.White);
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
                    // If the sound button is selected
                    if (_soundSelected)
                    {
                        // Change what button is selected
                        _soundSelected = false;
                        _difficultySelected = true;
                    }
                    // If the difficulty button is selected
                    else if (_difficultySelected)
                    {
                        // Change what button is selected
                        _difficultySelected = false;
                        _exitSelected = true;
                    }
                    // If the exit button is selected
                    else if (_exitSelected)
                    {
                        // Change what button is selected
                        _exitSelected = true;
                    }
                    break;
                // If the user pressed the up arrow key
                case ConsoleKey.UpArrow:
                    // If the sound button is selected
                    if (_soundSelected)
                    {
                        // Change what button is selected
                        _soundSelected = true;
                    }
                    // If the difficulty button is selected
                    else if (_difficultySelected)
                    {
                        // Change what button is selected
                        _difficultySelected = false;
                        _soundSelected = true;
                    }
                    // If the exit button is selected
                    else if (_exitSelected)
                    {
                        // Change what button is selected
                        _exitSelected = false;
                        _difficultySelected = true;
                    }
                    break;
                // If the user pressed enter
                case ConsoleKey.Enter:
                    // If the sound button is selected
                    if (_soundSelected)
                    {
                        // If the sound is on
                        if (_onSelected)
                        {
                            // Change what sound is selected
                            _onSelected = false;
                            _offSelected = true;
                        }

                        // If the sound is off
                        else if (_offSelected)
                        {
                            // Change what dound is selected
                            _offSelected = false;
                            _onSelected = true;
                        }
                    }
                    // If the difficulty button is selected
                    else if (_difficultySelected)
                    {
                        // If the easy mod is selected
                        if (_easySelected)
                        {
                            // Change what mod is selected
                            _easySelected = false;
                            _hardSelected = true;
                        }
                        // If the hard mod is selected
                        else if (_hardSelected)
                        {
                            // Change what mod is selected
                            _hardSelected = false;
                            _easySelected = true;
                        }
                    }
                    // If the exit button is selected
                    else if (_exitSelected)
                    {
                        // Change what menu is selected
                        _isOption = false;
                    }
                    break;
            }
            // Render the menu
            RenderMenu();
        }
        #endregion
    }
}

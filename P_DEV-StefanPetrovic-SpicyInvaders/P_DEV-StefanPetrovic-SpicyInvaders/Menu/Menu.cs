/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : Main menu

using System;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    public class Menu
    {
        #region Attributs
        // Constant of the X value to render all button
        const int _X_SELECTION = 38;
        // If the play button is selected
        private bool _playSelected;
        // If the exit button is selected
        private bool _exitSelected;
        // If the option button is selected
        private bool _optionSelected;
        // If the about button is selected
        private bool _aboutSelected;
        // If the score button is selected
        private bool _scoreSelected;
        // Holds a game instance
        private Game _game;
        // Holds a option menu instance
        private OptionMenu _option;
        // Holds a about menu instance
        private AboutMenu _about;
        // Holds a score menu instance
        private ScoreMenu _score;
        #endregion

        #region Propriétés des attributs
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructor for the menu class
        /// </summary>
        public Menu()
        {
            // The play button starts selected
            _playSelected = true;
            // The quit button starts unselected
            _exitSelected = false;
            // The option button starts unselected
            _optionSelected = false;
            // The about button starts unselected
            _aboutSelected = false;
            // The score button starts unselected
            _scoreSelected = false;
            // Instantiate a new option menu
            _option = new OptionMenu();
            // Instantiate a new about menu
            _about = new AboutMenu();
            // Instantiate a new score menu
            _score = new ScoreMenu();
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Renders all the sprites in the menu
        /// </summary>
        public void RenderMenu()
        {
            // Display Title
            for (int i = 0; i < Sprites.titleStartString.Length; i++)
            {
                Buffer.WriteWithColor(0, 5 + i, " ", ConsoleColor.Yellow);
                Buffer.Write(_X_SELECTION - 28, 5 + i, Sprites.titleStartString[i]);
            }
            // Display Buttons
            for (int i = 0; i < Sprites.playString.Length; i++)
            {
                MenuDisplayer.PlayButton(i, ConsoleColor.White);
                MenuDisplayer.ScoreButton(i, ConsoleColor.White);
                MenuDisplayer.AboutButton(i, ConsoleColor.White);
                MenuDisplayer.OptionButton(i, ConsoleColor.White);
                MenuDisplayer.ExitButton(i, ConsoleColor.White);
            }
            // Display Button Selector
            for (int i = 0; i < Sprites.playString.Length; i++)
            {
                // If we have the play button selected
                if (_playSelected)
                {
                    MenuDisplayer.PlayButton(i, ConsoleColor.Red);
                    MenuDisplayer.ScoreButton(i, ConsoleColor.White);
                }
                // If we have the score button selected
                else if (_scoreSelected)
                {
                    MenuDisplayer.ScoreButton(i, ConsoleColor.Red);
                    MenuDisplayer.PlayButton(i, ConsoleColor.White);
                    MenuDisplayer.AboutButton(i, ConsoleColor.White);
                }
                // If we have the about button selected
                else if (_aboutSelected)
                {
                    MenuDisplayer.AboutButton(i, ConsoleColor.Red);
                    MenuDisplayer.ScoreButton(i, ConsoleColor.White);
                    MenuDisplayer.OptionButton(i, ConsoleColor.White);
                }
                // If we have the option button selected
                else if (_optionSelected)
                {
                    MenuDisplayer.OptionButton(i, ConsoleColor.Red);
                    MenuDisplayer.AboutButton(i, ConsoleColor.White);
                    MenuDisplayer.ExitButton(i, ConsoleColor.White);
                }
                // If we have the exit button selected
                else if (_exitSelected)
                {
                    MenuDisplayer.ExitButton(i, ConsoleColor.Red);
                    MenuDisplayer.OptionButton(i, ConsoleColor.White);
                }
            }
            // Tells the double buffer to render the frame
            Buffer.DisplayRender();
            // Gets the input from the user
            GetInput();
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
                    // If the score button is selected
                    if (_scoreSelected)
                    {
                        // Change what button is selected
                        _scoreSelected = false;
                        _aboutSelected = true;
                    }
                    // If the play button is selected
                    else if (_playSelected)
                    {
                        // Change what button is selected
                        _playSelected = false;
                        _scoreSelected = true;
                    }
                    // If the about button is selected
                    else if (_aboutSelected)
                    {
                        // Change what button is selected
                        _aboutSelected = false;
                        _optionSelected = true;
                    }
                    // If the option button is selected
                    else if (_optionSelected)
                    {
                        // Change what button is selected
                        _optionSelected = false;
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
                    // If the play button is selected
                    if (_playSelected)
                    {
                        // Change what button is selected
                        _playSelected = true;
                    }
                    // If the score button is selected
                    else if (_scoreSelected)
                    {
                        // Change what button is selected
                        _scoreSelected = false;
                        _playSelected = true;
                    }
                    // If the about button is selected
                    else if (_aboutSelected)
                    {
                        // Change what button is selected
                        _aboutSelected = false;
                        _scoreSelected = true;
                    }
                    // If the option button is selected
                    else if (_optionSelected)
                    {
                        // Change what button is selected
                        _optionSelected = false;
                        _aboutSelected = true;
                    }
                    // If the exit button is selected
                    else if (_exitSelected)
                    {
                        // Change what button is selected
                        _exitSelected = false;
                        _optionSelected = true;
                    }
                    break;
                // If the user pressed enter key
                case ConsoleKey.Enter:
                    // If the play button is selected
                    if (_playSelected)
                    {
                        // Instantiate a new Game
                        _game = new Game();
                        if (_option.HardSelected)
                        {
                            _game.IsHard();
                        }
                        // Start the game
                        _game.Loop();
                    }
                    // If the option button is selected
                    else if (_optionSelected)
                    {
                        // Clear the buffer from the menu render
                        Buffer.ClearBuffer();
                        // The sound button starts selected
                        _option.SoundSelected = true;
                        // The difficulty button starts unselected
                        _option.DifficultySelected = false;
                        // The exit button starts unselected
                        _option.ExitSelected = false;
                        // If it is the option menu
                        _option.IsOption = true;
                        // Render the option menu
                        _option.RenderMenu();
                    }
                    // If the about button is selected
                    else if (_aboutSelected)
                    {
                        // Clear the buffer from the menu render
                        Buffer.ClearBuffer();
                        // If it is the option menu
                        _about.IsAbout = true;
                        // Render the option menu
                        _about.RenderMenu();
                    }
                    // If the score button is selected
                    else if (_scoreSelected)
                    {
                        // Clear the buffer from the menu render
                        Buffer.ClearBuffer();
                        // If it is the option menu
                        _score.IsScore = true;
                        // Username of the last player
                        _score.UserName = _game.UserName;
                        // Score of the last player
                        _score.Score = _game.Score;
                        // Render the option menu
                        _score.RenderMenu();
                    }
                    else
                    {
                        // Exits the application
                        Environment.Exit(0);
                    }
                    break;
            }
            // Render the menu
            RenderMenu();
        }
        #endregion
    }
}

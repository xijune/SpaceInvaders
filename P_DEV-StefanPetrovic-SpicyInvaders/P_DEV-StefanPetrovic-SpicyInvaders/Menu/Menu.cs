using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    public class Menu
    {
        #region Attributs
        // Constant of the X value to render all button
        private const int X_SELECTION = 38;
        // If the play button is selected
        private bool playSelected;
        // If the exit button is selected
        private bool exitSelected;
        // If the option button is selected
        private bool optionSelected;
        // If the about button is selected
        private bool aboutSelected;
        // If the score button is selected
        private bool scoreSelected;
        // Holds a game instance
        private Game game;
        // Holds a option menu instance
        private OptionMenu option;
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
            playSelected = true;
            // The quit button starts unselected
            exitSelected = false;
            // The option button starts unselected
            optionSelected = false;
            // The about button starts unselected
            aboutSelected = false;
            // The score button starts unselected
            scoreSelected = false;
            // Instantiate a new Game
            option = new OptionMenu();
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
                Buffer.Write(X_SELECTION - 28, 5 + i, Sprites.titleStartString[i]);
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
                if (playSelected)
                {
                    MenuDisplayer.PlayButton(i, ConsoleColor.Red);
                    MenuDisplayer.ScoreButton(i, ConsoleColor.White);
                }
                // If we have the score button selected
                else if (scoreSelected)
                {
                    MenuDisplayer.ScoreButton(i, ConsoleColor.Red);
                    MenuDisplayer.PlayButton(i, ConsoleColor.White);
                    MenuDisplayer.AboutButton(i, ConsoleColor.White);
                }
                // If we have the about button selected
                else if (aboutSelected)
                {
                    MenuDisplayer.AboutButton(i, ConsoleColor.Red);
                    MenuDisplayer.ScoreButton(i, ConsoleColor.White);
                    MenuDisplayer.OptionButton(i, ConsoleColor.White);
                }
                // If we have the option button selected
                else if (optionSelected)
                {
                    MenuDisplayer.OptionButton(i, ConsoleColor.Red);
                    MenuDisplayer.AboutButton(i, ConsoleColor.White);
                    MenuDisplayer.ExitButton(i, ConsoleColor.White);
                }
                // If we have the exit button selected
                else if (exitSelected)
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
                    if (scoreSelected)
                    {
                        // Change what button is selected
                        scoreSelected = false;
                        aboutSelected = true;
                    }
                    // If the play button is selected
                    else if (playSelected)
                    {
                        // Change what button is selected
                        playSelected = false;
                        scoreSelected = true;
                    }
                    // If the about button is selected
                    else if (aboutSelected)
                    {
                        // Change what button is selected
                        aboutSelected = false;
                        optionSelected = true;
                    }
                    // If the option button is selected
                    else if (optionSelected)
                    {
                        // Change what button is selected
                        optionSelected = false;
                        exitSelected = true;
                    }
                    // If the exit button is selected
                    else if (exitSelected)
                    {
                        // Change what button is selected
                        exitSelected = true;
                    }
                    break;
                // If the user pressed the up arrow key
                case ConsoleKey.UpArrow:
                    // If the play button is selected
                    if (playSelected)
                    {
                        // Change what button is selected
                        playSelected = true;
                    }
                    // If the score button is selected
                    else if (scoreSelected)
                    {
                        // Change what button is selected
                        scoreSelected = false;
                        playSelected = true;
                    }
                    // If the about button is selected
                    else if (aboutSelected)
                    {
                        // Change what button is selected
                        aboutSelected = false;
                        scoreSelected = true;
                    }
                    // If the option button is selected
                    else if (optionSelected)
                    {
                        // Change what button is selected
                        optionSelected = false;
                        aboutSelected = true;
                    }
                    // If the exit button is selected
                    else if (exitSelected)
                    {
                        // Change what button is selected
                        exitSelected = false;
                        optionSelected = true;
                    }
                    break;
                // If the user pressed enter key
                case ConsoleKey.Enter:
                    // If the play button is selected
                    if (playSelected)
                    {
                        // Instantiate a new Game
                        game = new Game();
                        if (option.HardSelected)
                        {
                            game.IsHard();
                        }
                        // Start the game
                        game.Loop();
                    }
                    else if (optionSelected)
                    {
                        // Clear the buffer from the menu render
                        Buffer.ClearBuffer();
                        // The sound button starts selected
                        option.SoundSelected = true;
                        // The difficulty button starts unselected
                        option.DifficultySelected = false;
                        // The exit button starts unselected
                        option.ExitSelected = false;
                        // If it is the option menu
                        option.IsOption = true;
                        // Render the option menu
                        option.RenderMenu();
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

/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : ScoreMenu

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class ScoreMenu
    /// </summary>
    public class ScoreMenu
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
        /// If the option menu is selected
        /// </summary>
        private bool _isScore;
        /// <summary>
        /// Path of the user
        /// </summary>
        private static string _pathUser = @"%USERPROFILE%\Desktop\Score.txt";
        /// <summary>
        /// Path of the file
        /// </summary>
        private static string _pathFile = Environment.ExpandEnvironmentVariables(_pathUser);
        /// <summary>
        /// UserName of the last player
        /// </summary>
        private string _userName;
        /// <summary>
        /// Score of the last player
        /// </summary>
        private int _score;
        #endregion

        #region Propriétés des attributs
        /// <summary>
        /// Getter, setter on _exitSelected
        /// </summary>
        public bool ExitSelected
        {
            get { return _exitSelected; }
            set { _exitSelected = value; }
        }
        /// <summary>
        /// Getter, setter on _isScore
        /// </summary>
        public bool IsScore
        {
            get { return _isScore; }
            set { _isScore = value; }
        }
        /// <summary>
        /// Getter, setter on _userName
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        /// <summary>
        /// Getter, setter on _score
        /// </summary>
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructor for the menu class
        /// </summary>
        public ScoreMenu()
        {
            // The exit button selected
            _exitSelected = true;
            // The about menu selected
            _isScore = true;
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Renders all the sprites in the menu
        /// </summary>
        public void RenderMenu()
        {
            while (_isScore)
            {
                ReadFile();
                // Display Title
                for (int i = 0; i < Sprites.titleScoreString.Length; i++)
                {
                    Buffer.WriteWithColor(0, 5 + i, " ", ConsoleColor.Yellow);
                    Buffer.Write(_X_SELECTION - 6, 5 + i, Sprites.titleScoreString[i]);
                }
                // Display Buttons
                for (int i = 0; i < Sprites.playString.Length; i++)
                {
                    MenuDisplayer.ExitButton(i, ConsoleColor.White);
                }
                // Display Texts
                for (int i = 0; i < Sprites.aboutinfo.Length; i++)
                {

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
                        _isScore = false;
                    }
                    break;
            }
            // Render the menu
            RenderMenu();
        }
        /// <summary>
        /// Read the content of file and write in console
        /// </summary>
        public void ReadFile()
        {
            // Y start position to display score
            int positionY = 15;     

            // If file donesn't exist, create one
            if (!File.Exists(_pathFile))
            {
                StreamWriter sw = File.CreateText(_pathFile);
                sw.Close();
            }
            else
            {
                // Read text file
                using (StreamReader sr = new StreamReader(_pathFile))
                {
                    // Get readed line
                    string line;    
                    // While the line content the value
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Set the cursor position and write content
                        Buffer.WriteWithColor(0, positionY, " ", ConsoleColor.White);
                        Buffer.Write(_X_SELECTION, positionY, line);

                        // Increment X position
                        positionY++;
                    }
                }
            }

        }

        /// <summary>
        /// Write in the text file
        /// </summary>
        public void WriteFile()
        {
            // Content of text file
            string textInFile = "";
            // Get content and split
            string[] arrayContent;
            // Get the username of player
            string fileResult = "";
            // Get last score of player
            string lastScore = "";
            // Get the new data to write
            string newFileContent = "";
            // Get the old data
            string fileContent = "";        

            // If the file doesn't exist, create one
            if (!File.Exists(_pathFile))
            {
                StreamWriter sw = File.CreateText(_pathFile);
                sw.Close();
            }
            // Read all content of the text file and find the text where username is
            foreach (var match in File.ReadLines(_pathFile).Select((text, index) => new { text, lineNumber = index + 1 }).Where(x => x.text.Contains(UserName)))
            {
                // Split des info récupérée dans le tableau
                arrayContent = match.text.Split(' ');

                // Si la case 0 du tableau correspond à un pseudo
                if (arrayContent[0] == UserName)
                {
                    fileResult = match.text;
                }
            }

            // If fileResult isn't empty
            if (fileResult != "")
            {
                // Search only numbers in the content
                MatchCollection matches = Regex.Matches(fileResult, "[0-9]");
                foreach (Match match in matches)
                {
                    lastScore += match.Value;
                }

                // Convert last score
                fileContent = File.ReadAllText(_pathFile);

                // If last score is better
                if (Score > Convert.ToInt32(lastScore))
                {
                    // Replace score in the content of the text file
                    newFileContent = fileContent.Replace(UserName + " \t:   " + lastScore, UserName + " \t:   " + Score);

                    // Write new data in the text file
                    using (FileStream fs = File.Create(_pathFile))
                    {
                        Byte[] textToWrite = new UTF8Encoding(true).GetBytes(newFileContent);
                        fs.Write(textToWrite, 0, textToWrite.Length);
                    }
                }
                else
                {
                    // Write new data in the text file
                    using (FileStream fs = File.Create(_pathFile))
                    {
                        Byte[] textToWrite = new UTF8Encoding(true).GetBytes(fileContent);
                        fs.Write(textToWrite, 0, textToWrite.Length);
                    }
                }
            }
            else
            {
                // Read content
                textInFile = File.ReadAllText(_pathFile);

                // Write all content
                using (FileStream fs = File.Create(_pathFile))
                {
                    Byte[] textToWrite = new UTF8Encoding(true).GetBytes(textInFile + "\n" + UserName + " \t:   " + Score);
                    fs.Write(textToWrite, 0, textToWrite.Length);
                }
            }
        }
        #endregion
    }
}

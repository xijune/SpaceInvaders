/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : This class is used to store sprites

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class Sprites
    /// </summary>
    class Sprites
    {
        #region Attributs
        /// <summary>
        /// Design of the space invaders title
        /// </summary>
        public static readonly string[] titleStartString = new string[4]
        {
            "█████████████████████████████████████████████████████████████████████████████████",
            "█─▄▄▄▄█▄─▄▄─██▀▄─██─▄▄▄─█▄─▄▄─███▄─▄█▄─▀█▄─▄█▄─█─▄██▀▄─██▄─▄▄▀█▄─▄▄─█▄─▄▄▀█─▄▄▄▄█",
            "█▄▄▄▄─██─▄▄▄██─▀─██─███▀██─▄█▀████─███─█▄▀─███▄▀▄███─▀─███─██─██─▄█▀██─▄─▄█▄▄▄▄─█",
            "▀▄▄▄▄▄▀▄▄▄▀▀▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▀▀▄▄▄▀▄▄▄▀▀▄▄▀▀▀▄▀▀▀▄▄▀▄▄▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀"
        };
        /// <summary>
        /// Design of the option title
        /// </summary>
        public static readonly string[] titleOptionString = new string[4]
        {
            "███████████████████████████████████",
            "█─▄▄─█▄─▄▄─█─▄─▄─█▄─▄█─▄▄─█▄─▀█▄─▄█",
            "█─██─██─▄▄▄███─████─██─██─██─█▄▀─██",
            "▀▄▄▄▄▀▄▄▄▀▀▀▀▄▄▄▀▀▄▄▄▀▄▄▄▄▀▄▄▄▀▀▄▄▀"
        };
        /// <summary>
        /// Design of the about title
        /// </summary>
        public static readonly string[] titleAboutString = new string[4]
        {
            "███████████████████████████████",
            "██▀▄─██▄─▄─▀█─▄▄─█▄─██─▄█─▄─▄─█",
            "██─▀─███─▄─▀█─██─██─██─████─███",
            "▀▄▄▀▄▄▀▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▄▀▀▀▄▄▄▀▀"
        };
        /// <summary>
        /// Design of the score title
        /// </summary>
        public static readonly string[] titleScoreString = new string[4]
        {
            "██████████████████████████████",
            "█─▄▄▄▄█─▄▄▄─█─▄▄─█▄─▄▄▀█▄─▄▄─█",
            "█▄▄▄▄─█─███▀█─██─██─▄─▄██─▄█▀█",
            "▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀"
        };
        /// <summary>
        /// Design of the play text
        /// </summary>
        public static readonly string[] playString = new string[2]
        {
           "█▀█ █   ▄▀▄ █▄█",
           "█▀▀ █▄▄ █▀█  █ "
        };
        /// <summary>
        /// Design of the score text
        /// </summary>
        public static readonly string[] scoreString = new string[2]
        {
           "█▀ █▀▀ █▀█ █▀█ █▀▀",
           "▄█ █▄▄ █▄█ █▀▄ ██▄"
        };
        /// <summary>
        /// Design of the about text
        /// </summary>
        public static readonly string[] aboutString = new string[2]
        {
           "▄▀▄ █▄▄ █▀█ █ █ ▀█▀",
           "█▀█ █▄█ █▄█ █▄█  █ "
        };
        /// <summary>
        /// Design of the option text
        /// </summary>
        public static readonly string[] optionString = new string[2]
        {
           "█▀█ █▀█ ▀█▀ █ █▀█ █▄ █",
           "█▄█ █▀▀  █  █ █▄█ █ ▀█"
        };
        /// <summary>
        /// Design of the exit text
        /// </summary>
        public static readonly string[] exitString = new string[2]
        {
            "█▀▀ ▀▄▀ █ ▀█▀",
            "██▄ █ █ █  █ "
        };
        /// <summary>
        /// Design of the sound text
        /// </summary>
        public static readonly string[] soundString = new string[2]
        {
            "█▀ █▀█ █ █ █▄ █ █▀▄",
            "▄█ █▄█ █▄█ █ ▀█ █▄▀"
        };
        /// <summary>
        /// Design of the on text
        /// </summary>
        public static readonly string[] onString = new string[2]
        {
            "█▀█ █▄ █",
            "█▄█ █ ▀█"
        };
        /// <summary>
        /// Design of the off text
        /// </summary>
        public static readonly string[] offString = new string[2]
        {
            "█▀█ █▀▀ █▀▀",
            "█▄█ █▀  █▀ "
        };
        /// <summary>
        /// Design of the easy text
        /// </summary>
        public static readonly string[] easyString = new string[2]
        {
            "█▀▀ ▄▀▄ █▀ █▄█",
            "██▄ █▀█ ▄█  █ "
        };
        /// <summary>
        /// Design of the hard text
        /// </summary>
        public static readonly string[] hardString = new string[2]
        {
            "█ █ ▄▀▄ █▀█ █▀▄",
            "█▀█ █▀█ █▀▄ █▄▀"
        };
        /// <summary>
        /// Design of the difficulty text
        /// </summary>
        public static readonly string[] difficultyString = new string[2]
        {
            "█▀▄ █ █▀▀ █▀▀ █ █▀▀ █ █ █   ▀█▀ █▄█",
            "█▄▀ █ █▀  █▀  █ █▄▄ █▄█ █▄▄  █   █ "
        };
        /// <summary>
        /// Design of the game over text
        /// </summary>
        public static readonly string[] gameOverString = new string[2]
        {
            "█▀▀ ▄▀▄ █▀▄▀█ █▀▀   █▀█ █ █ █▀▀ █▀█",
            "█▄█ █▀█ █ ▀ █ ██▄   █▄█ ▀▄▀ ██▄ █▀▄"
        };
        /// <summary>
        /// Design of the pause text
        /// </summary>
        public static readonly string[] pauseString = new string[6]
        {
            "----------------------------------------------------------------------------------------------------",
            "                                                                                                    ",
            "---------------------------------------- █▀█ ▄▀▄ █ █ █▀ █▀▀ ----------------------------------------",
            "---------------------------------------- █▀▀ █▀█ █▄█ ▄█ ██▄ ----------------------------------------",
            "                                                                                                    ",
            "----------------------------------------------------------------------------------------------------"
        };
        /// <summary>
        /// Design of the player
        /// </summary>
        public static readonly string[] player = new string[3]
        {
            "   ▄   ",
            "  ▄█▄  ",
            " ▀█▀█▀ "
        };
        /// <summary>
        /// Design of the ennemy
        /// </summary>
        public static readonly string[] enemy = new string[3]
        {
            " ▀▄ ▄▀ ",
            " █▀█▀█ ",
            " ▐▀▀▀▌ "
        };
        /// <summary>
        /// Infos of the about menu
        /// </summary>
        public static readonly string[] aboutinfo = new string[14]
        {
            "╔═════════════════════════════════════════════════════════════════╗",
            "║Nom :        Petrovic                                            ║",
            "║Prénom :     Stefan                                              ║",
            "║Classe :     CID2a                                               ║",
            "║Age :        19 ans                                              ║",
            "║Formation :  CFC Informatique - 2021 / 2024                      ║",
            "║Lieu :       ETML - Ecole Technique des Métiers de Lausanne      ║",
            "║Date :       11.12.2021                                          ║",
            "╠═════════════════════════════════════════════════════════════════╣",
            "║Projet :     Le projet consiste à crée un Space Invaders à       ║",
            "║             partir de rien. Le Space Invaders est un jeu        ║",
            "║             d'arcade de l'époque, le but ici est de le          ║",
            "║             recrée en C# en mode console.                       ║",
            "╚═════════════════════════════════════════════════════════════════╝"
        };
        #endregion

        #region Propriétés des attributs
        #endregion

        #region Constructeurs
        #endregion

        #region Methodes
        #endregion
    }
}

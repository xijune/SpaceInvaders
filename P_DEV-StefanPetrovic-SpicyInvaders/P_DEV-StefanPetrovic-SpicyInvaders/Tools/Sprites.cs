/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : This class is used to store sprites

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    class Sprites
    {
        #region Attributs
        // Design of the space invaders title
        public static readonly string[] titleStartString = new string[4]
        {
            "█████████████████████████████████████████████████████████████████████████████████",
            "█─▄▄▄▄█▄─▄▄─██▀▄─██─▄▄▄─█▄─▄▄─███▄─▄█▄─▀█▄─▄█▄─█─▄██▀▄─██▄─▄▄▀█▄─▄▄─█▄─▄▄▀█─▄▄▄▄█",
            "█▄▄▄▄─██─▄▄▄██─▀─██─███▀██─▄█▀████─███─█▄▀─███▄▀▄███─▀─███─██─██─▄█▀██─▄─▄█▄▄▄▄─█",
            "▀▄▄▄▄▄▀▄▄▄▀▀▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▀▀▄▄▄▀▄▄▄▀▀▄▄▀▀▀▄▀▀▀▄▄▀▄▄▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀"
        };
        // Design of the option title
        public static readonly string[] titleOptionString = new string[4]
        {
            "███████████████████████████████████",
            "█─▄▄─█▄─▄▄─█─▄─▄─█▄─▄█─▄▄─█▄─▀█▄─▄█",
            "█─██─██─▄▄▄███─████─██─██─██─█▄▀─██",
            "▀▄▄▄▄▀▄▄▄▀▀▀▀▄▄▄▀▀▄▄▄▀▄▄▄▄▀▄▄▄▀▀▄▄▀"
        };
        // Design of the about title
        public static readonly string[] titleAboutString = new string[4]
        {
            "███████████████████████████████",
            "██▀▄─██▄─▄─▀█─▄▄─█▄─██─▄█─▄─▄─█",
            "██─▀─███─▄─▀█─██─██─██─████─███",
            "▀▄▄▀▄▄▀▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▄▀▀▀▄▄▄▀▀"
        };
        // Design of the play text
        public static readonly string[] playString = new string[2]
        {
           "█▀█ █   ▄▀▄ █▄█",
           "█▀▀ █▄▄ █▀█  █ "
        };
        // Design of the score text
        public static readonly string[] scoreString = new string[2]
        {
           "█▀ █▀▀ █▀█ █▀█ █▀▀",
           "▄█ █▄▄ █▄█ █▀▄ ██▄"
        };
        // Design of the about text
        public static readonly string[] aboutString = new string[2]
        {
           "▄▀▄ █▄▄ █▀█ █ █ ▀█▀",
           "█▀█ █▄█ █▄█ █▄█  █ "
        };
        // Design of the option text
        public static readonly string[] optionString = new string[2]
        {
           "█▀█ █▀█ ▀█▀ █ █▀█ █▄ █",
           "█▄█ █▀▀  █  █ █▄█ █ ▀█"
        };
        // Design of the exit text
        public static readonly string[] exitString = new string[2]
        {
            "█▀▀ ▀▄▀ █ ▀█▀",
            "██▄ █ █ █  █ "
        };
        // Design of the sound text
        public static readonly string[] soundString = new string[2]
        {
            "█▀ █▀█ █ █ █▄ █ █▀▄",
            "▄█ █▄█ █▄█ █ ▀█ █▄▀"
        };
        // Design of the on text
        public static readonly string[] onString = new string[2]
        {
            "█▀█ █▄ █",
            "█▄█ █ ▀█"
        };
        // Design of the off text
        public static readonly string[] offString = new string[2]
        {
            "█▀█ █▀▀ █▀▀",
            "█▄█ █▀  █▀ "
        };
        // Design of the easy text
        public static readonly string[] easyString = new string[2]
        {
            "█▀▀ ▄▀▄ █▀ █▄█",
            "██▄ █▀█ ▄█  █ "
        };
        // Design of the hard text
        public static readonly string[] hardString = new string[2]
        {
            "█ █ ▄▀▄ █▀█ █▀▄",
            "█▀█ █▀█ █▀▄ █▄▀"
        };
        // Design of the difficulty text
        public static readonly string[] difficultyString = new string[2]
        {
            "█▀▄ █ █▀▀ █▀▀ █ █▀▀ █ █ █   ▀█▀ █▄█",
            "█▄▀ █ █▀  █▀  █ █▄▄ █▄█ █▄▄  █   █ "
        };
        // Design of the game over text
        public static readonly string[] gameOverString = new string[2]
        {
            "█▀▀ ▄▀▄ █▀▄▀█ █▀▀   █▀█ █ █ █▀▀ █▀█",
            "█▄█ █▀█ █ ▀ █ ██▄   █▄█ ▀▄▀ ██▄ █▀▄"
        };
        // Design of the pause text
        public static readonly string[] pauseString = new string[6]
        {
            "----------------------------------------------------------------------------------------------------",
            "                                                                                                    ",
            "---------------------------------------- █▀█ ▄▀▄ █ █ █▀ █▀▀ ----------------------------------------",
            "---------------------------------------- █▀▀ █▀█ █▄█ ▄█ ██▄ ----------------------------------------",
            "                                                                                                    ",
            "----------------------------------------------------------------------------------------------------"
        };
        // Design of the player
        public static readonly string[] player = new string[3]
        {
            "   ▄   ",
            "  ▄█▄  ",
            " ▀█▀█▀ "
        };
        // Design of the ennemy
        public static readonly string[] enemy = new string[3]
        {
            " ▀▄ ▄▀ ",
            " █▀█▀█ ",
            " ▐▀▀▀▌ "
        };
        // Infos of the about menu
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

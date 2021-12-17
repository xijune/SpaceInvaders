using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    class Sprites
    {
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
    }
}

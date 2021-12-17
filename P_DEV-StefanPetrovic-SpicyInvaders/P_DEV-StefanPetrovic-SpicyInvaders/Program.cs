using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    class Program
    {
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
    }
}

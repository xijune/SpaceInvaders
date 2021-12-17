using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Interface for all game objects
    /// </summary>
    interface IGameObject
    {
        /// <summary>
        /// The update method of the game object
        /// </summary>
        void Update();

        /// <summary>
        /// The start method of the game object
        /// </summary>
        void Start();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Controlls all the explosions in the game
    /// </summary>
    class Explosions : GameObject
    {
        // List of explosions
        private List<Explosion> _explosions;

        /// <summary>
        /// Constructor for the Explosions class
        /// </summary>
        public Explosions()
        {
            // Initialize the list of explosions
            _explosions = new List<Explosion>();
        }

        /// <summary>
        /// The Update method
        /// </summary>
        public override void Update()
        {
            // Go through all the explosions on the list
            for (int i = _explosions.Count - 1; i >= 0; i--)
            {
                // If the explosion has finished the animation
                if (_explosions[i].Explode())
                {
                    // Delete the explosion
                    _explosions[i].Delete();

                    // Remove it from the list
                    _explosions.Remove(_explosions[i]);
                }
            }
        }

        /// <summary>
        /// Adds an explosion to the list
        /// </summary>
        /// <param name="coordinate">The coordinates for the explosion</param>
        /// <param name="explosionType">The type of explosion</param>
        public void Add(Vector coordinate, ExplosionType explosionType)
        {
            // Adds a new explosion to the list
            _explosions.Add(new Explosion(coordinate, explosionType));
        }
    }
}

/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : Displays an explosion where an object was destroyed

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class Explosion
    /// </summary>
    class Explosion
    {
        #region Attributs
        /// <summary>
        /// Constant to define the sprite height
        /// </summary>
        const int _SPRITE_HEIGHT = 3;
        /// <summary>
        /// The coordinate for the ship
        /// </summary>
        private Vector _coordinates;
        /// <summary>
        /// Create a new Timer
        /// </summary>
        private Timer _timer;
        /// <summary>
        /// Save the explosion type
        /// </summary>
        private ExplosionType _type;
        /// <summary>
        /// Sprite for explosion 1
        /// </summary>
        private string[] _sprite1;
        /// <summary>
        /// Sprite for explosion 2
        /// </summary>
        private string[] _sprite2;
        /// <summary>
        /// Sprite for explosion 3
        /// </summary>
        private string[] _sprite3;
        /// <summary>
        /// Sprite for explosion 4
        /// </summary>
        private string[] _sprite4;
        /// <summary>
        /// Sprite for explosion 5
        /// </summary>
        private string[] _sprite5;
        /// <summary>
        /// Current animation frame
        /// </summary>
        private int _animation;
        #endregion

        #region Propriétés des attributs
        /// <summary>
        /// Vector of Coordinates
        /// </summary>
        public Vector Coordinates => _coordinates;
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructor for the Explosion class
        /// </summary>
        /// <param name="coordinate">The coordinate for the explosion</param>
        /// <param name="explosionType">The type of explosion</param>
        public Explosion(Vector coordinate, ExplosionType explosionType)
        {
            // Instantiate a new timer
            _timer = new Timer(2);

            // Set the coordinates
            _coordinates = coordinate;

            // Decrease the X coordinate by 1
            // Makes the explosion sprite fit better
            _coordinates.X--;

            // Set the animation frame to 0
            _animation = 0;

            // Set the type of explosion
            _type = explosionType;

            // Set the explosion sprites
            SetSprites();
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Writes the sprite of the explosion to the buffer
        /// </summary>
        /// <returns>If the explosion has finished the animation</returns>
        public bool Explode()
        {
            // Create a bool variable
            bool retVal = false;

            // Create a new String array for the sprite
            string[] sprite = null;

            // If the timer is not counting
            if (!_timer.IsCounting())
            {
                // Switch the animation frame
                switch (_animation)
                {
                    // If it's the frame 0
                    case 0:
                        // Set the sprite to 1
                        sprite = _sprite1;
                        break;
                    // If it's the frame 1
                    case 1:
                        // Set the sprite to 2
                        sprite = _sprite2;
                        break;
                    // If it's the frame 2
                    case 2:
                        // Set the sprite to 3
                        sprite = _sprite3;
                        break;
                    // If it's the frame 3
                    case 3:
                        // If it's a small explosion the animation lasts less time
                        if (_type == ExplosionType.SMALL)
                        {
                            // Set the sprite to 5
                            sprite = _sprite5;

                            // Set the return value to true
                            retVal = true;
                        }
                        // Else...
                        else
                        {
                            // Set the sprite to 4
                            sprite = _sprite4;
                        }
                        break;
                    // If it's the frame 4
                    case 4:
                        // Set the sprite to 5
                        sprite = _sprite5;

                        // Set the return value to true
                        retVal = true;
                        break;
                }

                // Increase the animation frame
                _animation++;

                // Go through every string on the sprite
                for (int i = 0; i < _SPRITE_HEIGHT; i++)
                {
                    // Write it to the buffer
                    Buffer.Write(_coordinates.X, _coordinates.Y + i, sprite[i]);
                }
            }

            // Return the return value
            return retVal;
        }

        /// <summary>
        /// Deletes the sprite from the buffer
        /// </summary>
        public void Delete()
        {
            // Go through every string on the sprite
            for (int i = 0; i < _sprite5.Length; i++)
            {
                // Delete it from the buffer
                Buffer.Delete(_coordinates.X, _coordinates.Y + i, _sprite5[i]);
            }
        }

        /// <summary>
        /// Sets the sprites for the explosion
        /// </summary>
        private void SetSprites()
        {
            _sprite1 = new string[3]
            {
                "         ",
                "    ▄    ",
                "         "
            };
            _sprite2 = new string[3]
            {
                "         ",
                "   ▀▄▀   ",
                "   ▀ ▀   "
            };
            _sprite3 = new string[3]
            {
                "  ▄   ▄  ",
                " ▄ ▀ ▀ ▄ ",
                "  ▄▀ ▀▄  "
            };
            _sprite4 = new string[3]
            {
                " ▄     ▄ ",
                "▄ ▀   ▀ ▄",
                " ▄▀   ▀▄ "
            };
            _sprite5 = new string[3]
            {
                "         ",
                "         ",
                "         "
            };
        }
        #endregion
    }
}

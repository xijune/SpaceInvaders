using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Enemy Class corresponds to an ingame enemy object
    /// </summary>
    class Enemy : GameObject
    {
        // Constants related to what's done in this script
        private const int _SPRITE_HEIGTH = 3;

        /// <summary>
        /// The coordinate for the ship
        /// </summary>
        private Vector _coordinates;
        public Vector Coordinates => _coordinates;

        /// <summary>
        /// If the enemy is on the first sprite
        /// </summary>
        public bool FirstSprite { get; set; }

        /// <summary>
        /// The current type of movement the enemy has
        /// </summary>
        public MoveType MovementType { get; set; }

        /// <summary>
        /// If the enemy is to go down
        /// </summary>
        public bool IncreaseY { get; set; }

        /// <summary>
        /// If the enemy will move this frame
        /// </summary>
        public bool CanMove { get; set; }

        // The enemy first sprite
        private string[] _sprite1;

        // The enemy second sprite
        private string[] _sprite2;

        // The enemy current sprite
        private string[] _currentSprite;

        // The color of the enemy
        private ConsoleColor _myColor;

        /// <summary>
        /// Constructor for the enemy class
        /// </summary>
        /// <param name="x">The starting x position</param>
        /// <param name="y">The starting y position</param>
        /// <param name="color">The color of the enemy</param>
        /// <param name="enemyType">The type of the enemy</param>
        public Enemy(int x, int y, ConsoleColor color, string[] enemy)
        {
            // Set the enemy starting position
            _coordinates = new Vector(x, y);

            // Set the enemy color
            _myColor = color;

            // Set the correct sprites
            _sprite1 = enemy;
            _sprite2 = enemy;
        }

        /// <summary>
        /// The Update method
        /// </summary>
        public override void Update()
        {
            // If the enemy can move
            if (CanMove)
            {
                // Move
                Move();
            }

            // Writes the enemy sprite to the buffer
            WriteToBuffer();
        }

        /// <summary>
        /// Moves the enemies up
        /// </summary>
        public void DecreaseY()
        {
            // Move the enemy up
            _coordinates = new Vector(Coordinates.X, Coordinates.Y - 1);
        }

        /// <summary>
        /// Moves the enemies down
        /// </summary>
        public void YIncreasse()
        {
            // Move the enemy up
            _coordinates = new Vector(Coordinates.X, Coordinates.Y + 1);
        }

        /// <summary>
        /// Deletes the enemy from the buffer
        /// </summary>
        public void Delete()
        {
            // Go through all the strings in the sprite
            for (int i = 0; i < _SPRITE_HEIGTH; i++)
            {
                // Write to the current buffer an empty string
                Buffer.Delete(_coordinates.X, _coordinates.Y + i, "       ");
            }
        }

        /// <summary>
        /// Writes the enemy sprite to the buffer
        /// </summary>
        private void WriteToBuffer()
        {
            // Select the correct sprite to render
            _currentSprite = FirstSprite ? _sprite1 : _sprite2;

            // Go through the array of strings
            for (int i = 0; i < _currentSprite.Length; i++)
            {
                // Write a string to the buffer
                Buffer.WriteWithColor(0, _coordinates.Y + i, " ", _myColor);

                // Write each string to the buffer
                Buffer.Delete(_coordinates.X, _coordinates.Y + i, _currentSprite[i]);
            }
        }

        /// <summary>
        /// Moves the enemy based on it's current direction
        /// </summary>
        private void Move()
        {
            // If the enemy is to move down
            if (IncreaseY)
            {
                // Clear the area above the enemy
                Buffer.WriteWithColor(0, _coordinates.Y, " ", ConsoleColor.Black);
                Buffer.Delete(_coordinates.X, _coordinates.Y, "       ");

                // Moves the enemy down
                _coordinates.Y++;

                // Reset the `IncreaseY` back to false
                IncreaseY = false;
            }
            // Else
            else
            {
                // If the movement type is left
                if (MovementType == MoveType.LEFT)
                {
                    // Move the enemy left
                    _coordinates.X--;
                }
                // Else if the movement type is right
                else if (MovementType == MoveType.RIGHT)
                {
                    // Move the enemy right
                    _coordinates.X++;
                }
            }
        }
    }
}

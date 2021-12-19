/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : Bullet Class corresponds to an ingame bullet object

using System;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    class Bullet
    {
        #region Attributs
        // The bullet prite
        private char _bullet;
        // How much to move the bullet
        private int _increment;
        // The coordinate for the bullet
        private Vector _coordinates;
        #endregion

        #region Propriétés des attributs
        // The coordinate for the bullet
        public Vector Coordinates => _coordinates;
        // Save the move direction of the bullet
        public MoveType moveDirection { get; }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructor for the bullet class
        /// </summary>
        /// <param name="x">The starting x position</param>
        /// <param name="y">The starting y position</param>
        /// <param name="movement">The type of movement the bullet will have (Up/Down)</param>
        public Bullet(int x, int y, MoveType movement)
        {
            // Set the move direction
            moveDirection = movement;

            // Set the bullet coordinates to the starting position
            _coordinates = new Vector(x, y);

            // Set the type of increment based on the move type
            _increment = movement == MoveType.UP ? -1 : 1;

            // Set the bullet sprite
            _bullet = '║';
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Write the bullet to the buffer
        /// </summary>
        private void Write()
        {
            // Write to the buffer
            Buffer.Delete(_coordinates.X, _coordinates.Y, _bullet.ToString());

            Buffer.WriteWithColor(0, _coordinates.Y, " ", ConsoleColor.White);
        }

        /// <summary>
        /// Delete the bullet from the buffer
        /// </summary>
        public void Delete()
        {
            // Write the bullet to the buffer
            Buffer.Delete(_coordinates.X, _coordinates.Y, " ");
        }

        /// <summary>
        /// Move the bullet
        /// </summary>
        private void Move()
        {
            // Delete the bullet from the buffer
            Delete();

            // Move the bullet
            _coordinates.Y += _increment;
        }

        /// <summary>
        /// The Update method
        /// </summary>
        public void Update()
        {
            // Move the bullet
            Move();

            // Write to the buffer
            Write();
        }
        #endregion
    }
}

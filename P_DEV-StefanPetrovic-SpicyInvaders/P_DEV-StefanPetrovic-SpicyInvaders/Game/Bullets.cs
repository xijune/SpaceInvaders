/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : The Bullets class holds and controls several bullets

using System.Collections.Generic;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class Bullets
    /// </summary>
    class Bullets
    {
        #region Attributs
        /// <summary>
        /// The current number of bullets
        /// </summary>
        private int _numOfBullets;
        /// <summary>
        /// The max number of bullets of the scene
        /// </summary>
        private int _maxNumOfBullets;
        /// <summary>
        /// The endRow for the bullet
        /// </summary>
        private int _endRow;
        /// <summary>
        /// How fast the bullet will move
        /// </summary>
        private Timer _moveTimer;
        #endregion

        #region Propriétés des attributs
        /// <summary>
        /// List with the current bullets on the scene
        /// </summary>
        public List<Bullet> BulletsList { get; private set; }
        #endregion

        #region Constructeurs
        /// <summary>
        /// `ShipBullets` constructor class
        /// </summary>
        public Bullets(int endRow, int maxBullets, int moveSpeed)
        {
            // Set the maximum number of bullets
            _maxNumOfBullets = maxBullets;

            // Set the end row
            this._endRow = endRow;

            // Instantiat a new timer
            _moveTimer = new Timer(moveSpeed);

            // Initialize a new `List` of `ShipBullets`
            BulletsList = new List<Bullet>(_maxNumOfBullets);

            // Set the starting number of bullets
            _numOfBullets = 0;
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Updates all the bullets
        /// </summary>
        public void UpdateBullets()
        {
            if (!_moveTimer.IsCounting())
            {
                // Go through all the bullets in the bullets list
                for (int i = 0; i < BulletsList.Count; i++)
                {
                    // Move the bullets
                    BulletsList[i].Update();

                    // If the bullet has reached the top part of the level
                    if ((BulletsList[i].Coordinates.Y >= _endRow &&
                        BulletsList[i].moveDirection == MoveType.DOWN) ||
                        (BulletsList[i].Coordinates.Y <= _endRow &&
                        BulletsList[i].moveDirection == MoveType.UP))
                    {
                        // Decrease the current number of bullets
                        _numOfBullets--;

                        // Delete the bullet
                        BulletsList[i].Delete();

                        // Add it to the remove list
                        BulletsList.Remove(BulletsList[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the bullets passed in
        /// </summary>
        /// <param name="bullets">Bullets to delete</param>
        public void DeleteBullets(List<Bullet> bullets)
        {
            // Go through all the bullets in the list
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                // Decrease the current number of bullets
                _numOfBullets--;

                // Delete the bullet
                BulletsList[i].Delete();

                // Add it to the remove list
                BulletsList.Remove(BulletsList[i]);
            }
        }

        /// <summary>
        /// Adds new bullets to the List
        /// </summary>
        /// <param name="x">Bullet X position</param>
        /// <param name="y">Bullet Y position</param>
        /// <param name="movement">The type of movement the bullet has</param>
        public void Add(int x, int y, MoveType movement)
        {
            // If the number of bullets is less than the max
            if (_numOfBullets < _maxNumOfBullets)
            {
                // Increase the number of bullets
                _numOfBullets++;

                // Add a new bullet to the list
                BulletsList.Add(new Bullet(x, y, movement));
            }
        }
        #endregion
    }
}

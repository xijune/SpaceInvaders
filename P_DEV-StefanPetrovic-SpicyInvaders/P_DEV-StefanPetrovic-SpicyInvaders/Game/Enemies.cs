/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : All enemies do the same so this class manages all of them

using System;
using System.Collections.Generic;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class Enemis inherits GameObject
    /// </summary>
    class Enemies : GameObject
    {
        #region Attributs
        /// <summary>
        /// Animation init speed
        /// </summary>
        const int _ANIMATION_INIT_SPEED = 12;
        /// <summary>
        /// Number of columns
        /// </summary>
        const int _NUMBER_OF_COLUMNS = 7;
        /// <summary>
        /// Bullet move speed
        /// </summary>
        const int _BULLET_MOVE_SPEED = 2;
        /// <summary>
        /// Move down steps
        /// </summary>
        const int _MOVE_DOWN_STEPS = 30;
        /// <summary>
        /// Number of bullet at the initialization
        /// </summary>
        const int _INIT_NUM_BULLETS = 3;
        /// <summary>
        /// Max number of bullet
        /// </summary>
        const int _MAX_NUM_BULLETS = 10;
        /// <summary>
        /// Bottom boundary
        /// </summary>
        const int _BOTTOM_BOUDARY = 54;
        /// <summary>
        /// Right boundary
        /// </summary>
        const int _RIGHT_BOUNDARY = 90;
        /// <summary>
        /// Lower boundary
        /// </summary>
        const int _LOWER_BOUNDARY = 58;
        /// <summary>
        /// Move down speed
        /// </summary>
        const int _MOVE_DOWN_SPEED = 5;
        /// <summary>
        /// Move init speed
        /// </summary>
        const int _MOVE_INIT_SPEED = 7;
        /// <summary>
        /// Move up steps
        /// </summary>
        const int _MOVE_UP_STEPS = 15;
        /// <summary>
        /// Move up speed
        /// </summary>
        const int _MOVE_UP_SPEED = 5;
        /// <summary>
        /// Top start row
        /// </summary>
        const int _TOP_START_ROW = 6;
        /// <summary>
        /// Left boundary
        /// </summary>
        const int _LEFT_BOUNDARY = 3;
        /// <summary>
        /// Y min
        /// </summary>
        const int _Y_MIN = 12;
        /// <summary>
        /// Current movement direction of all enemies
        /// </summary>
        private MoveType _currentMove;
        /// <summary>
        /// Timer for the animation
        /// </summary>
        private Timer _animationTimer;
        /// <summary>
        /// Timer for moving down
        /// </summary>
        private Timer _moveDownTimer;
        /// <summary>
        /// Timer for the movement
        /// </summary>
        private Timer _moveTimer;
        /// <summary>
        /// Timer fot the movement up steps
        /// </summary>
        private Timer _moveUpSteps;
        /// <summary>
        /// Timer for the movement up speed
        /// </summary>
        private Timer _moveUpSpeed;
        /// <summary>
        /// Instantiate a new Random
        /// </summary>
        private Random rnd = new Random();
        /// <summary>
        /// The step ammount to move the enemy down
        /// </summary>
        private int _moveDownSteps;
        /// <summary>
        /// Number of bullets
        /// </summary>
        private int _numOfBullets;
        /// <summary>
        /// If the enemy is on the first sprite
        /// </summary>
        private bool _firstSprite;
        /// <summary>
        /// If the enemy is to go down
        /// </summary>
        private bool _increaseY;
        /// <summary>
        /// If the enemy will move this frame
        /// </summary>
        private bool _moveEnemy;
        /// <summary>
        /// Check if the ship died
        /// </summary>
        public bool shipDestroyed;
        #endregion

        #region Propriétés des attributs
        /// <summary>
        /// Getter for the EnemyList
        /// </summary>
        public List<Enemy> EnemyList { get; private set; }
        /// <summary>
        /// Getter on EnemyBullets
        /// </summary>
        public Bullets EnemyBullets { get; private set; }
        #endregion

        #region Constructeurs
        /// <summary>
        /// The enemies constructor 
        /// </summary>
        /// <param name="level">The current level</param>
        public Enemies(int level)
        {
            // Set the max number of bullets for the enemies
            _numOfBullets = _INIT_NUM_BULLETS;
            // Increase the number of bullets every 4 levels up to a maximum of 10 bullets
            Timer bulletCounter = new Timer(4);
            // Loop the level amount of times
            for (int i = 0; i < level; i++)
            {
                // If the bullet counter has stopped and the num of bullets is less than the max
                if (!bulletCounter.IsCounting() && (_numOfBullets < _MAX_NUM_BULLETS))
                {
                    // Increase the number of bullets by 2
                    _numOfBullets += 2;
                }
            }
            // Initialize the list
            EnemyList = new List<Enemy>();
            // Instantiate a new timer for the animation speed
            _animationTimer = new Timer(_ANIMATION_INIT_SPEED);
            // Instantiate a new timer for the movement speed
            _moveTimer = new Timer(_MOVE_INIT_SPEED);
            // Instantiate a new timer for the move down speed
            _moveDownTimer = new Timer(_MOVE_DOWN_SPEED);
            // Instantiate a new timer for the move up steps
            _moveUpSteps = new Timer(_MOVE_UP_STEPS);
            // Instantiate a new timer for the move up speed
            _moveUpSpeed = new Timer(_MOVE_UP_SPEED);
            // Instatiate the ship bullets
            EnemyBullets = new Bullets(_LOWER_BOUNDARY, _numOfBullets, _BULLET_MOVE_SPEED);
            // When the game starts the enemie is on the first sprite
            _firstSprite = true;
            // Set the starting movement direction for the enemies
            _currentMove = MoveType.RIGHT;
            // At the start the y wont increasse
            _increaseY = false;
            AddEnemies(level);
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Update method
        /// </summary>
        public override void Update()
        {
            // If the animation timer has finished counting
            if (!_animationTimer.IsCounting())
            {
                // Change the sprite to animate the enemy
                _firstSprite = !_firstSprite;
            }

            // Update all enemy bullets
            EnemyBullets.UpdateBullets();

            // If the ship is not destroyed
            if (!shipDestroyed)
            {
                // Try to shoot
                Shoot();

                // Update the movement for the enemies
                Move();
            }
            // Else...
            else
            {
                // Move the enemies up
                MoveUp();
            }

            // Updates all enemies
            UpdateAllEnemies();

        }

        /// <summary>
        /// Moves the enemies up
        /// </summary>
        public void MoveUp()
        {
            // If the moveSpeed timer is not counting and the move steps is counting
            if (!_moveUpSpeed.IsCounting() && _moveUpSteps.IsCounting())
            {
                // Create a new int `min`
                int min = 60;

                // Create a new coordinate
                Vector coordinate;

                // Go through every enemy in the enemies list
                for (int i = 0; i < EnemyList.Count; i++)
                {
                    // Save it's coordinates
                    coordinate = EnemyList[i].Coordinates;

                    // If the min is bigger than the coordinate Y
                    if (min > coordinate.Y)
                    {
                        // Set the min to be equal to the coordinate Y
                        min = coordinate.Y;
                    }
                }

                // If min is bigger than the minimum Y value
                if (min > _Y_MIN)
                {
                    // Go through every enemy on the enemies list
                    for (int i = 0; i < EnemyList.Count; i++)
                    {
                        // Save it's coordinates
                        coordinate = EnemyList[i].Coordinates;

                        // Delete the under part of the enemy
                        Buffer.Delete(coordinate.X, coordinate.Y + 2, "       ");

                        // Decrease the enemy Y value
                        EnemyList[i].DecreaseY();
                    }
                }
            }
        }

        /// <summary>
        /// Moves all enemies down
        /// </summary>
        public void MoveDown()
        {
            // If the animation timer has finished counting
            if (!_animationTimer.IsCounting())
            {
                // Change the sprite to animate the enemy
                _firstSprite = !_firstSprite;
            }

            // If the moveDownTimer is not counting
            if (!_moveDownTimer.IsCounting())
            {
                //Increase the steps by 1
                _moveDownSteps++;

                // If the moveDowSteps is greater than the `MOVE_DOWN_STEPS` returns
                if (_moveDownSteps > _MOVE_DOWN_STEPS) return;

                // Create a new Vector
                Vector coordinate;

                // Goes through every enemy in the Enemy List
                foreach (Enemy enemy in EnemyList)
                {
                    // Save the enemy coordinate to a more convinient variable
                    coordinate = enemy.Coordinates;

                    // Set the enemy to not move
                    enemy.CanMove = false;

                    // Update the enemy sprite
                    enemy.FirstSprite = _firstSprite;

                    // Increase the enemy Y
                    enemy.YIncreasse();

                    // If the enemy Y coordinate is greater than the `TOP_START_ROW`
                    if (coordinate.Y > _TOP_START_ROW)
                    {
                        // Delete the top line of the enemy
                        Buffer.Delete(coordinate.X, coordinate.Y, "       ");

                        // Update the enemy
                        enemy.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Reset the move up timers
        /// </summary>
        public void ResetMoveUp()
        {
            // Reset the moveUpSteps timer
            _moveUpSteps = new Timer(_MOVE_UP_STEPS);

            // Reset the moveUpSpeed;
            _moveUpSpeed = new Timer(_MOVE_UP_SPEED);
        }

        /// <summary>
        /// A random enemy is choosen to shoot a bullet
        /// </summary>
        private void Shoot()
        {
            // Get a random index from the list of enemies
            int index = rnd.Next(0, EnemyList.Count);

            // Get the coordinates of the enemy
            int x = EnemyList[index].Coordinates.X + 3;
            int y = EnemyList[index].Coordinates.Y + 3;

            // Add a new bullet
            EnemyBullets.Add(x, y, MoveType.DOWN);
        }

        /// <summary>
        /// Checks if an enemy was hit by a bullet
        /// </summary>
        /// <param name="bulletCoordinate">The coordinate of the bullet</param>
        /// <returns>If there was a hit</returns>
        public bool CheckHit(Vector bulletCoordinate, out Vector coordinate)
        {
            coordinate = new Vector(0, 0);

            // Go through all existing enemies
            for (int i = EnemyList.Count - 1; i >= 0; i--)
            {
                // Save the coordinate on a specific variable
                coordinate = EnemyList[i].Coordinates;

                // If the bullet hit an enemy
                if (bulletCoordinate.X >= coordinate.X + 1 &&
                    bulletCoordinate.X < coordinate.X + 6 &&
                    bulletCoordinate.Y >= coordinate.Y &&
                    bulletCoordinate.Y < coordinate.Y + 2)
                {
                    // Delete the enemy
                    EnemyList[i].Delete();

                    // Remove the enemy from the list
                    EnemyList.Remove(EnemyList[i]);

                    // Return true
                    return true;
                }
            }

            // Return false
            return false;
        }

        /// <summary>
        /// Checks if any of the enemy bullets has it the ship
        /// </summary>
        /// <param name="shipCoordinate">The ship's coordinate</param>
        /// <returns>If the ship was hit</returns>
        public bool CheckShipHit(Vector shipCoordinate)
        {
            // Saves the ship location
            Vector coordinate;

            // Go through all existing enemy bullets
            for (int i = EnemyBullets.BulletsList.Count - 1; i >= 0; i--)
            {
                // Save the coordinate on a specific variable
                coordinate = EnemyBullets.BulletsList[i].Coordinates;

                // Check if there was a collision between the ship and the bullet
                if ((coordinate.X > shipCoordinate.X + 2 &&
                    coordinate.X < shipCoordinate.X + 4 &&
                    coordinate.Y == shipCoordinate.Y) ||
                    (coordinate.X > shipCoordinate.X + 1 &&
                    coordinate.X < shipCoordinate.X + 5 &&
                    coordinate.Y == shipCoordinate.Y + 1) ||
                    (coordinate.X > shipCoordinate.X &&
                    coordinate.X < shipCoordinate.X + 6 &&
                    coordinate.Y == shipCoordinate.Y + 2))
                {
                    // Delete the bullet
                    EnemyBullets.BulletsList[i].Delete();

                    // Remove the bullet from the list
                    EnemyBullets.BulletsList.Remove(EnemyBullets.BulletsList[i]);

                    // Return true
                    return true;
                }
            }

            // Return false
            return false;
        }

        /// <summary>
        /// Updates all enemies
        /// </summary>
        private void UpdateAllEnemies()
        {
            // Go through every enemy on the list
            for (int i = 0; i < EnemyList.Count; i++)
            {
                // Update the sprite to use
                EnemyList[i].FirstSprite = _firstSprite;

                // Update the movement type
                EnemyList[i].MovementType = _currentMove;

                // Update if it's to increase the Y value
                EnemyList[i].IncreaseY = _increaseY;

                // Tell the enemy he can move
                EnemyList[i].CanMove = _moveEnemy;

                if (shipDestroyed)
                {
                    EnemyList[i].CanMove = false;
                }

                // Call the update method on this enemy
                EnemyList[i].Update();
            }

            // Reset the `increaseY` to false
            _increaseY = false;

            // Reset the move enemy back to false
            _moveEnemy = false;
        }

        /// <summary>
        /// Updates the movement type for all the enemies
        /// </summary>
        private void Move()
        {
            // If the move timer has finished counting
            if (!_moveTimer.IsCounting())
            {
                // The enemy will move this frame
                _moveEnemy = true;

                // Find the closest enemy to the right and the left
                for (int i = 0; i < EnemyList.Count; i++)
                {
                    // If the enemies are moving left and 
                    // the current enemy X coordinate is lower than the left boundary
                    if (_currentMove == MoveType.LEFT && EnemyList[i].Coordinates.X < _LEFT_BOUNDARY)
                    {
                        // Set the movement direction to right
                        _currentMove = MoveType.RIGHT;

                        // Set the increaseY to true
                        _increaseY = true;
                    }
                    // Else if the enemies are moving right and 
                    // the current enemy X coordinate is greater than right boundary
                    else if (_currentMove == MoveType.RIGHT && EnemyList[i].Coordinates.X > _RIGHT_BOUNDARY)
                    {
                        // Set the movement direction to left
                        _currentMove = MoveType.LEFT;

                        // Set the increaseY to true
                        _increaseY = true;
                    }
                }
            }
        }

        /// <summary>
        /// Adds enemies to the list of enemies
        /// </summary>
        private void AddEnemies(int level)
        {
            // Create a new int for the number of columns
            int numColumns = _NUMBER_OF_COLUMNS;

            // Create a new int for how many more enemies to add
            int moreEnemies = 0;

            // Create a counter
            int counter = 0;

            // Increase the number of row every 4 levels up to a maximum of 11
            for (int i = 0; i < level; i++)
            {
                // Increase the counter by 1
                counter++;

                // If the counter is equal to 4
                if (counter == 4)
                {
                    // Set the counter to 0
                    counter = 0;

                    // If ``moreEnemies is less than 4`
                    if (moreEnemies < 4)
                    {
                        // Increase the number of enemies to add
                        moreEnemies++;
                    }
                }
            }

            // Increase the number of enemies by `moreEnemies`
            numColumns += moreEnemies;

            // Loops the number of `numColumns`
            for (int i = 0; i < numColumns; i++)
            {
                // Add all the starting enemies
                EnemyList.Add(new Enemy(i * 8, -20, ConsoleColor.Green, Sprites.enemy));
                EnemyList.Add(new Enemy(i * 8, -16, ConsoleColor.Green, Sprites.enemy));
                EnemyList.Add(new Enemy(i * 8, -12, ConsoleColor.Cyan, Sprites.enemy));
                EnemyList.Add(new Enemy(i * 8, -8, ConsoleColor.Cyan, Sprites.enemy));
                EnemyList.Add(new Enemy(i * 8, -4, ConsoleColor.Magenta, Sprites.enemy));
                EnemyList.Add(new Enemy(i * 8, 0, ConsoleColor.Magenta, Sprites.enemy));

                // If the level is greater than 4
                if (level > 4)
                {
                    // Adds an extra line of enemies
                    EnemyList.Add(new Enemy(i * 8, 4, ConsoleColor.Blue, Sprites.enemy));

                    // If the level is greate than 9
                    if (level > 9)
                    {
                        // Adds an extra line of enemies
                        EnemyList.Add(new Enemy(i * 8, 8, ConsoleColor.Blue, Sprites.enemy));

                        // If the level is greate than 14
                        if (level > 14)
                        {
                            // Adds an extra line of enemies
                            EnemyList.Add(new Enemy(i * 8, 12, ConsoleColor.DarkGreen, Sprites.enemy));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks if an enemy has reached the bottom of the screen
        /// </summary>
        public bool HasReachedBottom()
        {
            // Create a new bool for the return value
            bool retVal = false;

            // Go through every enemy on the enemy list
            for (int i = EnemyList.Count - 1; i >= 0; i--)
            {
                // If it has reached the bottom
                if (EnemyList[i].Coordinates.Y > _BOTTOM_BOUDARY)
                {
                    // Delete that enemy
                    EnemyList[i].Delete();

                    // Remove it from the list
                    EnemyList.Remove(EnemyList[i]);

                    // Sets the return value to true
                    retVal = true;
                }
            }

            // Return `reVal`
            return retVal;
        }
        #endregion
    }
}

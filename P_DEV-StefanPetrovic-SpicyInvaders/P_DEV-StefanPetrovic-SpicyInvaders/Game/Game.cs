/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : Class of the main game

using System;
using System.Collections.Generic;
using System.Threading;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    class Game
    {
        #region Attributs
        // Constant that holds the frame time
        private const int _FAME_TIME = 40;
        private const int _BASE_DELAY = 25;
        private const int _START_LIFES = 1;
        // The current score
        private int _score;
        // The current number of lifes
        private int _lifes;
        // The current level
        private int _level;
        // The current difficulty
        private int _isHard;
        // Bool knows if the game is over
        private bool _gameOver;
        // Username of the player
        private string _userName;
        // Collection with all the game objects
        List<GameObject> objectsCollection;
        // Create a list of bullets to delete
        List<Bullet> bulletsToDelete;
        // Create a new list of bullets
        List<Bullet> bullets;
        // Create a new Timer
        Timer counter;
        // Create a new blinkCounter
        Timer blinkCounter;
        // Instance of the ship
        Ship ship;
        // Instance of the enemies
        Enemies enemies;
        // Instance of the barriers
        Barriers barriers;
        // Instace of the explosions
        Explosions explosions;
        #endregion

        #region Propriétés des attributs
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructor for the Game class
        /// </summary>
        public Game()
        {
            // Initialize the lifes at 3
            _lifes = _START_LIFES;

            // Initialize the level at 1
            _level = 1;

            // Initialize the collection
            objectsCollection = new List<GameObject>();

            // Initialize the list of bullets to delete
            bulletsToDelete = new List<Bullet>(20);

            // Initialize the list of bullets
            bullets = new List<Bullet>(20);

            // Instantiate new enemies
            enemies = new Enemies(_level + _isHard);

            // Instantiate new Barriers
            barriers = new Barriers();

            // Instantiate new explosions
            explosions = new Explosions();

            // Game over is false when the game starts
            _gameOver = false;
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Game Loop Class
        /// </summary>
        public void Loop()
        {
            // Intantiate a new ship
            ship = new Ship(_level);

            // Add a ship to the objects collection
            objectsCollection.Add(ship);

            // Add the enemies to the objects collection
            objectsCollection.Add(enemies);

            // Add the barriers to the objects collection
            objectsCollection.Add(barriers);

            // Add the explosions to the objects collection
            objectsCollection.Add(explosions);

            // Clear the buffer from the menu render
            Buffer.ClearBuffer();

            /// Call a global Start method ///
            for (int i = 0; i < objectsCollection.Count; i++)
            {
                objectsCollection[i].Start();
            }

            // Create a new long start
            long start;

            // Create a new long timeToWait
            int timeToWait;

            // Calls the get ready animation before the game starts
            GetReady();

            // Loops...
            do
            {
                // The time in ticks at the start of the frame
                start = DateTime.Now.Ticks / 10000;

                /// Call a global update method ///
                for (int i = 0; i < objectsCollection.Count; i++)
                {
                    objectsCollection[i].Update();
                }

                // Displays the header
                DisplayHeader();

                // Check for hits
                EnemyDestroyedCheck();
                BarrierHitCheck();

                // If there's no enemies left
                if (enemies.EnemyList.Count == 0)
                {
                    // Call the level completed method
                    LevelCompleted();
                }

                // Check if the ship was hit
                if (ShipDestroyedCheck())
                {
                    // Call the life lost method
                    LifeLost();

                    _gameOver = _lifes == 0;
                }

                /// Render the frame ///
                Buffer.DisplayRender();

                // Get the delay needed
                timeToWait = (int)(start + _FAME_TIME - DateTime.Now.Ticks / 10000);

                // Delay the thread by a certain ammout of time so the game can be precieved
                Thread.Sleep(timeToWait < 0 ? 0 : timeToWait);

                // While the game is not over
            } while (!_gameOver);

            GameOver();

            UserNameWrite();

            // Clears the buffer
            Buffer.ClearBuffer();
        }

        private void GameOver()
        {
            // Create a new timer to be a counter for the animations duration
            Timer counter = new Timer(130);

            // Create a new timer for the blinking animation
            Timer blinker = new Timer(9);

            // Create a new bool
            bool displayMessage = false;

            // Clears the buffer
            Buffer.ClearBuffer();

            // Loops while the counter is counting
            while (counter.IsCounting())
            {
                // Sets the display score to true or false depending on the counter
                displayMessage = !blinker.IsCounting() ? !displayMessage : displayMessage;

                // If displayScore is true
                if (displayMessage)
                {
                    // Write an informational text saying that the level was completed
                    for (int i = 0; i < Sprites.gameOverString.Length; i++)
                    {
                        Buffer.WriteWithColor(0, 22 + i, " ", ConsoleColor.Blue);
                        Buffer.Write(32, 22 + i, Sprites.gameOverString[i]);
                    }
                }
                else
                {
                    // Delete the previously written text
                    for (int i = 0; i < Sprites.gameOverString.Length; i++)
                    {
                        Buffer.Write(32, 22 + i, "                                     ");
                    }
                }

                // Display the frame
                Buffer.DisplayRender();

                // Wait for 20 miliseconds
                Thread.Sleep(20);
            }
        }

        private void UserNameWrite()
        {
            Buffer.ClearBuffer();
            Buffer.WriteWithColor(0, 22, " ", ConsoleColor.Blue);
            Buffer.Delete(36, 22, "P L A Y E R   U S E R N A M E :");

            // Display the frame
            Buffer.DisplayRender();
            Console.SetCursorPosition(38, 24);
            Console.ForegroundColor = ConsoleColor.White;
            _userName = Console.ReadLine();

        }

        /// <summary>
        /// Get Ready method to animate the begining of the game or level
        /// </summary>
        private void GetReady()
        {
            // Create a new timer counter
            Timer counter = new Timer(160);

            // Create a new timer to blink the text
            Timer blinker = new Timer(9);

            // Create a new bool to display the text
            bool displayText = true;

            // While the counter is counting
            while (counter.IsCounting())
            {
                // Updates the header
                DisplayHeader();

                // Sets the `displayText` to true or false
                displayText = !blinker.IsCounting() ? !displayText : displayText;

                // If the displayText is true
                if (displayText)
                {
                    // Set a color and write to the buffer
                    Buffer.WriteWithColor(0, 50, " ", ConsoleColor.Blue);
                    Buffer.Write(45, 50, "Get Ready!");
                }
                // Else...
                else
                {
                    // Delete from the buffer
                    Buffer.Delete(45, 50, "          ");
                }

                // Move the enemies down
                enemies.MoveDown();

                /// Render the frame ///
                Buffer.DisplayRender();

                // Delay the loop
                Thread.Sleep(_BASE_DELAY);
            }

            // Delete the text again
            Buffer.Write(45, 50, "          ");
        }

        /// <summary>
        /// Check if the ship was destroyed
        /// </summary>
        private bool ShipDestroyedCheck() =>
            enemies.CheckShipHit(ship.Coordinates) || enemies.HasReachedBottom();

        /// <summary>
        /// Check if an enemy was destroyed
        /// </summary>
        private void EnemyDestroyedCheck()
        {
            // Clear the bullets to delete list
            bulletsToDelete.Clear();

            // Set bullets to be equal to the bullets list from the ship
            bullets = ship.ShipBullets.BulletsList;

            // If there's bullets on the scene
            if (bullets.Count > 0)
            {
                // Go through every bullet
                for (int i = 0; i < bullets.Count; i++)
                {
                    Vector enemyCoord;

                    // If the bullet has hit an enemy
                    if (enemies.CheckHit(bullets[i].Coordinates, out enemyCoord))
                    {
                        // Add the bullet to the bullets to delete
                        bulletsToDelete.Add(bullets[i]);

                        // Create new explosion
                        explosions.Add(enemyCoord, ExplosionType.SMALL);

                        // Increase the score
                        _score += 100;
                    }
                }

                // Delete the bullets
                ship.ShipBullets.DeleteBullets(bulletsToDelete);
            }
        }

        /// <summary>
        /// Check if a bullet has hit a barrier
        /// </summary>
        private void BarrierHitCheck()
        {
            // Create a new list of bullets to delete
            bulletsToDelete.Clear();

            // Create a new Vector to hold the bullet coordinate
            Vector bulletCoordinate;

            // Go through every bullet on the ship's bullet list
            foreach (Bullet bullet in ship.ShipBullets.BulletsList)
            {
                // Save it's coordinate to the Vector
                bulletCoordinate = bullet.Coordinates;

                // If that bullet is in range of a barrier
                if (bulletCoordinate.Y > 49 && bulletCoordinate.Y < 56)
                {
                    // Check if it hit the barrier
                    if (barriers.DeleteBarrierPart(bulletCoordinate))
                    {
                        // Add the bullet to the bullets to delete list
                        bulletsToDelete.Add(bullet);

                        // Remove the bullet from the screen
                        bullet.Delete();
                    }
                }
            }

            // Delete all the bullets that hit the barrier
            ship.ShipBullets.DeleteBullets(bulletsToDelete);

            // Clear the list
            bulletsToDelete.Clear();


            // Go through every bullet on the Enemies bullet list
            foreach (Bullet bullet in enemies.EnemyBullets.BulletsList)
            {
                // Save it's coordinate to the Vector
                bulletCoordinate = bullet.Coordinates;

                // If that bullet is in range of a barrier
                if (bulletCoordinate.Y > 50 & bulletCoordinate.Y < 55)
                {
                    // Check if it hit the barrier
                    if (barriers.DeleteBarrierPart(bulletCoordinate))
                    {
                        // Add the bullet to the bullets to delete list
                        bulletsToDelete.Add(bullet);

                        // Remove the bullet from the screen
                        bullet.Delete();
                    }
                }
            }

            // Delete all the bullets that hit the barrier
            enemies.EnemyBullets.DeleteBullets(bulletsToDelete);
        }

        /// <summary>
        /// The player lost a life
        /// </summary>
        private void LifeLost()
        {
            // Int with the time ammount the blinking will last
            int timer = (_lifes == 0) ? 50 : 150;

            // Create a new timer
            counter = new Timer(timer);

            // How long it takes for each blink
            blinkCounter = new Timer(6);

            // If we wan't to display the lifes
            bool displayLife = true;

            // Decrease the ammount of lifes
            _lifes--;

            // Set the life lost to true
            ship.LifeLost = true;

            // Reset the Enemies Move Up
            enemies.ResetMoveUp();

            // Set the ship destroyed true
            enemies.shipDestroyed = true;

            // Add an explosion
            explosions.Add(ship.Coordinates, ExplosionType.LARGE);

            // While the counter is counting
            while (counter.IsCounting())
            {
                // Go through all objects in the collection
                for (int i = 0; i < objectsCollection.Count; i++)
                {
                    // Update them
                    (objectsCollection[i] as GameObject).Update();
                }

                // Delay the thread by a certain ammout of time so the game can be precieved
                Thread.Sleep(_BASE_DELAY);

                // If the blink counter has stopped counting
                if (!blinkCounter.IsCounting())
                {
                    // If display life is true
                    if (displayLife)
                    {
                        // Set it to false
                        displayLife = false;

                        // Display the lifes
                        NumberManager.WriteLifes(_lifes + 1);
                        Buffer.DisplayRender();
                        NumberManager.WriteLifes(_lifes + 1);
                    }
                    // Else
                    else
                    {
                        // Set it to true
                        displayLife = true;

                        // Delete the lifes
                        NumberManager.DeleteLifes();
                    }
                }

                // Check for hits
                EnemyDestroyedCheck();
                BarrierHitCheck();

                /// Render the frame ///
                Buffer.DisplayRender();
            }

            // Reset the ship values
            ship.Init(_level);

            // Set the life lost to false
            ship.LifeLost = false;

            // Set the ship destroyed to false
            enemies.shipDestroyed = false;

            // Display the lifes
            NumberManager.WriteLifes(_lifes);
        }

        /// <summary>
        /// Is called when the level is completed to play animations and initialise the next level
        /// </summary>
        private void LevelCompleted()
        {
            // Create a new timer to be a counter for the animations duration
            Timer counter = new Timer(201);

            // Create a new timer for the blinking animation
            Timer blinker = new Timer(9);

            // Create a new bool
            bool displayScore = false;

            // Clears the buffer
            Buffer.ClearBuffer();

            // Loops while the counter is counting
            while (counter.IsCounting())
            {
                // Sets the display score to true or false depending on the counter
                displayScore = !blinker.IsCounting() ? !displayScore : displayScore;

                // If displayScore is true
                if (displayScore)
                {
                    // Write an informational text saying that the level was completed
                    Buffer.WriteWithColor(0, 22, " ", ConsoleColor.Blue);
                    Buffer.WriteWithColor(0, 24, " ", ConsoleColor.Blue);
                    Buffer.Delete(36, 22, "L E V E L  C O M P L E T E D!");
                    Buffer.Delete(38, 24, "Level bonus 1000 points!");
                    NumberManager.WriteLevel(_level);
                }
                else
                {
                    // Delete the previously written text
                    Buffer.Write(36, 22, "                             ");
                    Buffer.Write(38, 24, "                        ");
                    NumberManager.DeleteLevel();
                }

                // Updates the score
                _score += 5;
                NumberManager.WriteScore(_score);

                // Updates the header
                DisplayHeader();

                // Display the frame
                Buffer.DisplayRender();

                // Wait for 20 miliseconds
                Thread.Sleep(20);
            }

            // Removes the text in the middle of the screen
            Buffer.Write(36, 22, "                             ");
            Buffer.Write(38, 24, "                        ");

            // Increases the level
            _level++;

            // Updates the level number
            NumberManager.WriteLevel(_level);

            // Delays for 800 miliseconds
            Thread.Sleep(800);

            // Initializes the next level
            InitNextLevel();
        }

        /// <summary>
        /// Initialize the next level
        /// </summary>
        private void InitNextLevel()
        {
            // Reset the ship values
            ship.Init(_level);

            // Instantiate new enemies
            enemies = new Enemies(_level + _isHard);

            // Instantiate new barriers
            barriers = new Barriers();

            // Instantiate new explosions
            explosions = new Explosions();

            // Start the barriers
            barriers.Start();

            // Clears the objects collection
            objectsCollection.Clear();

            // Add the ship to the collection
            objectsCollection.Add(ship);

            // Add the enemies to the collection
            objectsCollection.Add(enemies);

            // Add the barriers to the collection
            objectsCollection.Add(barriers);

            // Add the explosions to the collection
            objectsCollection.Add(explosions);

            // Call the get ready method
            GetReady();
        }

        /// <summary>
        /// Displays the header
        /// </summary>
        private void DisplayHeader()
        {
            // Set the color to red
            Buffer.WriteWithColor(0, 0, " ", ConsoleColor.Red);
            Buffer.WriteWithColor(0, 5, " ", ConsoleColor.Red);

            // Loop 100 times
            for (int i = 0; i < 100; i++)
            {
                // Write to the buffer
                Buffer.Write(i, 0, "-");
                Buffer.Write(i, 5, "-");
            }

            // Change the color to blue
            Buffer.WriteWithColor(0, 1, " ", ConsoleColor.Blue);

            // Write to the buffer
            Buffer.Write(1, 1, "Score:");
            Buffer.Write(45, 1, "Level:");
            Buffer.Write(80, 1, "Lifes:");

            // Write the numbers to the buffer
            NumberManager.WriteScore(_score);
            NumberManager.WriteLevel(_level);
            NumberManager.WriteLifes(_lifes);
        }

        public void IsHard()
        {
            _isHard = 12;
        }
        #endregion
    }
}

/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : Create the ship that player control

using System;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class Ship inherits from GameObject0
    /// </summary>
    class Ship : GameObject
    {
        #region Attributs
        /// <summary>
        /// Number of bullets for initialization
        /// </summary>
        private const int INIT_NUM_BULLETS = 3;
        /// <summary>
        /// Max number of bullets
        /// </summary>
        private const int MAX_NUM_BULLETS = 8;
        /// <summary>
        /// Left boundary
        /// </summary>
        private const int LEFT_BOUNDARY = 0;
        /// <summary>
        /// Right boudary
        /// </summary>
        private const int RIGHT_BOUNDARY = 93;
        /// <summary>
        /// Upper boundary
        /// </summary>
        private const int UPPER_BOUNDARY = 6;
        /// <summary>
        /// Speed of the bullet
        /// </summary>
        private const int BULLET_SPEED = 1;
        /// <summary>
        /// Speed of the movement
        /// </summary>
        private const int MOVE_SPEED = 2;
        /// <summary>
        /// X position
        /// </summary>
        private const int INIT_X = 47;
        /// <summary>
        /// Y position
        /// </summary>
        private const int INIT_Y = 55;
        /// <summary>
        /// Coordinates of the ship
        /// </summary>
        private Vector _coordinates;
        /// <summary>
        /// Sprite for the ship
        /// </summary>
        private string[] _sprite;
        /// <summary>
        /// Current type of movement the ship has
        /// </summary>
        private MoveType _currentMove;
        /// <summary>
        /// If the game is paused
        /// </summary>
        private bool _pause;
        /// <summary>
        /// Timer for movement
        /// </summary>
        private Timer _moveTimer;
        /// <summary>
        /// Total number of bullets
        /// </summary>
        private int _numOfBullets;
        #endregion

        #region Propriétés des attributs
        /// <summary>
        /// Vector for Coordinates
        /// </summary>
        public Vector Coordinates => _coordinates;
        /// <summary>
        /// Getter for the ShipBullets
        /// </summary>
        public Bullets ShipBullets
        {
            get;
            private set;
        }
        /// <summary>
        /// Getter, setter to see if a life was lost
        /// </summary>
        public bool LifeLost
        {
            get;
            set;
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Ship Class constructor
        /// </summary>
        /// <param name="level">The current level</param>
        public Ship(int level)
        {
            // Set the starting number of bullets
            _numOfBullets = INIT_NUM_BULLETS;
            // Increase the number of bullets every 4 levels up to a maximum of 8 bullets
            Timer bulletCounter = new Timer(4);
            // Loop the level amount of times
            for (int i = 0; i < level; i++)
            {
                // If the bullet counter has stopped and the num of bullets is less than the max
                if (!bulletCounter.IsCounting() && (_numOfBullets < MAX_NUM_BULLETS))
                {
                    _numOfBullets += 2;
                }
            }
            // Set the ship coordinates to the starting position
            _coordinates = new Vector(INIT_X, INIT_Y);
            // Instatiate the ship bullets
            ShipBullets = new Bullets(UPPER_BOUNDARY, _numOfBullets, BULLET_SPEED);
            // Instantiate a new Timer
            _moveTimer = new Timer(MOVE_SPEED);
            // Set the ship sprite
            _sprite = Sprites.player;
            // Set the start move type
            _currentMove = MoveType.NONE;
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Initializes the ship values
        /// </summary>
        /// <param name="level">The current level</param>
        public void Init(int level)
        {
            // Set the ship coordinates
            _coordinates = new Vector(INIT_X, INIT_Y);
            // Set the type of movement the ship starts with
            _currentMove = MoveType.NONE;
            // Set the starting number of bullets
            _numOfBullets = INIT_NUM_BULLETS;
            // Increase the number of bulets every 4 levels up to a maximum of 8 bullets
            Timer bulletCounter = new Timer(4);
            // Loop the level amount of times
            for (int i = 0; i < level; i++)
            {
                // If the bullet counter has stopped and the num of bullets is less than the max
                if (!bulletCounter.IsCounting() && (_numOfBullets < MAX_NUM_BULLETS))
                {
                    // Increase the number of bullets by 2
                    _numOfBullets += 2;
                }
            }
            // Instatiate the ship bullets
            ShipBullets = new Bullets(UPPER_BOUNDARY, _numOfBullets, BULLET_SPEED);
        }
        /// <summary>
        /// The Update method for the ship (Called once every frame)
        /// </summary>
        public override void Update()
        {
            if (!LifeLost)
            {
                // Check for user input
                GetInput();
                // What to write to the buffer
                WriteToBuffer();
                // Moves the ship
                Move();
            }
            // Update the bullets
            ShipBullets.UpdateBullets();
        }
        /// <summary>
        /// Writes the ship sprite to the buffer
        /// </summary>
        private void WriteToBuffer()
        {
            // Go through the ship sprite array
            for (int i = 0; i < _sprite.Length; i++)
            {
                // Write each string to the buffer
                Buffer.Write(_coordinates.X, _coordinates.Y + i, _sprite[i]);
                // Set the color to white
                Buffer.WriteWithColor(0, _coordinates.Y + i, " ", ConsoleColor.White);
            }
        }
        /// <summary>
        /// Checks for the user input
        /// </summary>
        private void GetInput()
        {
            // Create a new ConsoleKeyInfo
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            // Loop
            while (Console.KeyAvailable)
            {
                // Set the keyInfo to the read key
                keyInfo = Console.ReadKey(true);
            }
            // Check what key the user pressed
            switch (keyInfo.Key)
            {
                // If the user pressed the Left Arrow
                case ConsoleKey.LeftArrow:
                    // Change the ship movement to go Left
                    _currentMove = MoveType.LEFT;
                    break;
                // If the user pressed the Right Arrow
                case ConsoleKey.RightArrow:
                    // Change the ship movement to go Right
                    _currentMove = MoveType.RIGHT;
                    break;
                // If the user pressed the X key
                case ConsoleKey.X:
                    // Stop the ship movement
                    _currentMove = MoveType.NONE;
                    break;
                // If the user pressed space bar
                case ConsoleKey.Spacebar:
                    ShipBullets.Add(_coordinates.X + 3, _coordinates.Y, MoveType.UP);
                    break;
                // If the user pressed the Escape
                case ConsoleKey.Escape:
                    _pause = true;
                    while (_pause)
                    {
                        for (int i = 0; i < Sprites.pauseString.Length; i++)
                        {
                            Buffer.WriteWithColor(0, 22 + i, " ", ConsoleColor.Blue);
                            Buffer.Write(0, 22 + i, Sprites.pauseString[i]);
                        }
                        Buffer.DisplayRender();
                        if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                        {
                            _pause = false;
                        }
                    }
                    for (int i = 0; i < Sprites.pauseString.Length; i++)
                    {
                        Buffer.Delete(0, 22 + i, Sprites.pauseString[1]);
                    }
                    Buffer.Delete(_coordinates.X, _coordinates.Y + 2, "           ");
                    break;
            }
        }
        /// <summary>
        /// Moves the ship based on it's current direction
        /// </summary>
        private void Move()
        {
            // If the move timer has stopped counting
            if (!_moveTimer.IsCounting())
            {
                // The ship can move
                // If the ship is moving left and hasn't reached the boundary
                if (_currentMove == MoveType.LEFT && _coordinates.X > LEFT_BOUNDARY)
                {
                    // Move the ship left
                    _coordinates.X--;
                }
                // If the ship is moving right and hasn't reached the boundary
                else if (_currentMove == MoveType.RIGHT && _coordinates.X < RIGHT_BOUNDARY)
                {
                    // Move the ship right
                    _coordinates.X++;
                }
            }
        }
        #endregion
    }
}

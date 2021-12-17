using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class to hold and manage all the barriers in the game
    /// </summary>
    class Barriers : GameObject
    {
        // Necessary constants for this script
        private const int _NUM_OF_BARRIERS = 4;
        private const int _POSITION_OFFSET = 20;
        private const int _START_X = 16;
        private const int _Y_POS = 51;

        // List with all the barriers
        private List<Barrier> _barriers;

        /// <summary>
        /// Barriers class constructor
        /// </summary>
        public Barriers()
        {
            // Initialize the list of barriers
            _barriers = new List<Barrier>();

            // Create new barriers and add them to the list
            for (int i = 0; i < _NUM_OF_BARRIERS; i++)
            {
                _barriers.Add(new Barrier(_START_X + i * _POSITION_OFFSET, _Y_POS));
            }
        }

        /// <summary>
        /// Is called at the start of the game
        /// </summary>
        public override void Start()
        {
            // Write the barriers to the buffer
            WriteBarriers();
        }

        /// <summary>
        /// The update method
        /// </summary>
        public override void Update()
        {
            // Go through every barrier on the list and set it's color to green
            for (int i = 0; i < _barriers.Count; i++)
            {
                _barriers[i].SetColor();
            }
        }

        /// <summary>
        /// Writes the barriers to the buffer
        /// </summary>
        private void WriteBarriers()
        {
            // Go through every barrier on the list and write it to the buffer
            for (int i = 0; i < _barriers.Count; i++)
            {
                _barriers[i].Write();
            }
        }

        /// <summary>
        /// Deletes a part of the barrier
        /// </summary>
        /// <param name="bulletCoordinate">The coordinate of the bullet</param>
        /// <returns></returns>
        public bool DeleteBarrierPart(Vector bulletCoordinate)
        {
            bool retVal = false;

            for (int i = 0; i < _barriers.Count; i++)
            {
                if (_barriers[i].IsNotDestroyed(bulletCoordinate))
                {
                    _barriers[i].SetDestroyed(bulletCoordinate);
                    retVal = true;
                }
            }

            return retVal;
        }
    }
}

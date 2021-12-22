/// ETML
/// Auteur : Stefan Petrovic
/// Date : 11.12.2021
/// Description : This class is used to create a generig timer for several diferent purposes

namespace P_DEV_StefanPetrovic_SpicyInvaders
{
    /// <summary>
    /// Class Timer
    /// </summary>
    class Timer
    {
        #region Attributs
        /// <summary>
        /// What limit we can count to
        /// </summary>
        int _limit;

        /// <summary>
        /// The counter
        /// </summary>
        int _counter;
        #endregion

        #region Propriétés des attributs
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructor for the Timer class
        /// </summary>
        /// <param name="_limit">How much to count to</param>
        public Timer(int limit)
        {
            // Set the limit to be equal to the passed value
            this._limit = limit;

            // Set the counter to start at 0
            _counter = 0;
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Returns a true or false base on if the timer is still counting or not
        /// </summary>
        /// <returns>true or false base on if the timer is still counting or not</returns>
        public bool IsCounting()
        {
            // Increase counter by 1 each frame
            _counter++;

            // If the counter is greater or equal to the set limit
            if (_counter >= _limit)
            {
                // Set the counter to 0
                _counter = 0;

                // Return false
                return false;
            }

            // Return true
            return true;
        }
        #endregion
    }
}

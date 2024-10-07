using UnityEngine;

namespace Caught.Services
{
    public static class PauseService
    {
        #region Properties

        public static bool IsPaused { get; private set; }

        #endregion

        #region Public methods

        public static void Pause()
        {
            Time.timeScale = 0;
            IsPaused = true;
        }

        public static void Unpause()
        {
            Time.timeScale = 1;
            IsPaused = false;
        }

        #endregion
    }
}
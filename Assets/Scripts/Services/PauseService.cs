using Caught.Game;
using UnityEngine;

namespace Caught.Services
{
    public  class PauseService : SingletonMonoBehaviour<PauseService>
    {
        #region Properties

        public bool IsPaused { get; private set; }

        #endregion

        #region Public methods

        public void Pause()
        {
            Time.timeScale = 0;
            IsPaused = true;
        }

        public void Unpause()
        {
            Time.timeScale = 1;
            IsPaused = false;
        }

        #endregion
    }
}
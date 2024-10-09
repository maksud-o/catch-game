using Caught.Services;
using Caught.Services.Game;
using UnityEngine;

namespace Caught.UI.Game
{
    public class GameOverWindow : MonoBehaviour
    {
        #region Unity lifecycle

        private void Start()
        {
            PlayerStatsService.Instance.OnGameOver += ActivateWindow;

            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            PlayerStatsService.Instance.OnGameOver -= ActivateWindow;
        }

        #endregion

        #region Private methods

        private void ActivateWindow()
        {
            gameObject.SetActive(true);
            PauseService.Instance.Pause();
        }

        #endregion
    }
}
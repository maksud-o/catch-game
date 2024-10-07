using Caught.Game;
using Caught.Services;
using UnityEngine;

namespace Caught.UI.Game
{
    public class GameOverWindow : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerStatsController _playerStatsController;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _playerStatsController.OnZeroLives += ActivateWindow;

            gameObject.SetActive(false);
        }

        #endregion

        #region Private methods

        private void ActivateWindow()
        {
            gameObject.SetActive(true);
            PauseService.Pause();
        }

        #endregion
    }
}
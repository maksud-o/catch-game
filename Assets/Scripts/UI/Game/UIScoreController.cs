using Caught.Game;
using TMPro;
using UnityEngine;

namespace Caught.UI.Game
{
    public class UIScoreController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private PlayerStatsController _playerStatsController;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _playerStatsController.OnScoreChanged += OnScoreChangedCallback;
        }

        #endregion

        #region Private methods

        private void OnScoreChangedCallback()
        {
            _scoreText.text = _playerStatsController.Score.ToString();
        }

        #endregion
    }
}
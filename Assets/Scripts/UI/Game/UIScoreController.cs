using Caught.Services.Game;
using TMPro;
using UnityEngine;

namespace Caught.UI.Game
{
    public class UIScoreController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI _scoreText;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            PlayerStatsService.Instance.OnScoreChanged += OnScoreChangedCallback;

            _scoreText.text = PlayerStatsService.Instance.Score.ToString();
        }

        private void OnDestroy()
        {
            PlayerStatsService.Instance.OnScoreChanged -= OnScoreChangedCallback;
        }

        #endregion

        #region Private methods

        private void OnScoreChangedCallback()
        {
            _scoreText.text = PlayerStatsService.Instance.Score.ToString();
        }

        #endregion
    }
}
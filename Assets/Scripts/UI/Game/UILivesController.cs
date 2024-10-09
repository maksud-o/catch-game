using System.Linq;
using Caught.Services.Game;
using UnityEngine;

namespace Caught.UI.Game
{
    public class UILivesController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _livesContainer;
        [SerializeField] private GameObject _lifePrefab;

        private GameObject[] _lives;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            PlayerStatsService.Instance.OnLivesChanged += LivesChangedCallback;

            SetupLives();
        }

        private void OnDestroy()
        {
            PlayerStatsService.Instance.OnLivesChanged -= LivesChangedCallback;
        }

        #endregion

        #region Private methods

        private void ChangeLives(int amount)
        {
            bool isAdded = amount > 0;
            amount = Mathf.Abs(amount);
            GameObject[] lives = _lives.Where(l => l.activeSelf == !isAdded).ToArray();
            if (lives.Length == 0)
            {
                return;
            }

            for (var i = 0; i < amount; i++)
            {
                lives[i].SetActive(isAdded);
            }
        }

        private void LivesChangedCallback(int amount)
        {
            ChangeLives(amount);
        }

        private void SetupLives()
        {
            while (_livesContainer.transform.childCount > 0)
            {
                DestroyImmediate(_livesContainer.transform.GetChild(0).gameObject);
            }

            _lives = new GameObject[PlayerStatsService.Instance.MaxLives];
            for (var i = 0; i < _lives.Length; i++)
            {
                _lives[i] = Instantiate(_lifePrefab, _livesContainer.transform);
                _lives[i].SetActive(false);
            }

            ChangeLives(PlayerStatsService.Instance.StartingLives);
        }

        #endregion
    }
}
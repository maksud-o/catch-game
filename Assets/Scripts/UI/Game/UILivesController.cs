using System.Linq;
using Caught.Game;
using UnityEngine;

namespace Caught.UI.Game
{
    public class UILivesController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _livesContainer;
        [SerializeField] private GameObject _lifePrefab;
        [SerializeField] private PlayerStatsController _playerStatsController;

        private GameObject[] _lives;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _playerStatsController.OnLivesAdded += LivesAddedCallback;
            _playerStatsController.OnLivesRemoved += LivesRemovedCallback;

            SetupLives();
        }

        private void OnDestroy()
        {
            _playerStatsController.OnLivesAdded -= LivesAddedCallback;
            _playerStatsController.OnLivesRemoved -= LivesRemovedCallback;
        }

        #endregion

        #region Private methods

        private void LivesAddedCallback(int amount)
        {
            GameObject[] inactiveLives = _lives.Where(l => !l.activeSelf).ToArray();
            for (var i = 0; i < amount; i++)
            {
                inactiveLives[i].SetActive(true);
            }
        }

        private void LivesRemovedCallback(int amount)
        {
            GameObject[] activeLives = _lives.Where(l => l.activeSelf).ToArray();
            for (var i = 0; i < amount; i++)
            {
                activeLives[i].SetActive(false);
            }
        }

        private void SetupLives()
        {
            while (_livesContainer.transform.childCount > 0)
            {
                DestroyImmediate(_livesContainer.transform.GetChild(0).gameObject);
            }

            _lives = new GameObject[_playerStatsController.MaxLives];
            for (var i = 0; i < _lives.Length; i++)
            {
                _lives[i] = Instantiate(_lifePrefab, _livesContainer.transform);
                _lives[i].SetActive(false);
            }
        }

        #endregion
    }
}
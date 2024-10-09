using System;
using UnityEngine;

namespace Caught.Services.Game
{
    public class PlayerStatsService : SingletonMonoBehaviour<PlayerStatsService>
    {
        #region Variables

        [Header("Lives Settings")]
        [SerializeField] private int _maxLives = 5;
        [SerializeField] private int _startingLives = 3;

        private int _lives;

        #endregion

        #region Events

        public event Action OnGameOver;

        public event Action<int> OnLivesChanged;
        public event Action OnScoreChanged;

        #endregion

        #region Properties

        public int MaxLives => _maxLives;
        public int Score { get; private set; }
        public int StartingLives => _startingLives;

        #endregion

        #region Public methods

        public void ChangeLives(int amount)
        {
            _lives += amount;

            if (amount == 0)
            {
                Debug.LogError($"({nameof(ChangeLives)}) Zero lives added.");
            }

            OnLivesChanged?.Invoke(amount);

            if (_lives <= 0)
            {
                Score = 0;
                _lives = _startingLives;
                OnGameOver?.Invoke();
            }
        }

        public void ChangeScore(int amount)
        {
            Score += amount;
            if (Score < 0)
            {
                Score = 0;
                return;
            }

            OnScoreChanged?.Invoke();
        }

        #endregion

        #region Protected methods

        protected override void AwakeAddition()
        {
            base.AwakeAddition();
            _lives = _startingLives;
        }

        #endregion
    }
}
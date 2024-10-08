using System;
using Caught.Game.Items;
using UnityEngine;

namespace Caught.Game
{
    public class PlayerStatsController : MonoBehaviour
    {
        #region Variables

        [Header("Lives Settings")]
        [SerializeField] private int _maxLives = 5;
        [SerializeField] private int _startingLives = 3;

        private int _lives;

        #endregion

        #region Events

        public event Action<int> OnLivesAdded;
        public event Action<int> OnLivesRemoved;
        public event Action OnScoreChanged;
        public event Action OnZeroLives;

        #endregion

        #region Properties

        public int MaxLives => _maxLives;
        public int Score { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            PositiveItem.OnCaught += ChangeScore;
            PositiveItem.OnFall += ChangeLives;
            NegativeItem.OnCaught += ChangeScore;
            SpecialItemAddLife.OnCaught += ChangeLives;

            ChangeLives(_startingLives);
            Score = 0;
            OnScoreChanged?.Invoke();
        }

        private void OnDestroy()
        {
            PositiveItem.OnCaught -= ChangeScore;
            PositiveItem.OnFall -= ChangeLives;
            NegativeItem.OnCaught -= ChangeScore;
        }

        #endregion

        #region Private methods

        private void ChangeLives(int amount)
        {
            amount = NormalizeLivesAmount(amount);
            _lives += amount;

            switch (amount)
            {
                case < 0:
                    OnLivesRemoved?.Invoke(Mathf.Abs(amount));
                    break;
                case > 0:
                    OnLivesAdded?.Invoke(Mathf.Abs(amount));
                    break;
                default: return;
            }

            if (_lives <= 0)
            {
                OnZeroLives?.Invoke();
            }
        }

        private void ChangeScore(int amount)
        {
            Score += amount;
            if (Score < 0)
            {
                Score = 0;
                return;
            }

            OnScoreChanged?.Invoke();
        }

        private int NormalizeLivesAmount(int amount)
        {
            if (_lives + amount > _maxLives)
            {
                amount -= amount + _lives - _maxLives;
            }
            else if (_lives + amount < 0)
            {
                amount += Mathf.Abs(_lives + amount);
            }

            return amount;
        }

        #endregion
    }
}
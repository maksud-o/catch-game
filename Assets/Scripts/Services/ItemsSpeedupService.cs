using System;
using System.Collections;
using UnityEngine;

namespace Caught.Services
{
    public class ItemsSpeedupService : SingletonMonoBehaviour<ItemsSpeedupService>
    {
        #region Variables

        [SerializeField] private float _itemsSpeedupInterval = 10f;

        #endregion

        #region Events

        public event Action OnSpeedup;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            StartCoroutine(SpeedupCountdown());
        }

        #endregion

        #region Private methods

        private IEnumerator SpeedupCountdown()
        {
            while (true)
            {
                yield return new WaitForSeconds(_itemsSpeedupInterval);
                OnSpeedup?.Invoke();
            }
        }

        #endregion
    }
}
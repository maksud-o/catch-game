using UnityEngine;

namespace Caught
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        #region Properties

        public static T Instance { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }

            Instance = GetComponent<T>();
        }

        #endregion
    }
}
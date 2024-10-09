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
                Debug.LogError($"{this} already exists.");
                Destroy(gameObject);
            }

            Instance = GetComponent<T>();
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);

            AwakeAddition();
        }

        #endregion

        #region Protected methods

        protected virtual void AwakeAddition() { }

        #endregion
    }
}
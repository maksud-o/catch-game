using UnityEngine;

namespace Caught
{
    public class GlobalSystems : MonoBehaviour
    {
        #region Unity lifecycle

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        #endregion
    }
}
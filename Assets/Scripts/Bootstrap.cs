using Caught.Services;
using UnityEngine;

namespace Caught
{
    public class Bootstrap : MonoBehaviour
    {
        #region Variables

        [SerializeField] private string _startSceneName;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            SceneService.LoadScene(_startSceneName);
        }

        #endregion
    }
}
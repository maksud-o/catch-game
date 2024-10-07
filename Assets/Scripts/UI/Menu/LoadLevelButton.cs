using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Caught.UI.Menu
{
    [RequireComponent(typeof(Button))]
    public class LoadLevelButton : MonoBehaviour
    {
        #region Variables

        [SerializeField] private string _levelSceneName;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(LoadLevel);
        }

        #endregion

        #region Private methods

        private void LoadLevel()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(_levelSceneName);
        }

        #endregion
    }
}
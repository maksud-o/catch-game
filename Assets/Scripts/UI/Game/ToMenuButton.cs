using Caught.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Caught.UI.Game
{
    [RequireComponent(typeof(Button))]
    public class ToMenuButton : MonoBehaviour
    {
        #region Variables

        [SerializeField] private string _menuSceneName;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(ToMenu);
        }

        private void ToMenu()
        {
            SceneService.LoadScene(_menuSceneName);
            PauseService.Unpause();
        }

        #endregion
    }
}
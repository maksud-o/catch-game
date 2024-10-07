using Caught.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Caught.UI.Game
{
    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour
    {
        #region Unity lifecycle

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(Restart);
        }

        #endregion

        #region Private methods

        private void Restart()
        {
            SceneService.ResetActiveScene();
            PauseService.Unpause();
        }

        #endregion
    }
}
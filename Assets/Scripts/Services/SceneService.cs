using UnityEngine.SceneManagement;

namespace Caught.Services
{
    public static class SceneService
    {
        #region Public methods

        public static void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene(sceneName, mode);
            // SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }

        public static void ResetActiveScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}
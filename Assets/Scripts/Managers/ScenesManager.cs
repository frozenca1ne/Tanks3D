using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Managers
{
    public class ScenesManager : MonoBehaviour
    {
        #region Singleton
        public static ScenesManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            
            }
        }
        #endregion

        public void LoadActiveScene()
        {
            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }
        public void LoadNextLevel()
        {
            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex + 1);
        }
        public void LoadFirstScene()
        {
            SceneManager.LoadScene(0);
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}

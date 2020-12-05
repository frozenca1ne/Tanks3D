using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Managers
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private Button pauseButton = default;


        private bool isPause = false;


        public void PauseGame(bool pause)
        {
            Time.timeScale = pause ? 0 : 1;
        }
    }
}

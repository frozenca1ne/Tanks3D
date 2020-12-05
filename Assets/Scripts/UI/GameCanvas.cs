using DG.Tweening;
using Managers;
using Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class GameCanvas : MonoBehaviour
    {

        [SerializeField] private CanvasGroup settings;
        [SerializeField] private Transform settingsPoint;
        [SerializeField] private static GameManager gameManager;

        [SerializeField] private Button resumeButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private CanvasGroup pausePanel;
        
        private float m_UpgradePanelStartY;
        private bool m_IsPanelActive;
        private bool m_IsPause;
        private AudioListener m_listener;

        private void OnEnable()
        {
            settingsButton.onClick.AddListener(OpenSettings);
            pauseButton.onClick.AddListener(OpenPausePanel);
            mainMenuButton.onClick.AddListener(LoadMainMenu);
            resumeButton.onClick.AddListener(ClosePausePanel);
        }
        
        private void Start()
        {
            m_listener = FindObjectOfType<AudioListener>();
            m_UpgradePanelStartY = settings.transform.position.y;
        }

        private void OpenSettings()
        {
            var positionY = m_IsPanelActive ? m_UpgradePanelStartY :settingsPoint.position.x;
            settings.gameObject.transform.DOMoveY(positionY, 1f);
            m_IsPanelActive = !m_IsPanelActive;
        }

        private void OpenPausePanel()
        {
            gameManager.TransitionTo(gameManager.GetComponent<PauseState>());
            if (m_IsPause) return;
            m_IsPause = true;
            m_listener.DOPause();
            Time.timeScale = 0;
            pausePanel.gameObject.SetActive(true);
            
        }

        private void ClosePausePanel()
        {
            gameManager.TransitionTo(gameManager.GetComponent<PlayingState>());
            m_IsPause = false;
            m_listener.DOPlay();
            Time.timeScale = 1;
            pausePanel.gameObject.SetActive(false);
            
        }

        private static void LoadMainMenu()
        {
            gameManager.sceneLoadingSettings.LoadingScene = 0;
            SceneManager.LoadSceneAsync("Loading");
            ScenesManager.Instance.LoadFirstScene();
        }
        
    }
}

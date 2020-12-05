using DG.Tweening;
using Scripts.Managers;
using SOData;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private Button multiplayer;
        [SerializeField] private Button settings;
        [SerializeField] private Button quit;
        [SerializeField] private TMPro.TMP_Text coins;

        [SerializeField] private CanvasGroup settingPanel;
        [SerializeField] private Transform openPoint;
        [SerializeField] private CanvasGroup singlePlayerPanel;
        [SerializeField] private CanvasGroup levelPanel;

        [SerializeField] private TankInfo playerInfo;


        private float m_UpgradePanelStartY;
        private float levelsY;
        private bool m_IsPanelActive;
        private bool isLevels;

        private void OnEnable()
        {
            settings.onClick.AddListener(OpenSettings);
            multiplayer.onClick.AddListener(LoadMultiplayer);
            
        }

        private void Start()
        {
            m_UpgradePanelStartY = settingPanel.transform.position.y;
            levelsY = levelPanel.transform.position.y;
        }

        private void OpenSettings()
        {
            var positionY = m_IsPanelActive ? m_UpgradePanelStartY : openPoint.position.x;
            settingPanel.gameObject.transform.DOMoveY(positionY, 1f);
            m_IsPanelActive = !m_IsPanelActive;
        }

        private void LoadMultiplayer()
        {
            var positionY = isLevels ? levelsY : openPoint.position.x;
            levelPanel.gameObject.transform.DOMoveY(positionY, 1f);
            m_IsPanelActive = !m_IsPanelActive;
        }

       
    }
}
using SOData;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UI
{
    public class UpgradeMenu : MonoBehaviour
    {
        [SerializeField] private UpgradeWindow upWindow;
        [SerializeField] private Transform openPoint = default;

        [SerializeField] private TankInfo playerInfo;

        [SerializeField] private Button showUpdateMenu;
    
        [SerializeField] private Slider level1;
        [SerializeField] private Slider level2;
        [SerializeField] private Slider level3;
    
        [SerializeField] private Button level1Button;
        [SerializeField] private Button level2Button;
        [SerializeField] private Button level3Button;
    
        private float m_UpgradePanelStartX;
        private bool isPanelActive;

        private void OnEnable()
        {
            showUpdateMenu.onClick.AddListener(ShowUpgradePanel);
        }

        private void Start()
        {
            m_UpgradePanelStartX = upWindow.transform.position.x;
        }

        public void ShowUpgradePanel()
        {
            var positionX = isPanelActive ? m_UpgradePanelStartX : openPoint.position.x;
            upWindow.transform.DOMoveX(positionX, 1f);
            isPanelActive = !isPanelActive;
        }
    }
}

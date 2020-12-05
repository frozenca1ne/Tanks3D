using System;
using DG.Tweening;
using Scripts.Managers;
using SOData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelPanel : MonoBehaviour
    {
        [SerializeField] private ImageScript[] scenes;

        
        [SerializeField] private SceneLoadingSettings sceneLoadingSettings;
        [SerializeField] private TMP_Text levelTimeText;
        [SerializeField] private GameObject content;
        [SerializeField] private Scrollbar scrollbar;
        [SerializeField] private Button rightArrowButton;
        [SerializeField] private Button leftArrowButton;
        [SerializeField] private Button playButton;

        private int m_LevelIndex = 0;

        // Start is called before the first frame update
        private void Awake()
        {
      
            levelTimeText.text = TimeSpan.FromSeconds(scenes[m_LevelIndex].LevelTime).ToString(@"hh\:mm\:ss");

            var rectTransform = content.GetComponent<RectTransform>();
            var rect = rectTransform.rect;
            rectTransform.rect.Set(rect.x, rect.y,
                rect.width * scenes.Length, rect.height);
            scrollbar.numberOfSteps = scenes.Length;
            AddUIListeners();
        }


        private void ScrollbarChanged(float value)
        {
            m_LevelIndex = (int)Mathf.Clamp01(1f / scrollbar.numberOfSteps * value * 10);
            levelTimeText.text = TimeSpan.FromSeconds(scenes[m_LevelIndex].LevelTime).ToString(@"hh\:mm\:ss");
        }

        private void PlayButtonClick()
        {
            ButtonClickAnimation(playButton);
            transform.DOLocalMoveY(0f, 1f);
        }

        private void LeftClick()
        {
            ButtonClickAnimation(leftArrowButton);
            scrollbar.value = Mathf.Clamp01(scrollbar.value - 1f / scrollbar.numberOfSteps - 0.1f);
        }

        private void RightClick()
        {
            ButtonClickAnimation(rightArrowButton);
            scrollbar.value = Mathf.Clamp01(scrollbar.value + 1f / scrollbar.numberOfSteps + 0.1f);
        }

        public void LoadLevelClick()
        {
            sceneLoadingSettings.LoadingScene = m_LevelIndex;
            SceneManager.LoadSceneAsync("Loading");
        }

        private void ButtonClickAnimation(Button button)
        {
            DOTween.Sequence()
                .Append(button.transform.DOScale(0.9f, 0.1f))
                .Append(button.transform.DOScale(1f, 0.1f));
        }

        private void AddUIListeners()
        {
            scrollbar.onValueChanged.AddListener(ScrollbarChanged);
            playButton.onClick.AddListener(PlayButtonClick);
            leftArrowButton.onClick.AddListener(LeftClick);
            rightArrowButton.onClick.AddListener(RightClick);
            
        }
    }
}

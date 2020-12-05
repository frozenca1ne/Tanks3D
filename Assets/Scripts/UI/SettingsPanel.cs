using Scripts.Managers;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;


namespace UI
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private CanvasGroup settingsPanel;
    
        [Header("AudioSettings")]
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider effectsSlider;
        [SerializeField] private Slider drivingSlider;
    
        [SerializeField] private TMPro.TMP_Dropdown quality;
        [SerializeField] private Button resetButton;
        [SerializeField] private Button closeSettings;

        private void OnEnable()
        {
            quality.onValueChanged.AddListener(delegate
            {
                ChangeGameQuality(quality);
            });
        
            //Set all sliders start value from AudioManager
            musicSlider.value = AudioManager.Instance.GetMusicLvl();
            effectsSlider.value = AudioManager.Instance.GetSfxLvl();
            drivingSlider.value = AudioManager.Instance.GetDrivingLvl();
            //Subscribe to slider value change
            musicSlider.onValueChanged.AddListener(delegate
            {
                AudioManager.Instance.SetMusicLvl(musicSlider.value);
            });
            effectsSlider.onValueChanged.AddListener(delegate
            {
                AudioManager.Instance.SetSfxLvl(musicSlider.value);
            });
            drivingSlider.onValueChanged.AddListener(delegate
            {
                AudioManager.Instance.SetDrivingLvl(musicSlider.value);
            });
        
            resetButton.onClick.AddListener(ResetAll);
        
        }

        private void OnDisable()
        {
            quality.onValueChanged.RemoveListener(delegate
            {
                ChangeGameQuality(quality);
            });
        
            musicSlider.onValueChanged.RemoveListener(delegate
            {
                AudioManager.Instance.SetMusicLvl(musicSlider.value);
            });
            effectsSlider.onValueChanged.RemoveListener(delegate
            {
                AudioManager.Instance.SetSfxLvl(musicSlider.value);
            });
            drivingSlider.onValueChanged.RemoveListener(delegate
            {
                AudioManager.Instance.SetDrivingLvl(musicSlider.value);
            });
            resetButton.onClick.RemoveListener(ResetAll);
        }

        private void ChangeGameQuality(TMPro.TMP_Dropdown index)
        {
            switch (index.value)
            {
                case 0:
                    //Quality settings set to 'Fastest'
                    QualitySettings.SetQualityLevel(0, true);
                    break;
                case 1:
                    //Quality settings set to 'Fast'
                    QualitySettings.SetQualityLevel(1, true);
                    break;
                case 2:
                    //Quality settings set to 'Simple'
                    QualitySettings.SetQualityLevel(2, true);
                    break;
                case 3:
                    //Quality settings set to 'Good'
                    QualitySettings.SetQualityLevel(3, true);
                    break;
                case 4:
                    //Quality settings set to 'Beautiful'
                    QualitySettings.SetQualityLevel(4, true);
                    break;
                case 5:
                    //Quality settings set to 'Fantastic'
                    QualitySettings.SetQualityLevel(5, true);
                    break;
            
            }
       
        }

        private void ResetAll()
        {
            PlayerPrefs.DeleteAll();   
        }
    }
}

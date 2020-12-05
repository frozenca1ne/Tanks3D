using UnityEngine;
using UnityEngine.Audio;

namespace Scripts.Managers
{
    public class AudioManager : MonoBehaviour
    {
        #region Singleton
        public static AudioManager Instance { get; private set; }

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

        [SerializeField] private AudioMixer masterMixer = default;
        [SerializeField] private float startMusicValue = 1f;
        [SerializeField] private float startEffectsValue = 1f;
        [SerializeField] private float startDrivingValue = 1f;

    
    
        private const string PrefsMusicVolume = "MusicVolume";
        private const string PrefsEffectsVolume = "SFXVolume";
        private const string PrefsDrivingVolume = "DrivingVolume";
    

        public void SetMusicLvl(float lvl)
        {
            masterMixer.SetFloat(PrefsMusicVolume, lvl);
            PlayerPrefs.SetFloat(PrefsMusicVolume, lvl);
        }
        public void SetSfxLvl(float lvl)
        {
            masterMixer.SetFloat(PrefsEffectsVolume, lvl);
            PlayerPrefs.SetFloat(PrefsMusicVolume, lvl);
        }
        public void SetDrivingLvl(float lvl)
        {
            masterMixer.SetFloat(PrefsDrivingVolume, lvl);
            PlayerPrefs.SetFloat(PrefsMusicVolume, lvl);
        }

        public float GetMusicLvl()
        {
            var lvl = PlayerPrefs.GetFloat(PrefsMusicVolume, startMusicValue);
            return lvl;
        }
        public float GetSfxLvl()
        {
            var lvl = PlayerPrefs.GetFloat(PrefsEffectsVolume, startEffectsValue);
            return lvl;
        }
        public float GetDrivingLvl()
        {
            var lvl = PlayerPrefs.GetFloat(PrefsDrivingVolume, startDrivingValue);
            return lvl;
        }
    
    }
}

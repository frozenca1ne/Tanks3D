using UnityEngine;

namespace UI
{
    public class ImageScript : MonoBehaviour
    {
        [SerializeField] private float buildIndex;
        [HideInInspector] public float LevelTime;

        private void Awake()
        {
            if (PlayerPrefs.HasKey(buildIndex.ToString()))
            {
                LevelTime = PlayerPrefs.GetFloat(buildIndex.ToString());
            }
            else
            {
                LevelTime = 0f;
                PlayerPrefs.SetFloat(buildIndex.ToString(), LevelTime);
            }
        }
    }
}

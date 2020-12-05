using UnityEngine;

namespace SOData
{
    [CreateAssetMenu(fileName = "SceneLoading",menuName = "ScenesLoading/LoadingScene")]
    public class SceneLoadingSettings : ScriptableObject
    {
        [SerializeField]private int loadingScene;

        public int LoadingScene
        {
            get => loadingScene;
            set => loadingScene = value;
        }
    }
}

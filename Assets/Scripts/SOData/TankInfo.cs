using UnityEngine;

namespace SOData
{
    [CreateAssetMenu(fileName = "TankInfo", menuName = "TankInfo/TankInfo", order = 0)]
    public class TankInfo : ScriptableObject
    {
        [Header("General")] [SerializeField] private string id = "";
        [SerializeField] private Color tankColor = default;
        [Header("Variable")] [SerializeField] private FloatReference hp;
        [SerializeField] private FloatReference speed;
        [SerializeField] private FloatReference turnSpeed;
        [SerializeField] private FloatReference coins;


        public string ID => id;

        public Color TankColor => tankColor;

        public FloatReference Hp => hp;

        public FloatReference Speed => speed;

        public FloatReference TurnSpeed => turnSpeed;

        public FloatReference Coins => coins;

        
    }
}

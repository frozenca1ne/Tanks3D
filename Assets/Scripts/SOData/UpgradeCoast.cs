using UnityEngine;

namespace Scripts.SOData
{
    [CreateAssetMenu(fileName = "UpgradeCoast",menuName = "SinglePlayer/UpgradeCoast",order = 0)]
    public class UpgradeCoast : ScriptableObject
    {
        [SerializeField] private float speedCost;
        [SerializeField] private float turnSpeedCost;
        [SerializeField] private float shootSpeedCost;
        [SerializeField] private float damageCost;

        [SerializeField] private float upgradeValue;

        public float SpeedCost => speedCost;

        public float TurnSpeedCost => turnSpeedCost;

        public float ShootSpeedCost => shootSpeedCost;

        public float DamageCost => damageCost;

        public float UpgradeValue => upgradeValue;
    }
}

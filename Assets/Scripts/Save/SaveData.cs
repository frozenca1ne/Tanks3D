using System;
using SOData;


namespace Save
{
    [Serializable]
    public class SaveData
    {
        public float currentHp;
        public float currentSpeed;
        public float turnSpeed;
        public float coins;

        public SaveData(TankInfo tankInfo)
        {
            currentHp = tankInfo.Hp;
            currentSpeed = tankInfo.Speed;
            turnSpeed = tankInfo.Speed;
            coins = tankInfo.Coins;
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.ObjectPool
{
    [Serializable]
    public class PoolObjectInfo 
    {
        public string Name;
        public int Amount;
        public GameObject PrefabObjectPool;
        public List<GameObject> PoolObjects;
    }
}

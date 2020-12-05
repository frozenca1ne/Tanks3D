using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.ObjectPool
{
    public class PoolManager : MonoBehaviour
    {

        public static PoolManager Instance { get; set; }

        [SerializeField] private List<PoolObjectInfo> poolObjectInfo = new List<PoolObjectInfo>();

        public List<PoolObjectInfo> PoolObjectInfos => poolObjectInfo;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        
            InitPool();
        }
        private void InitPool()
        {
            if (poolObjectInfo == null) return;

            foreach (var pool in poolObjectInfo)
            {
                for (var i = 0; i <pool.Amount; i++)
                {
                    var o = Instantiate(pool.PrefabObjectPool);
                    o.name = $"Pool Object {pool.Name} {i}";
                    o.SetActive(false);
                    pool.PoolObjects.Add(o);
                }
            }
        }

        private static GameObject GetFirstFreeObject(PoolObjectInfo pool)
        {return  pool.PoolObjects.FirstOrDefault(x => !x.activeInHierarchy);
        }

        private PoolObjectInfo GetPoolByName(string poolName)
        {
            return  poolObjectInfo.FirstOrDefault(x => x.Name == poolName);
        }
    
        public GameObject GetObjectFromPool(string poolName)
        { var f = GetPoolByName(poolName);
            var obj = GetFirstFreeObject(f);
            obj.SetActive(true);
            return obj;
        }
        public GameObject GetObjectFromPool(string poolName,Vector3 pos, Quaternion rot)
        {
            var f = GetPoolByName(poolName);
            var obj = GetFirstFreeObject(f);
            obj.transform.position = pos;
            obj.transform.rotation = rot;
            obj.SetActive(true);
            return obj;
        }

        public void ReturnToPool(string poolName,GameObject obj)
        {
            var f = GetPoolByName(poolName);
            if (f == null) return;
            var o = f.PoolObjects.Find(x => x.gameObject == obj);
            if (o != null)
            {
                o.SetActive(false);
            }
        }

        public IEnumerator ReturnToPoolWithDelay(string poolName, GameObject obj, float delay = 1f)
        {
            yield return new WaitForSeconds(delay);
            var f = GetPoolByName(poolName);
            if (f != null)
            {
                Debug.LogError("pool name not found " + poolName);
                var o = f.PoolObjects.Find(x => x.gameObject == obj);
                if (o != null)
                {
                    o.SetActive(false);
                }
            }

            yield return null;
        }
    }
}

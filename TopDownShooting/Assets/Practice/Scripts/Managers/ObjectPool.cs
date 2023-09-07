using System.Collections.Generic;
using UnityEngine;

namespace Practice.Scripts.Managers
{
    public class ObjectPool<T> where T : UnityEngine.Object
    {
        private Dictionary<string, T> _pool;
        private Dictionary<string, T> _Prefabs;
        public ObjectPool()
        {
            _pool = new Dictionary<string, T>();
        }

        public T Get(string Id)
        {
            T result;
            if (!_pool.TryGetValue(Id, out result))
            {
                T obj;
                if (_Prefabs.TryGetValue(Id, out obj))
                {
                    T newObj = GameObject.Instantiate(obj);
                    return newObj;
                }
                else
                {
                    Debug.Log($"{Id}는 등록 된적 없는 프리팹입니다");
                }
            }
            return result;
        }

        public void SetPrefabs(Dictionary<string, T> newPool)
        {
            _Prefabs = newPool;
        }
    }
}
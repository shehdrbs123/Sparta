using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Practice.Scripts.Managers
{
    public class GameObjectPool
    {
        private Dictionary<string, HashSet<GameObject>> _pool;
        private Dictionary<string, GameObject> _original;
        public GameObjectPool()
        {
            _pool = new Dictionary<string,HashSet<GameObject>>();
        }

        public GameObject Get(string Id)
        {
            HashSet<GameObject> list;
            GameObject result =null;
            if (_pool.TryGetValue(Id, out list))
            {
                foreach (var obj in list)
                {
                    if (!obj.activeSelf)
                    {
                        result = obj;
                    }
                }
            }
            else
            {
                list = new HashSet<GameObject>();
                _pool.Add(Id,list);
            }

            if (!result)
            {
                if (_original.TryGetValue(Id,out GameObject prefab))
                {
                    result = GameObject.Instantiate(prefab);
                    list.Add(result);
                }
                else
                {
                    Debug.Log($"{Id}의 이름을 가진 프리팹은 없습니다.");
                }
            }
            return result;
        }

        public void Init(Dictionary<string, GameObject> newOriginalObjects)
        {
            _original = newOriginalObjects;
        }
    }
}
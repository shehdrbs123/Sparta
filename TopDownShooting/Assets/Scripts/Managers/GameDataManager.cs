using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
namespace Practice.Scripts.Managers
{
    public class GameDataManager : MonoBehaviour
    {
        private Dictionary<string, Actor> Actors = new Dictionary<string, Actor>();
        private int duplicatedCount = 0;
        private GameObject _player;

        public GameObject Player
        {
            get
            {
                if (_player == null)
                {
                    _player = GameObject.FindGameObjectWithTag("Player");
                }

                return _player;
            }
            set
            {
                _player = value;
            }
        }
        
        /// <summary>
        /// 이름을 넣을 때 유니크하게 넣어주세요
        /// </summary>
        /// <param name="nameID">유니크 한 이름</param>
        /// <param name="obj">저장할 오브젝트</param>
        /// <returns>유니크 할 경우 nameID가 그대로 반환, 유니크 하지 않다면 nameID+식별번호로 반환</returns>
        public string Regist(string nameID, Actor obj)
        {
            if (!Actors.TryAdd(nameID, obj))
            {
                nameID += duplicatedCount;
                ++duplicatedCount;
                Actors.Add(nameID,obj);
            }

            return nameID;
        }
        
        public void CancelRegist(string nameID)
        {
            Actors.Remove(nameID);
        }
        
        
        public Actor Get(string nameID)
        {
            Actor obj = null;
            Actors.TryGetValue(nameID, out obj);
            return obj;
        }

        
    }
}
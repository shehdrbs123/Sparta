using System;
using Practice.Scripts.Managers;
using UnityEngine;
namespace Practice.Scripts
{
    public class Actor : MonoBehaviour 
    {
        [SerializeField] protected string nameID;
        protected static GameDataManager _gameDataManager;
        public event Action OnNameChanged;
        
        protected virtual void Awake()
        {
            _gameDataManager = GameManager.Instance.GameDataManager;
        }

        private void RegistToGameDataManager()
        {
#if UNITY_EDITOR
            if (nameID == null)
            {
                nameID = name;
            }
#endif
            nameID = _gameDataManager.Regist(nameID,this);   
        }

        private void RemoveToGameDataManager()
        {
            _gameDataManager.CancelRegist(nameID);
        }

        public void ChangeRegistName(string newName)
        {
            _gameDataManager.CancelRegist(nameID);
            nameID = newName;
            _gameDataManager.Regist(nameID, this);
            OnNameChanged?.Invoke();
        }
        
        /// <summary>
        /// 오버라이드가 필요할 경우 기존 메소드 먼저 실행해 주세요
        /// </summary>
        protected virtual void OnEnable()
        {
            RegistToGameDataManager();
        }
        
        /// <summary>
        /// 오버라이드가 필요할 경우 기존 메소드 먼저 실행해 주세요
        /// </summary>
        protected virtual void OnDisable()
        {
            RemoveToGameDataManager();
        }

        public string GetName()
        {
            return nameID;
        }
    }
}
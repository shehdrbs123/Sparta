using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Practice.Scripts
{
    public class Player : Actor
    {
        [SerializeField] private TextMesh nameTag;
        protected override void Awake()
        {
            base.Awake();
            _gameDataManager.Player = gameObject;
        }

        protected void Start()
        {
            OnNameChanged += nameTagChange;
            nameTagChange();
            DontDestroyOnLoad(gameObject);
        }

        public void nameTagChange()
        {
            nameTag.text = nameID;
        }
        public void StartInit(Scene arg0, LoadSceneMode arg1)
        {
           EnableComponents(true);
        }

        public void EnableComponents(bool isEnable)
        {
            MonoBehaviour[] Components = GetComponents<MonoBehaviour>();
            Array.ForEach(Components,x => x.enabled = isEnable);
        }
    }
}
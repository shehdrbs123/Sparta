using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Practice.Scripts.UI
{
    public class NameUI : BaseUI
    {
        [SerializeField] private InputField textField;
        [SerializeField] private Button Button;
        private Player player;
        public void OnSubmit()
        {
            player.ChangeRegistName(textField.text);
            
            if (SceneManager.GetActiveScene().name != "MapGenScene")
            {
                SceneManager.sceneLoaded += player.StartInit;
                SceneManager.LoadScene("MapGenScene");
            }

            gameObject.SetActive(false);
        }

        private void Start()
        {
            player = _gameDataManager.Player.GetComponent<Player>();
            textField.text = player.GetName();
            Button.onClick.AddListener(OnSubmit);
        }
    }
}
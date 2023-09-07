using System.Collections;
using System.Collections.Generic;
using Practice.Scripts;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameManager.Instance.GetPlayer();
        if (player == null)
        {
            player = Instantiate(playerPrefab, transform.position, transform.rotation);
            player.GetComponent<Player>().EnableComponents(true);
            GameManager.Instance.GameDataManager.Player = player;
        }

        player.transform.position = transform.position;
    }
}

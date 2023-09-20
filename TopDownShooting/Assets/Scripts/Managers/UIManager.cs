using System;
using Practice.Scripts.Common;
using Practice.Scripts.Managers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    private GameObjectPool pool;
    private bool IsInputIgnore=false;
    private HashSet<GameObject> enableSet;
    private List<InputAction> needIgnore;
    private void Awake()
    {
        pool = new GameObjectPool();
        var Prefabs = ClassGetter.GetResourcePrefabs<GameObject>("Prefabs/UI");
        pool.Init(Prefabs);
        enableSet = new HashSet<GameObject>();
        needIgnore = new List<InputAction>();
    }

    private void Start()
    {
        
    }

    public GameObject GetUI(string name)
    {
        GameObject obj;
        obj = pool.Get(name);
        return obj;
    }

    public void EnablePanel(GameObject enabled)
    {
        enabled.SetActive(true);
        enableSet.Add(enabled);
        CheckInputIgnore();
    }

    public void DisablePanel(GameObject disabled)
    {
        disabled.SetActive(false);
        enableSet.Remove(disabled);
        CheckInputIgnore();
    }

    private void CheckInputIgnore()
    {
        if (needIgnore.Count == 0)
        {
            var player = GameManager.Instance.GetPlayer();

            if (player)
            {
                var input = player.GetComponent<PlayerInput>();
                needIgnore.Add(input.actions.FindAction("Move"));
                needIgnore.Add(input.actions.FindAction("Look"));
                needIgnore.Add(input.actions.FindAction("Fire"));
            }
            else
                return;
        }

        if (enableSet.Count > 0)
        {
            needIgnore.ForEach((x)=> x.Disable());
        }
        else
        {
            needIgnore.ForEach((x)=> x.Enable());
        }
    }
    
}

using Practice.Scripts.Common;
using Practice.Scripts.Managers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    private ObjectPool<GameObject> pool;
    private bool IsInputIgnore=false;
    private void Awake()
    {
        pool = new ObjectPool<GameObject>();
        Dictionary<string, GameObject> Prefabs = ClassGetter.GetResourcePrefabs<GameObject>("Prefabs/UI");
        pool.SetOriginalObjects(Prefabs);
    }

    public GameObject GetUI(string name)
    {
        GameObject obj;
        obj = pool.Get(name);
        return obj;
    }

    public void InputIgnore()
    {
        PlayerInput test = GameManager.Instance.GetPlayer().GetComponent<PlayerInput>();
        if(IsInputIgnore)
            test.DeactivateInput();
        else
            test.ActivateInput();

        IsInputIgnore = !IsInputIgnore;
    }
}

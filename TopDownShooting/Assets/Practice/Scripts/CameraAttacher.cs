using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttacher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(GameManager.Instance.GetPlayer().transform);
    }
}

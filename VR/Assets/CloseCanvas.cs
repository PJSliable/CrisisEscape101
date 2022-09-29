using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCanvas : MonoBehaviour
{
    public GameObject item;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Close", delay);
    }

    // Update is called once per frame
    void Close()
    {
        item.SetActive(false);
    }
}

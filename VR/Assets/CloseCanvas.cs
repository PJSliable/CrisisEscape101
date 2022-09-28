using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCanvas : MonoBehaviour
{
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Close", 7f);
    }

    // Update is called once per frame
    void Close()
    {
        item.SetActive(false);
    }
}

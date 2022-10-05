using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonCollides : MonoBehaviour
{
    public GameObject TargetBG;
    
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        GameObject collided = other.gameObject;
        Debug.Log(collided.name);
        if ((collided.name == "LeftBaseController" || collided.name == "RightBaseController") && !TargetBG.active)
            TargetBG.SetActive(!TargetBG.active);
    }
}

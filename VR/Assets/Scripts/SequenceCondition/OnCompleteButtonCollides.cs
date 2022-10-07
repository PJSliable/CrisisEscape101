using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCompleteButtonCollides : MonoBehaviour
{
    public GameObject TargetBG;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        GameObject collided = other.gameObject;
        //Debug.Log(collided.name);
        if ((collided.name == "LeftBaseController" || collided.name == "RightBaseController"))
            SceneManager.LoadScene("Mainmenu");
    }
}

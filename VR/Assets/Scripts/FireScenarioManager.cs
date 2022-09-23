using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireScenarioManager : MonoBehaviour
{

    public GameObject[] guideMessages;

    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    public static int stage = 0;

    void Start()
    {
        object1.GetComponent<XRGrabInteractable>().enabled = true;
        object1.GetComponent<Sequence>().enabled = true;
        object2.GetComponent<XRGrabInteractable>().enabled = false;
        object1.GetComponent<Sequence>().enabled = false;
        object3.GetComponent<XRGrabInteractable>().enabled = false;
        object1.GetComponent<Sequence>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

}


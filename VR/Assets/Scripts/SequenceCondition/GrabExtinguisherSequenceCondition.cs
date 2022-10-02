using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabExtinguisherSequenceCondition : NextSequenceActivator
{

    public GameObject _XROrigin;
    public GameObject fireExtinguisher;
    GameObject previous;
    GameObject next;
    //public GameObject _parent;

    void Start()
    {
        //_parent = gameObject.transform.parent.gameObject;
        //_XROrigin = GameObject.Find("XR Origin"); 
        previous = gameObject.transform.GetChild(FireScenarioManager.stage - 1).gameObject;
        next = gameObject.transform.GetChild(FireScenarioManager.stage + 1).gameObject;

        Debug.Log(_XROrigin.transform.position);
        Debug.Log(fireExtinguisher.transform.position);
    }

    void Update()
    {
        if (FireScenarioManager.stage == 7 && Vector3.Distance(fireExtinguisher.transform.position,_XROrigin.transform.position) <= 2f)
        {
            FireScenarioManager.stage++;
            next.SetActive(true);
        }
    }
}

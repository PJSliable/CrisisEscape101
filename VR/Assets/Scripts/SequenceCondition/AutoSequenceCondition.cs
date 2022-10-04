using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSequenceCondition : NextSequenceActivator
{

    public GameObject previous;
    public GameObject previousCanvas;
    public GameObject present;

    void Update()
    {
        if (!previousCanvas.active)
        {
            previous.SetActive(false);
            base.ActivateNextGuideline(present);
            this.enabled = false;
        }
    }
}

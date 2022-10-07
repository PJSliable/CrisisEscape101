using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterSequenceCondition : NextSequenceActivator
{
    
    public GameObject nextSeqGuideline;

    // Update is called once per frame
    void Update()
    {
        if (FireScenarioManager.isEnd && FireScenarioManager.stage == transform.GetSiblingIndex()) {
            Debug.Log(transform.GetSiblingIndex());
            FireScenarioManager.stage++;
            base.ActivateNextGuideline(nextSeqGuideline);
            gameObject.SetActive(false);
        }
    }
}


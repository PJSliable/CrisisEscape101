using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainDoorOpenSequenceCondition : NextSequenceActivator
{
    
    public GameObject nextSeqGuideline;

    // Update is called once per frame
    void Update()
    {
        if (FireScenarioManager.isOut && FireScenarioManager.stage == transform.GetSiblingIndex()) {
            Debug.Log(transform.GetSiblingIndex());
            FireScenarioManager.stage++;
            base.ActivateNextGuideline(nextSeqGuideline);
            gameObject.SetActive(false);
        }
    }
}

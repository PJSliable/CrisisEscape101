using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayExtinguisherSequenceCondition : NextSequenceActivator
{
    public GameObject nextSeqGuideline;

    // Update is called once per frame
    void Update()
    {
        if (FireScenarioManager.fireNum <= 0) {
            nextSeqGuideline.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMaskSequenceCondition : NextSequenceActivator
{
    public GameObject nextSeqGuideline;

    // Update is called once per frame
    void Update()
    {
        if (FireScenarioManager.isGasMaskOn) {
            FireScenarioManager.stage++;
            base.ActivateNextGuideline(nextSeqGuideline);
            gameObject.SetActive(false);
        }
    }
}

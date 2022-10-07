using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrainDoorUnlockerSequenceCondition : NextSequenceActivator
{
    public GameObject trainDoorUnlocker;
    public GameObject nextSeqGuideline;
    XRBaseInteractable mInteractable;
    
    // Start is called before the first frame update
    void Start()
    {
        mInteractable = trainDoorUnlocker.GetComponent<XRBaseInteractable>();
        mInteractable.lastSelectExited.AddListener(OnLastSelectExited);

    }

    public virtual void OnLastSelectExited(SelectExitEventArgs args) => ActivateNextSequence();
    // Update is called once per frame
    public void ActivateNextSequence() {
        base.ActivateNextGuideline(nextSeqGuideline);
        FireScenarioManager.stage++;
        gameObject.SetActive(false);
    }
}

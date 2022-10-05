using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabExtinguisherSequenceCondition : NextSequenceActivator
{

    public GameObject fireExtinguisher;
    public GameObject nextSeqGuideline;
    //GameObject previous;
    GameObject next;
    XRBaseInteractable mInteractable;
    //public GameObject _parent;

    void Start()
    {
        mInteractable = fireExtinguisher.GetComponent<XRBaseInteractable>();
        mInteractable.firstSelectEntered.AddListener(OnFirstSelectEntered);
    }

    public virtual void OnFirstSelectEntered(SelectEnterEventArgs args) => ActivateNextSequence();

    public void ActivateNextSequence()
    {
        if (FireScenarioManager.stage == 6)
        {
            base.ActivateNextGuideline(nextSeqGuideline);
            FireScenarioManager.stage++;
            gameObject.SetActive(false);
        }
    }

    /*void Update()
    {
        if (FireScenarioManager.stage == 6 && Vector3.Distance(fireExtinguisher.transform.position,_XROrigin.transform.position) <= 2f)
        {
            FireScenarioManager.stage++;
            base.ActivateNextGuideline(next);
            base.ActivateNextInteractable(fireExtinguisher);
        }
    }*/
}

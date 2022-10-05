using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CallTrainDriverSequenceCondition : NextSequenceActivator
{
    // Start is called before the first frame update

    //public GameObject nextSeqObject;
    public GameObject InteractableObject;
    XRBaseInteractable mInteractable;
    public GameObject nextSeqGuideline;

    void OnEnable()
    {
        mInteractable = InteractableObject.GetComponent<XRBaseInteractable>();
        mInteractable.firstSelectEntered.AddListener(OnFirstSelectEntered);
    }

    public virtual void OnFirstSelectEntered(SelectEnterEventArgs args) => ActivateNextSequence();

    public void ActivateNextSequence()
    {
        if (FireScenarioManager.stage == 3)
        {
            base.ActivateNextGuideline(nextSeqGuideline);
            FireScenarioManager.stage++;
            InteractableObject.GetComponent<Rigidbody>().useGravity = true;
            Debug.Log(InteractableObject.GetComponent<Rigidbody>().isKinematic);
            gameObject.SetActive(false);
        }
    }

    /*public void ActivateNextGuideline(GameObject nextSeqObject)
    {
        nextSeqObject.SetActive(true);
    }*/
}
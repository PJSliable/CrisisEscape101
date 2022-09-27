using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NextSequenceActivator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject nextSeqObject;
    XRBaseInteractable mInteractable;
    //public GameObject nextSeqGuidelines;

    void Start()
    {
        mInteractable = GetComponent<XRBaseInteractable>();
        mInteractable.firstSelectEntered.AddListener(OnFirstSelectEntered);
    }

    protected virtual void OnFirstSelectEntered(SelectEnterEventArgs args) => ActivateNextSequence();

    void ActivateNextSequence ()
    {
        nextSeqObject.GetComponent<XRGrabInteractable>().enabled = true;
        nextSeqObject.GetComponent<Sequence>().enabled = true;
    }
}

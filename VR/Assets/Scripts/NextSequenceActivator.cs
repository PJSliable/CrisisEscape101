using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NextSequenceActivator : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject nextSeqObject;
    //XRBaseInteractable mInteractable;
    //public GameObject nextSeqGuidelines;

 /*   void Start()
    {
        mInteractable = GetComponent<XRBaseInteractable>();
        mInteractable.firstSelectEntered.AddListener(OnFirstSelectEntered);
    }

    public virtual void OnFirstSelectEntered(SelectEnterEventArgs args) => ActivateNextSequence();*/

    public void ActivateNextInteractable (GameObject nextSeqObject)
    {
        nextSeqObject.GetComponent<XRBaseInteractable>().enabled = true;
        //nextSeqObject.GetComponent<Sequence>().enabled = true;
    }

    public void ActivateNextGuideline (GameObject nextSeqObject)
    {
        nextSeqObject.SetActive(true);
    }
}

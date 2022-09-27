using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PinController : MonoBehaviour
{

    GameObject pinObject;
    XRBaseInteractable m_Interactable;

    void OnEnable()
    {
        pinObject = GameObject.Find("안전핀.004");
        m_Interactable = GetComponent<XRBaseInteractable>();
        m_Interactable.firstSelectEntered.AddListener(OnFirstSelectEntered);
        m_Interactable.lastSelectExited.AddListener(OnLastSelectExited);
    }

    protected virtual void OnLastSelectExited(SelectExitEventArgs args) => DeactivatePin();
    protected virtual void OnFirstSelectEntered(SelectEnterEventArgs args) => ActivatePin();

    void DeactivatePin()
    {
        if (pinObject != null)
            pinObject.GetComponent<XRBaseInteractable>().enabled = false;
    }

    void ActivatePin()
    {
        if (pinObject != null)
            pinObject.GetComponent<XRBaseInteractable>().enabled = true;
    }
}

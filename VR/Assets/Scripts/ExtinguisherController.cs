using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExtinguisherController : MonoBehaviour
{
    GameObject pinObject;
    XRBaseInteractable m_Interactable;
    ParticleSystem powderParticles;

    void OnEnable()
    {
        pinObject = GameObject.Find("안전핀.004");
        powderParticles = transform.Find("소화기").gameObject.transform.Find("FirePoint").gameObject.transform.Find("PressurisedSteam").gameObject.GetComponent<ParticleSystem>();
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
        powderParticles.Stop();
    }

    void ActivatePin()
    {
        if (pinObject != null)
            pinObject.GetComponent<XRBaseInteractable>().enabled = true;
        if (pinObject == null || pinObject.GetComponent<Joint>() == null)
            powderParticles.Play();
    }
}

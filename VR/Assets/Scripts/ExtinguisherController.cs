using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExtinguisherController : MonoBehaviour
{
    GameObject pinObject;
    GameObject firePoint;
    XRBaseInteractable m_Interactable;
    ParticleSystem powderParticles;
    GameObject rayCastActor;
    AudioSource spraySound;

    void OnEnable()
    {
        pinObject = GameObject.Find("안전핀.004");
        firePoint = transform.Find("소화기").gameObject.transform.Find("FirePoint").gameObject;
        powderParticles = firePoint.transform.Find("PressurisedSteam").GetComponent<ParticleSystem>();
        rayCastActor = firePoint.transform.Find("ExtinguishRayCast").gameObject;
        m_Interactable = GetComponent<XRBaseInteractable>();
        m_Interactable.firstSelectEntered.AddListener(OnFirstSelectEntered);
        m_Interactable.lastSelectExited.AddListener(OnLastSelectExited);
        spraySound = GetComponent<AudioSource>();
    }

    protected virtual void OnLastSelectExited(SelectExitEventArgs args) => DeactivatePin();
    protected virtual void OnFirstSelectEntered(SelectEnterEventArgs args) => ActivatePin();

    void DeactivatePin()
    {
        if (pinObject != null)
            pinObject.GetComponent<XRBaseInteractable>().enabled = false;
        powderParticles.Stop();
        rayCastActor.SetActive(false);
        spraySound.Stop();
    }

    void ActivatePin()
    {
        if (pinObject != null)
            pinObject.GetComponent<XRBaseInteractable>().enabled = true;
        if (pinObject == null || pinObject.GetComponent<Joint>() == null) {
            powderParticles.Play();
            rayCastActor.SetActive(true);
            spraySound.Play();
        }
    }
}

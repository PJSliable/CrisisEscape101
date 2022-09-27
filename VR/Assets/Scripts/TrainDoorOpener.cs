using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrainDoorOpener : MonoBehaviour
{

    public bool isLeft;
    public Rigidbody rigidBody;
    XRBaseInteractable m_Interactable;

    void OnEnable()
    {
        m_Interactable = GetComponent<XRBaseInteractable>();
        m_Interactable.firstSelectEntered.AddListener(OnFirstSelectEntered);
        rigidBody = GetComponent<Rigidbody>();
    }

    protected virtual void OnFirstSelectEntered(SelectEnterEventArgs args) => OpenDoor();

    void OpenDoor()
    {
        StartCoroutine(DoorMove());
    }

    IEnumerator DoorMove()
    {
        Debug.Log("act!");
        rigidBody.velocity = new Vector3(0, 0, 0.5f);
        if (isLeft)
            rigidBody.velocity *= -1;
        
        yield return new WaitForSeconds(0.6f);

        rigidBody.velocity = new Vector3(0, 0, 0);

    }
}

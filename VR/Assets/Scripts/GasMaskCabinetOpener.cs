using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GasMaskCabinetOpener : MonoBehaviour
{

    public bool isLeft;
    public Rigidbody rigidBody;
    XRBaseInteractable m_Interactable;
    private bool isOpen = false;
    Vector3 angleVelocity;

    void OnEnable()
    {
        m_Interactable = GetComponent<XRBaseInteractable>();
        m_Interactable.firstSelectEntered.AddListener(OnFirstSelectEntered);
        rigidBody = GetComponent<Rigidbody>();
        angleVelocity = new Vector3(0, -180, 0);
    }

    protected virtual void OnFirstSelectEntered(SelectEnterEventArgs args) => OpenDoor();


    void FixedUpdate()
    {
        if (isOpen)
        {
            StartCoroutine(DoorMove());
            Quaternion deltaRotation = Quaternion.Euler(angleVelocity * Time.fixedDeltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }
    }

    void OpenDoor()
    {
        isOpen = true;
    }

    IEnumerator DoorMove()
    { 
        
        yield return new WaitForSeconds(1f);
        isOpen = false;

    }
}

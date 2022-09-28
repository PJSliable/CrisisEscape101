using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PinFall : MonoBehaviour
{
    public Rigidbody rigidBody;
    XRBaseInteractable m_Interactable;
    Joint jointComp;

    void OnEnable()
    {
        m_Interactable = GetComponent<XRBaseInteractable>();
        m_Interactable.lastSelectExited.AddListener(OnLastSelectExited);
        rigidBody = GetComponent<Rigidbody>();
        jointComp = GetComponent<Joint>();
    }

    protected virtual void OnLastSelectExited(SelectExitEventArgs args) => DropPin();

    void DropPin()
    {
        rigidBody.useGravity = true;
        Destroy(jointComp);
        Invoke("DestroyPin", 5.0f);
        //m_Interactable.enabled = false;
    }

    void DestroyPin()
    {
        Destroy(this.gameObject);
    }
}

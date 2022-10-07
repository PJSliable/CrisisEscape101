using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ActiveDoor : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    XRGrabInteractable leftXr;
    XRGrabInteractable rightXr;

    // Start is called before the first frame update
    void Start()
    {
        leftXr = leftDoor.GetComponent<XRGrabInteractable>();
        rightXr = rightDoor.GetComponent<XRGrabInteractable>();
        Debug.Log("비상벨브");
    }

    public void activeDoor()
    {
        leftXr.enabled = true;
        rightXr.enabled = true;
        Debug.Log("비상벨브 잡기");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

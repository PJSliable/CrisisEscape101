using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XROriginTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "BrailleBlockCollider")
            FireScenarioManager.isOut = true;
        else if (other.gameObject.name == "EndPointCollider")
            FireScenarioManager.isEnd = true;
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class FireScenarioManager : MonoBehaviour
{

    public GameObject[] guideMessages;
    public static FireScenarioManager instance;

    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public static Volume GasMask;

    public static int stage = 0;
    public static bool isGasMaskOn = false;
    public static Vignette vg;

    public static void GasMaskEffect()
    {
        vg.intensity.value = 1f;
    }

    void Awake ()
    {
        instance = this;
        GasMask = GameObject.Find("PostProcessingGasMask").GetComponent<Volume>();
        GasMask.profile.TryGet(out vg);


        object1.GetComponent<XRGrabInteractable>().enabled = true;
        object1.GetComponent<Sequence>().enabled = true;
        object2.GetComponent<XRGrabInteractable>().enabled = false;
        object2.GetComponent<Sequence>().enabled = false;
        object3.GetComponent<XRGrabInteractable>().enabled = false;
        object3.GetComponent<Sequence>().enabled = false;
    }

}


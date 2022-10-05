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

    //public GameObject object1;
    //public GameObject object2;
    //public GameObject object3;
    //public GameObject object4;
    //public GameObject object5;
    //public GameObject object6;
    public static Volume GasMask;

    public static int stage = 0;
    public static bool isGasMaskOn = false;
    public static int fireNum = 1;
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


        //object1.SetActive(false);
        //object2.SetActive(false);
        //object3.SetActive(false);
        //object4.SetActive(false);
        //object5.SetActive(false);
        //object6.SetActive(false);
    }

}


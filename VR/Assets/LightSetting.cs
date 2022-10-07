using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSetting : MonoBehaviour
{

    private Light theLight;
    private float targetIntensity;
    private float currentIntensity;


    // Start is called before the first frame update
    void Start()
    {
        theLight = GetComponent<Light>();
        currentIntensity = theLight.intensity;
        targetIntensity = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(targetIntensity - currentIntensity) >= 0.01)
        {
            if (targetIntensity - currentIntensity >= 0)
                currentIntensity += Time.deltaTime * 3f;
            else
                currentIntensity -= Time.deltaTime * 3f;

            theLight.intensity = currentIntensity;
            theLight.range = currentIntensity + 10;
        }
        else
        {
            targetIntensity = Random.Range(0.4f, 1f);
        }
    }
}

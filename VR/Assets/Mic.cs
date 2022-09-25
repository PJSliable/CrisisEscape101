using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mic : MonoBehaviour
{
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        
    }

    public void PlaySnd()
    {
        SavWav.Save("C:/Users/SSAFY/Desktop/pjt 2/vr/S07P22A101/VR/Assets/Voice/voice1", aud.clip);
    }

    public void RecSnd()
    {
        aud.clip = Microphone.Start(Microphone.devices[0].ToString(),true, 10, 441000);
    }
}
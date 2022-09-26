using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

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

        /*    using (var fileStream = SavWav.CreateEmpty(Path.Combine(Application.persistentDataPath, filename);))
        {

            SavWav.ConvertAndWrite(fileStream, aud.clip);

            SavWav.WriteHeader(fileStream, aud.clip);
        };*/
        SavWav.Save("C:/Users/SSAFY/Desktop/pjt 2/vr/S07P22A101/VR/Assets/Voice/voice1", aud.clip);

    }

    public void RecSnd()
    {
        aud.clip = Microphone.Start(Microphone.devices[0].ToString(),true, 10, 441000);
    }
}
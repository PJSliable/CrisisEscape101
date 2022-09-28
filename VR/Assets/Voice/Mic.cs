using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.EventSystems;

public class Mic : MonoBehaviour
{
    public AudioSource aud;
    server httprequest;
    Mic tempMic;

    

    // Start is called before the first frame update
    void OnEnable()
    {   
        aud = GetComponent<AudioSource>();
        tempMic = GetComponent<Mic>();
        Debug.Log("Audio source: " + aud, gameObject);
        Invoke("RecSnd", 1f);

    }

    public void SaveSnd()
    {
        SavWav.Save("C:/Users/SSAFY/Desktop/pjt 2/vr/S07P22A101/VR/Assets/Voice/voice1", aud.clip);
        Debug.Log("save done");
    }

    public void PlaySnd()
    {

        Debug.Log("1");
       // SavWav.Save("C:/Users/SSAFY/Desktop/pjt 2/vr/S07P22A101/VR/Assets/Voice/voice1", aud.clip);

        httprequest = GetComponent<server>();
        httprequest.STTtext = "불이야";

        Debug.Log(httprequest.STTtext);

        byte[] bytes = File.ReadAllBytes("C:/Users/SSAFY/Desktop/pjt 2/vr/S07P22A101/VR/Assets/Voice/voice1.wav");

        Debug.Log(bytes);
        httprequest.STTaudio = bytes;
        httprequest.Ready();
        


        Debug.Log("됐다!");
        tempMic.enabled = false;

    }

    public void RecSnd()
    {
        aud.clip = Microphone.Start(Microphone.devices[0].ToString(), false, 5, 48000);
        Invoke("SaveSnd", 5f);
    }
}


// disabled = > Mic enabled = T
// Start OnEnable = ()
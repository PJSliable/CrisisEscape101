using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Mic : MonoBehaviour
{
    AudioSource aud;
    server httprequest;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        Debug.Log("Audio source: " + aud, gameObject);
    }

    public void PlaySnd()
    {

        Debug.Log("1");
        //SavWav.Save("C:/Users/SSAFY/Desktop/pjt 2/vr/S07P22A101/VR/Assets/Voice/voice1", aud.clip);

        httprequest = GetComponent<server>();
        httprequest.STTtext = "불이야";

        Debug.Log(httprequest.STTtext);

        AudioClip clip = aud.clip;
        Debug.Log(clip);


        float[] data = new float[clip.samples];
        clip.GetData(data, 0);
        int rescaleFactor = 32767;
        byte[] outData = new byte[data.Length * 2];
        Debug.Log(data);
        for (int i = 0; i < data.Length; i++)
        {
            short temshort = (short)(data[i] * rescaleFactor);
            byte[] temdata = BitConverter.GetBytes(temshort);
            outData[i * 2] = temdata[0];
            outData[i * 2 + 1] = temdata[1];
        }

        Debug.Log(outData);

        httprequest.STTaudio = outData;

        httprequest.Ready();
        


        Debug.Log("됐다!");
    }

    public void RecSnd()
    {

        //aud.clip = Microphone.Start(Microphone.devices[0].ToString(), false, 10, 441000);

    }
}
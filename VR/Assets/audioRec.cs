using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class audioRec : MonoBehaviour
{
    public AudioClip audio;
    int sampleRate = 44100;
    private float[] samples;
    public float rmsValue;
    public float modulate;
    public int resultValue;
    public int cutValue;


    private void Start()
    {
        samples = new float[sampleRate];
        audio = Microphone.Start(Microphone.devices[0].ToString(), true, 1, sampleRate);
    }

    /*public void RecSnd()
    {
        audio.clip = Microphone.Start(Microphone.devices[0].ToString(), false, 3, 44100);
        SavWav.Save("C:/Users/SSAFY/Desktop/pjt 2/vr/S07P22A101/VR/Assets/Voice/voice1", audio.clip);
    }*/
    private void Update()
    {
        audio.GetData(samples, 0);
        float sum = 0;
        for(int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i];
        }
        rmsValue = Mathf.Sqrt(sum / samples.Length);
        rmsValue = rmsValue * modulate;
        rmsValue = Mathf.Clamp(rmsValue, 0, 100);
        resultValue = Mathf.RoundToInt(rmsValue);
        if (resultValue < cutValue)
            resultValue = 0;

    }
}
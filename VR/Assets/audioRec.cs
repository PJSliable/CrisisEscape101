using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class audioRec : MonoBehaviour
{
    AudioSource audio;

    public bool useMicrophone;
    public string selectedDevice;


    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void SaveVoice()
    {
        SavWav.Save("Voice1", audio.clip);
    }

    public void InputVoice()
    {
        if (Microphone.devices.Length > 0)
        {
            useMicrophone = true;
            if (useMicrophone)
            {
                selectedDevice = Microphone.devices[0].ToString();//디바이스 선택
                Microphone.Start(selectedDevice, true, 5, AudioSettings.outputSampleRate); //마이크 입력 시작

                Invoke("SaveVoice", 3);
            }
        }
        else
        {
            useMicrophone = false;
        }
    }
    public void PlayVoice()
    {
        audio.Play();
    }
}
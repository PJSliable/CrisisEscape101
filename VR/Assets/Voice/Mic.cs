using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.EventSystems;

public class Mic : MonoBehaviour
{
    public AudioSource aud;
    public string sentence;
    public AudioSource ring;
    public int waitingTime;
    server httprequest;
    Mic tempMic;



    // Start is called before the first frame update
    void OnEnable()
    {
        aud = GetComponent<AudioSource>();
        tempMic = GetComponent<Mic>();
        Debug.Log("Audio source: " + aud, gameObject);
        ring.Play();
        Invoke("RecSnd", 1f);

    }

    public void SaveSnd()
    {
        Microphone.End(Microphone.devices[0].ToString());
        bool check = SavWav.Save(Application.persistentDataPath + "/audio.wav", aud.clip);

        Debug.Log(check); //True Or False
        Debug.Log("Microphone End and File Saved");
        httprequest = GetComponent<server>();
        httprequest.Ready(sentence);
        Debug.Log("playsound 끝");

    }

    public void PlaySnd()
    {

        httprequest = GetComponent<server>();
        httprequest.Ready(sentence);
        Debug.Log("playsound 끝");
    }

    public void RecSnd()
    {
        Debug.Log("Microphone Start");
        aud.clip = Microphone.Start(Microphone.devices[0].ToString(), false, waitingTime, 48000);
        Invoke("SaveSnd", waitingTime);

    }
}


// disabled = > Mic enabled = T
// Start OnEnable = ()

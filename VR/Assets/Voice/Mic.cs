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
    Server httprequest;
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
        Microphone.End(Microphone.devices[0].ToString());
        bool check = SavWav.Save(Application.persistentDataPath + "/audio.wav", aud.clip);

        Debug.Log(check); //True Or False
        Debug.Log("Microphone End and File Saved");
        aud.Play();

    }

    public void PlaySnd()
    {

        httprequest = GetComponent<Server>();
        httprequest.Ready(sentence);
        tempMic.enabled = false;

    }

    public void RecSnd()
    {
        Debug.Log("Microphone Start");
        aud.clip = Microphone.Start(Microphone.devices[0].ToString(), false, 5, 48000);
        Invoke("SaveSnd", 5f);

    }
}


// disabled = > Mic enabled = T
// Start OnEnable = ()

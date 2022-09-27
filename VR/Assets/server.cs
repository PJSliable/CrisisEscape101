using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;


public class server : MonoBehaviour
{
    public string STTtext;
    public byte[] STTaudio;
    public AudioClip STTclip;
    public void Ready()
    {
        Debug.Log("STTaudio is " + STTaudio);   
        StartCoroutine(Upload(STTtext, STTaudio));

    }

    IEnumerator Upload(string stttext, byte[] sttaudio)
    {


        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();

        Debug.Log("stttext is " + stttext);
        Debug.Log("sttaudio is " + sttaudio);


        formData.Add(new MultipartFormDataSection("text", stttext));
        formData.Add(new MultipartFormFileSection("audio", sttaudio));

        Debug.Log("formData");
        Debug.Log(formData[1]);

        UnityWebRequest www = UnityWebRequest.Post("http://j7a101.p.ssafy.io:8080/api/v1/processing/", formData);
        www.SetRequestHeader("Content-Type", "multipart/form-data; boundary=<calculated when request is sent>");
        yield return www.SendWebRequest();
        Debug.Log("Status Code: " + www.responseCode);

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            Debug.Log("에러");
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}
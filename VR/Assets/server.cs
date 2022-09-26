using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class MyBehavior : MonoBehaviour
{
    public string STTtext;
    AudioClip STTaudio;

    void Start()
    {
        StartCoroutine(Upload(STTtext, STTaudio));
    }

    IEnumerator Upload(string STTtext, file)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("text", STTtext));
        formData.Add(new MultipartFormFileSection("audio", STTaudio));

        UnityWebRequest www = UnityWebRequest.Post("http://j7a101.p.ssafy.io:8080/api/v1/processing/", formData);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}
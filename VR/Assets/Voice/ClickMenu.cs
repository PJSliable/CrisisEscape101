using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickMenu : MonoBehaviour
{

    // Start is called before the first frame update
    public void ChangeFireScene()
    {
        Debug.Log("fire");
        SceneManager.LoadScene("ObjectScene");
    }
    public void ChangeWaterScene()
    {
        Debug.Log("Water");
        SceneManager.LoadScene("water");
    }
    public void QuitScene()
    {
        Application.Quit();
    }

}

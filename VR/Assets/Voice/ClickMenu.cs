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
        SceneManager.LoadScene("text-mesh");
    }
    public void ChangeWaterScene()
    {
        Debug.Log("fire");
        SceneManager.LoadScene("WorldInteractionDemo");
    }
    public void QuitScene()
    {
        Application.Quit();
    }

}

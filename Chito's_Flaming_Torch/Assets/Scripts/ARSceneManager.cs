using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARSceneManager : MonoBehaviour
{
    private const string PreviousSceneKey = "PreviousScene";

    public void GotoTitle()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }

    public void GotoScene(string sceneName)
    {
        //save previous scene for previous button
        PlayerPrefs.SetString(PreviousSceneKey, SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    //Go to and return to the settings scene from any scene 
    public void ReturnToPreviousScene()
    {
       string previousSceneName = PlayerPrefs.GetString(PreviousSceneKey);
       SceneManager.LoadScene(previousSceneName, LoadSceneMode.Single);
    }
}

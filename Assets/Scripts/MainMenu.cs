using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public SceneFader sceneFader;
    // Start is called before the first frame update
    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

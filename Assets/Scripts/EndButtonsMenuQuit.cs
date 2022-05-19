using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtonsMenuQuit : MonoBehaviour
{
    public SceneFader sceneFader;
    public Animator ani;

    public void Start()
    {
        
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            ani.speed = 100;
        }
    }
    // Start is called before the first frame update
    public void Quit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";
    public string nextLevel;
    public int levelToReach;
    public GameObject obj;

    public void Continue()
    {
        //check if this actually works, level was won in some scenarios despite game being over
        if (!GameManager.isGameEnded)
        {
            PlayerPrefs.SetInt("levelReached", levelToReach);
            StartCoroutine(LowerVolume());
            sceneFader.FadeTo(nextLevel);
        }
    }
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
    public IEnumerator LowerVolume()
    {
        while (obj != null && obj.GetComponent<AudioSource>().volume > 0)
        {
            obj.GetComponent<AudioSource>().volume -= 0.1f;
            if (obj.GetComponent<AudioSource>().volume < 0.3f)
                Destroy(obj);

            yield return new WaitForSeconds(0.15f);
        }
    }

}

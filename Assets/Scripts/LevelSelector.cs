using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public SceneFader fader;
    public Button[] levelButtons;
    public GameObject obj;
    void Start()
    {
        obj = GameObject.Find("MenuMusic");
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    public void Select(string levelName)
    {
        StartCoroutine(LowerVolume());
        fader.FadeTo(levelName);
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

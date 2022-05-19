using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingMenu : MonoBehaviour
{
    public Button menu;
    public Button quit;
    public GameObject menuButton;
    public GameObject quitButton;
    public Animator anim;
    private string end = "Thank you for playing the Demo!";
    public TextMeshProUGUI text;
    private float typingSpeed = 0.5f;
    private bool isRunning = true;

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {

                menuButton.SetActive(true);
                quitButton.SetActive(true);
                isRunning = false;
                if (text.text != end)
                    StartCoroutine(DisplayText());
                    
            }
        }

    }
    IEnumerator DisplayText()
    {
        foreach (char letter in end.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}

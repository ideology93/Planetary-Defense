using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class EndText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro text;
    [SerializeField] private float typingSpeed = 0.04f;
    private string end = "Thank you for playing the Demo!";
    void Update()
    {
        StartCoroutine(DisplayText());
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

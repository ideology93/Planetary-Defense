using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: "+PlayerStats.Lives;
    }
}

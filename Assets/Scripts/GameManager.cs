using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverUI;

    public GameObject completeLevelUI;

    // Start is called before the first frame update
    public static bool isGameEnded = false;
    void Awake()
    {
        isGameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameEnded)
        {
            return;
        }
        if (Input.GetKey("e"))
        {
            EndGame();
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

    }
    void EndGame()
    {
        isGameEnded = true;
        gameOverUI.SetActive(true);

    }
    public void WinLevel()
    {
        completeLevelUI.SetActive(true);
    }

}

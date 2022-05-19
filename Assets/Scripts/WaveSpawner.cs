using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaveSpawner : MonoBehaviour
{

    public Wave[] waves;
    [SerializeField] float timeBetweenWaves = 20f; // try 5f
    private float countdown = 3f; // try 2f
    private int waveIndex = 0;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI enemiesLeftText;
    [SerializeField] private Text countdownTimer;


    public static int enemiesAlive;

    public GameManager gameManager;
    public Transform startPos;

    void Awake()
    {
        countdown = 3f;
        enemiesAlive = 0;

    }
    void Update()
    {
        //enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeftText.text = "Enemies: " + enemiesAlive;
        if (enemiesAlive > 0)
        {
            return;
        }
        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        if (countdown == 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            waveText.text = "Wave:" + waveIndex;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        countdownTimer.text = string.Format("{0:00.00}", countdown);



    }
    IEnumerator SpawnWave()
    {
 
        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];
        enemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
        
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, startPos.transform.position + new Vector3(0, 0, 2), enemy.transform.rotation);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive;

    public Wave[] waves;

    public float timeBetweenWaves = 5f;
    public Text waveCountDownText;
    private float countDown = 2f;
    private int waveIndex = 0;
    public Transform spawnPoint;

    public GameManager gameManager;

    private void Awake()
    {
        EnemiesAlive = 0;
    }

    private void Update()
    {   
        if (EnemiesAlive > 0) return;

        if (waveIndex >= waves.Length)
        {
            gameManager.Winlevel();
            this.enabled = false;
        }
        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveCountDownText.text = string.Format("{0:00.00}", countDown)  ;
    }

    IEnumerator SpawnWave()
    {
        FindObjectOfType<AudioManager>().Play("NewWave");
        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;
        for(int i=0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1/wave.rate);
        }
        waveIndex++;
        PlayerStats.rounds++;

        
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive;
    public int waypointGetIndex;

    public Wave[] waves;

    public float timeBetweenWaves = 5f;
    public Text waveCountDownText;
    private float countDown = 5f;
    public int waveIndex = 0;
    public Transform spawnPoint;
    public static bool waveIsOver;
    public Text currentWave;

    public GameManager gameManager;
    public Text itsBossTime;
    public static bool isBossWave;
    public static bool bossAlive;
    public int currentLevel;

    private void Awake()
    {
        waveIsOver = false;
        EnemiesAlive = 0;
        waveIndex = 0;
        bossAlive = false;
        isBossWave = false;
    }

    private void Update()
    {   
        if (EnemiesAlive > 0 && waveIsOver == true) return;

        if (waveIndex >= waves.Length && EnemiesAlive == 0 || waveIndex >= waves.Length && !bossAlive && currentLevel == 4)
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
        if (!isBossWave)
        {
            countDown -= Time.deltaTime;
        }
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveCountDownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpawnWave()
    {  
        waveIsOver = false;
        FindObjectOfType<AudioManager>().Play("NewWave");
        Wave wave = waves[waveIndex];
        waveIndex++;
        int waveSubCount = 0;
        for (int i = 0; i <= 2; i++)
        {
            waveSubCount += wave.count[i];
        }
        EnemiesAlive += waveSubCount;
        for (int i=0; i <= 2; i++)
        {
            for(int j=0; j<wave.count[i]; j++)
            {
                SpawnEnemy(wave.enemy[i]);
                yield return new WaitForSeconds(1 / wave.rate[i]);
            }
        }
        waveIsOver = true;
        PlayerStats.rounds++;
    }

    IEnumerator Warning()
    {
        itsBossTime.enabled = true;

        yield return new WaitForSeconds(3);

        itsBossTime.enabled = false;
    }

    void SpawnEnemy(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().SetWaypointSetIndex(waypointGetIndex);
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        if (enemy.GetComponent<Enemy>().isBoss)
        {
            FindObjectOfType<AudioManager>().Stop("Theme");
            FindObjectOfType<AudioManager>().Play("BossFight");
            bossAlive = true;
            StartCoroutine(Warning());
        }
    }

}

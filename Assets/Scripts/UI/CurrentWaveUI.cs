using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWaveUI : MonoBehaviour
{
    public Text currentWave;
    public WaveSpawner theSpawner;

    private void Update()
    {
        currentWave.text = "Wave: " + theSpawner.waveIndex;
    }
}

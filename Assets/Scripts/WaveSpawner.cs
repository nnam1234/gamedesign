using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float roundTime = 5f;
    private float countdown = 2f;

    public Text WaveCountdownText;

    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = roundTime;
        }

        countdown -= Time.deltaTime;

        WaveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        // Debug.Log("Wave Incomming!");
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
         
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        GameObject.FindObjectOfType<ScoreManager>().wave += 1;

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

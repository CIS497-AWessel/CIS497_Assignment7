/*
 * Anthony Wessel
 * Assignment 7 - Prototype 4
 * Manages waves and spawns enemies and powerups
 */

using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;

    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SpawnEnemyWave(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerups(int numPowerups)
    {
        for (int i = 0; i < numPowerups; i++)
        {
            Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return  new Vector3(spawnPosX, 0, spawnPosZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameInProgress)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.StartGame();
                SpawnEnemyWave(waveNumber);
            }
            return;
        }

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            if (waveNumber == 10)
            {
                GameManager.Win();
                return;
            }
                
            SpawnEnemyWave(++waveNumber);
            SpawnPowerups(1);
        }

        ScoreText.text = "Wave: " + waveNumber +
            "\nEnemies Remaining: " + enemyCount;
    }
}

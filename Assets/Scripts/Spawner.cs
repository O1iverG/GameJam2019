using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // The different Enemy levels
    public enum EnemyLevels
    {
        Easy,
        Medium,
        Hard,
        Boss
    }

    // Enemy level to be spawnedEnemy
    public EnemyLevels enemyLevel = EnemyLevels.Easy;

    
    public GameObject EasyEnemy;
    public GameObject MediumEnemy;
    public GameObject HardEnemy;
    public GameObject BossEnemy;
    private Dictionary<EnemyLevels, GameObject> Enemies = new Dictionary<EnemyLevels, GameObject>(4);
    
    public int enemyPerWave = 1;
    private int numEnemy = 0;
    private int spawnedEnemy = 0;


    // The ID of the spawner
    private int SpawnID;

    
    private bool waveSpawn = false;
    public bool Spawn = true;

    // timed wave controls
    public float timeBetweenEnemies = 1.0f;
    private float timeTillEnemy = 0.0f;
    //Wave controls
    public int wavesPerRound = 5;
    private int numWaves = 0;

    void Start()
    {
        SpawnID = Random.Range(1, 500);
        Enemies.Add(EnemyLevels.Easy, EasyEnemy);
        Enemies.Add(EnemyLevels.Boss, BossEnemy);
        Enemies.Add(EnemyLevels.Medium, MediumEnemy);
        Enemies.Add(EnemyLevels.Hard, HardEnemy);
        timeBetweenEnemies = Random.Range(1.0f, 5.0f);
    }
    
    void Update()
    {
        if (Spawn)
        {
            if (numWaves <= wavesPerRound)
            {
                timeTillEnemy += Time.deltaTime;
                if (waveSpawn)
                {
                    spawnEnemy();
                }
                if (timeTillEnemy >= timeBetweenEnemies)
                {
                    waveSpawn = true;
                    timeTillEnemy = 0.0f;
                    numWaves++;
                    numEnemy = 0;
                }
                if (numEnemy >= enemyPerWave)
                {
                    // diables the wave spawner
                    waveSpawn = false;
                }
            }
            else
            {
                Spawn = false;
            }
            
        }
    }
    // spawns an enemy based on the enemy level that you selected
    private void spawnEnemy()
    {
        GameObject Enemy = (GameObject)Instantiate(Enemies[enemyLevel], gameObject.transform.position, Quaternion.identity);
        // Increase the total number of enemies spawned and the number of spawned enemies
        numEnemy++;
        spawnedEnemy++;
    }
    // Call this function from the enemy when it "dies" to remove an enemy count
    public void killEnemy(int sID)
    {
        // if the enemy's spawnId is equal to this spawnersID then remove an enemy count
        if (SpawnID == sID)
        {
            numEnemy--;
        }
    }
    //enable the spawner based on spawnerID
    public void enableSpawner(int sID)
    {
        if (SpawnID == sID)
        {
            Spawn = true;
        }
    }
    //disable the spawner based on spawnerID
    public void disableSpawner(int sID)
    {
        if (SpawnID == sID)
        {
            Spawn = false;
        }
    }
    // returns the Time Till the Next Wave, for a interface, ect.
    public float TimeTillEnemy
    {
        get
        {
            return timeTillEnemy;
        }
    }

    public void enableTrigger()
    {
        Spawn = true;
    }
}

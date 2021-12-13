using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;
    [SerializeField] GameObject Enemy3;
    [SerializeField] GameObject Enemy4;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;

    int poolinc;
    List<GameObject>pool = new List<GameObject>(5);
    [SerializeField] float starttime;
    float startTimer;

    float timer;
    [SerializeField] [Range(0, 120)] float SpawnBoostTime; // How often an enemy is added to the pool.
    private void Awake()
    {
        poolinc = poolSize;
        StartCoroutine(StartDelayPool());
           
       
    }
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(SpawnEnemy());
    }
    
    void PopulatePool()
    {
       
       // pool = new List<GameObject>(poolSize);
        for(int i = 0;  i < pool.Capacity; i++)
        {
         //   pool[i] = Instantiate(EnemyPrefab, transform);
           // pool[i].SetActive(false);
           pool.Add( Instantiate(EnemyPrefab, transform));
        }
        foreach(GameObject enemy in pool)
        {
            enemy.SetActive(false);
        }
    }
    void EnableObjectInPool()
    {
        foreach (GameObject enemy in pool)
        {
            if(enemy.activeInHierarchy == false)
            {
                enemy.SetActive(true);
                return;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        startTimer += Time.deltaTime;
        timer += Time.deltaTime;
        SpawnTimerRatio();
       

    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
    IEnumerator StartDelayPool()
    {
        bool startmode = true;
        if (startmode == true)
        {
           
            yield return new WaitForSeconds(starttime);
            PopulatePool();
            StartCoroutine(SpawnEnemy());
            startmode = false;
        }
    }
    public void boostPool(int a)
    {
        switch (a)  // FIX FOR BOSS SPAWN IN BANK
        {
            case 1: // Creates a Ram with phyiscal resistance
                pool.Add(Instantiate(Enemy1, transform));
                break;
            case 2: // Creates a Ram with Energy resistance
                pool.Add(Instantiate(Enemy1, transform));
                break;
            case 3: // Creates a normal ram
                pool.Add(Instantiate(Enemy1, transform));
                break;
            case 4: // Creates a Rockman with phyiscal resistance
                pool.Add(Instantiate(Enemy1, transform));
                break;
            default:
                break;
               
        }
            
      
    }
    public void SpawnRandomEnemy(int a)
    {
    
       
        switch (a)
        {
           
            case 1:
                pool.Add(Instantiate(Enemy1, transform));
                break;
            case 2:
                pool.Add(Instantiate(Enemy2, transform));
                break;
            case 3:
                pool.Add(Instantiate(Enemy3, transform));
                break;
            case 4:
                pool.Add(Instantiate(Enemy4, transform));
                break;
            default:
                break;
        }
       

    }
    public void Rand()
    {
        int a;
        a = Random.Range(1, 3);
        switch (a)
        {

            case 1:
                pool.Add(Instantiate(Enemy1, transform));
                break;
            case 2:
                pool.Add(Instantiate(Enemy2, transform));
                break;
            case 3:
                pool.Add(Instantiate(Enemy3, transform));
                break;
            case 4:
                pool.Add(Instantiate(Enemy4, transform));
                break;
            default:
                break;
        }


    }
    void SpawnTimerRatio()
    {
        if (timer >= SpawnBoostTime)
        {
            Rand();
            timer = 0;
        }
    }
  
}

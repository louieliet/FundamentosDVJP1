using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnner : MonoBehaviour
{
    
    public GameObject[] enemyPrefabs;
    public int enemyIndex;
    public float spawnRate = 1f;
    private float timer = 0f;
    public float difference = 2.0f; 

    private void Start()
    {
        spawnEnemy();
    }
    
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnEnemy();
            timer = 0;
        }
    }

    void spawnEnemy(){
        float topLimit = -1.2f;
        float bottomLimit = -2.44f;
        float randomHeight = Random.Range(bottomLimit,topLimit);
        bool randomSide = (Random.Range(0,2) == 0);
        int enemyIndex = Random.Range(0,enemyPrefabs.Length);
        
        if(randomSide == true){
            Instantiate(
                enemyPrefabs[enemyIndex], 
                new Vector3(transform.position.x + 8.0f, randomHeight, 0), 
                enemyPrefabs[enemyIndex].transform.rotation);
        }
        else{
            Instantiate(
                enemyPrefabs[enemyIndex], 
                new Vector3(transform.position.x - 8.0f, randomHeight, 0), 
                enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 20.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()    
    {
        Vector3 spawnPos = GenerateRandomLocation();
        GameObject animal = GenerateRandomAnimal();
        Instantiate(animal, spawnPos,animal.transform.rotation);
    }
    Vector3 GenerateRandomLocation()
    {
        return new Vector3(Random.Range(-spawnRangeX,spawnRangeX),0,spawnPosZ);
    }

    GameObject GenerateRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        return animalPrefabs[animalIndex];
    }
}

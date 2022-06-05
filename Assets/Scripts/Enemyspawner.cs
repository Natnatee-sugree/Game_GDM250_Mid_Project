using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    public GameObject enemy;
    float readX;
    Vector2 spawn;
    public float spawnRate = 2f;
    float nextspawn = 0.0f;
    void Update()
    {
        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawnRate;
            Instantiate(enemy, spawn, Quaternion.identity);
        }  
    }
}

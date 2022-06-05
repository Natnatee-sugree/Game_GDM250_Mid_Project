using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Spawner : MonoBehaviour
{
    public Enemy_controller[] enemy;
    public GameObject[] spawnPoint;
    public string ConfFileName = "confData.csv";
    Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>();

    private void Awake()
    {
        ReadData();
    }

    private void ReadData()
    {
        StreamReader input = null;
        string path = "Assets/StreamingAssets";
        try
        {
            input = File.OpenText(Path.Combine(path,
                                        ConfFileName));
            string name = input.ReadLine();
            string values = input.ReadLine();
            while (values != null)
            {
                AssignData(values);
                values = input.ReadLine();
            }
        }
        catch (Exception ex) { Debug.Log(ex.Message); }
        finally { if (input != null) input.Close(); }
    }

    void AssignData(string values)
    {
        string[] data = values.Split(',');
        int no = int.Parse(data[0]);
        string enemyName = data[1];
        int MaxHP = int.Parse(data[2]);
        Enemy enemy = new Enemy(MaxHP);
        enemies.Add(enemyName, enemy);
    }
    void Start()
    {
        if (enemy == null) return;
        if (spawnPoint == null) return;

        foreach (GameObject spawn in spawnPoint)
        {
            int rand = UnityEngine.Random.Range(0, enemy.Length);
            string className = enemy[rand].GetType().Name;
            int MaxHP = 50;
            Enemy enemyData = new Enemy(MaxHP);
            switch (className)
            {
                case "Enemy":
                    enemyData = enemies["Enemy"];
                    break;
                default:
                    break;
            }
            enemy[rand].MaxHP = enemyData.maxHP;
            Instantiate(enemy[rand], spawn.transform.position, spawn.transform.rotation);
        }
    }
}

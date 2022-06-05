using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxHP = 50;
    public Enemy(int newMaxHP)
    {
        maxHP = newMaxHP;
    }
    public int maxHP { get => MaxHP; set => MaxHP = value; }
}

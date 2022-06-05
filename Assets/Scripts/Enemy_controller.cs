using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{
    public Animator animator;
    public int MaxHP = 50;
    int currentHP;
    void Start()
    {
        currentHP = MaxHP;    
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        animator.SetTrigger("Hurt");
        if(currentHP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        ScoreController.score += 10;
        Debug.Log("Dead");
        animator.SetBool("isDead",true);
        Destroy(gameObject);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}

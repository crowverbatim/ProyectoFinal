using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private GameObject enemy;
    public float attackCooldown = 0.5f;
    private float lastAttackTime;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        lastAttackTime = -attackCooldown;
    }

    void Update()
    {
        HandleAttack();
    }
    
    public void HandleAttack()
    {

        if (Input.GetKeyDown(KeyCode.K) && Time.time >= lastAttackTime + attackCooldown)
        {
            anim.SetBool("Attack", true);
            if (enemy !=null)
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(5);
                    Debug.Log("¡Daño al enemigo aplicado!");
                }
            }
            lastAttackTime = Time.time;
        }
        else
        {
          
            anim.SetBool("Attack", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy = other.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy = null;
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed, distnceDetection, attackDetection;
    private bool playerDetected;
    public int maxHealth = 10;
    public int Health;
    public TMP_Text EnemyLife;
    public float CoolDown = 1f;
    private float lastCoolDown;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Health = maxHealth;
        lastCoolDown = -CoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Vector3.Distance(transform.position, player.transform.position);
        if (direction < distnceDetection && direction > attackDetection)
        {
            Vector2 dir = (player.transform.position - transform.position).normalized;
            rb.velocity = dir * speed;
           
        }
        else if( direction <= attackDetection)
        {
            EnemyAttack();
        }
        else
        {
           
        }

        // Debug.Log(("distance player" + direction));
    }
    public void EnemyAttack()
    {
       if(Time.time >= lastCoolDown + CoolDown)
       {

            player.GetComponent<PlayerHealth>().TakeDamage(5);
            lastCoolDown = Time.time;
       }
        
    }
    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        EnemyLife.text = "Enemy Life: " + Health.ToString();
        if (Health <= 0)
        {
            anim.SetTrigger("Hit");
            Destroy(gameObject,1f);
        }
    }
}

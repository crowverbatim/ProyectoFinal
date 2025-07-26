using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed, distnceDetection, attackDetection;
    private bool playerDetected;
    public int maxHealth = 10;
    public int Health;
    [SerializeField] private float coolDown = 1f;
    private float lastCoolDown;
    [SerializeField] private TMP_Text enemyLife;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Health = maxHealth;
        lastCoolDown = -coolDown;
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
        else if(direction<= attackDetection)
        {
            EnemyAttack();
            
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
        // Debug.Log(("distance player" + direction));
    }
    public void EnemyAttack()
    {
        if (Time.time >= lastCoolDown + coolDown)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(5);
            lastCoolDown = Time.time;
        }
    }
   public void TakeDamage(int damage)
    {
        Health -= damage;
        enemyLife.text = "Vida enemigo: " + Health.ToString();
        if (Health <= 0)
        {
            anim.SetTrigger("Hit");
            Destroy(gameObject,1f);
        }
    }
}

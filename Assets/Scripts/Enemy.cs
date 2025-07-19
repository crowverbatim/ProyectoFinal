using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed, distnceDetection, attackDetection;
    private bool playerDetected;
    public int maxHealth = 10;
    public int Health;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Vector3.Distance(transform.position, player.transform.position);
        if (direction < distnceDetection && direction > attackDetection)
        {
            Vector2 dir = (player.transform.position - transform.position).normalized;
            rb.velocity = dir * speed;
            Debug.Log("Moverse hacia el jugador");
        }
        else
        {
            Debug.Log("Atacar jugador");
        }

        // Debug.Log(("distance player" + direction));
    }
    public void EnemyAttack()
    {
        if (playerDetected)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(5);
        }
    }
    private void OnCOllisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDetected = true;
        }
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            anim.SetTrigger("Hit");
            Destroy(gameObject,1f);
        }
    }
}

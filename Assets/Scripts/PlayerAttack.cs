using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    
    private GameObject enemy;
    private Animator anim;
    public float CoolDown = 1f;
    private float lastCoolDown;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        lastCoolDown = -CoolDown;
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    public void Attack()
    {
        if (Input.GetKey(KeyCode.K) && Time.time >= lastCoolDown + CoolDown)
        {
            anim.SetBool("Attack", true);

            if (enemy != null)
            {
                
                Enemy newEnemy = enemy.GetComponent<Enemy>();
                if(newEnemy !=null)
                {
                    newEnemy.TakeDamage(5);
                    Debug.Log("Daño enemigo");

                }
            }
            lastCoolDown = Time.time;
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
            enemy =null;

        }
    }
    
}

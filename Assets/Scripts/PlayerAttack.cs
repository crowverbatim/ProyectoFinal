using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    public bool enemyDetected;
    private GameObject enemy;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    public void Attack()
    {
        if (Input.GetKey(KeyCode.K))
        {
            anim.SetBool("Attack", true);
            
            if (enemyDetected)
            {

                enemy.GetComponent<Enemy>().TakeDamage(5);
                Debug.Log("Daño enemigo");
            }
            else
            {
                 Debug.Log("no hay enemigo");
            }
        }
        else
        {
            anim.SetBool("Attack", false);
        }
        
    }
    private void OnCOllisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyDetected = true;
            
        }
    }
}

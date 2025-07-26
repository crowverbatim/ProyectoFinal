using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int Health;
    public TMP_Text PlayerLife;
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        Health -= damage;
        PlayerLife.text = "Player Life: " + Health.ToString();
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

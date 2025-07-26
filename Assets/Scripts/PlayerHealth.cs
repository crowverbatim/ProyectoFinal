using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int Health;

    [SerializeField] private TMP_Text playerLife;
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        Health -= damage;
        playerLife.text = "Vida del jugador: " + Health.ToString();
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

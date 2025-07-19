using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    PlayerTransition playerTransition;
    public string objectName;
    public bool isTaken;
    // Start is called before the first frame update
    void Start()
    {
        playerTransition = FindObjectOfType<PlayerTransition>();
        if (PlayerPrefs.HasKey(objectName))
        {
            isTaken = PlayerPrefs.GetInt(objectName) == 1;
            gameObject.SetActive(!isTaken);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OntriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTaken = true;
            PlayerPrefs.SetInt(objectName, 1);
            gameObject.SetActive(false);
            var value = PlayerPrefs.GetInt("Coins", 0);
            PlayerPrefs.SetInt("Coins", value + 1);
            playerTransition.GetCoin();
        }
    }
}

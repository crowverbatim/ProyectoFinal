using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSave : MonoBehaviour
{

    [SerializeField] TMP_Text saveWarning;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 pos = other.transform.position;
            SavePositon(pos);
            Debug.Log("Guardado de posicion " + pos);
        }
    }
    public void SavePositon(Vector3 playerPos)
    {
        PlayerPrefs.SetFloat("posX", playerPos.x);
        PlayerPrefs.SetFloat("posY", playerPos.y);
        PlayerPrefs.SetFloat("posZ", playerPos.z);
        PlayerPrefs.Save();

        saveWarning.text = "The save was succesfull";
        Invoke("DeleteText", 2f);

    }

    public void DeleteText()
    {
        saveWarning.text = "";
    }
    
}

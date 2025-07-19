using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerTransition : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("posX"))
        {
            float loadedX = PlayerPrefs.GetFloat("posX");
            float loadedY = PlayerPrefs.GetFloat("posY");
            float loadedZ = PlayerPrefs.GetFloat("posZ");
            transform.position = new Vector3(loadedX, loadedY, loadedZ);
        }
        if (PlayerPrefs.HasKey("Coins"))
        {
            GetCoin();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetCoin()
    {
        coinsText.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}

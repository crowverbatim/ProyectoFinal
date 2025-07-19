using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [SerializeField] Button loadButton;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        if (PlayerPrefs.HasKey("posX"))
        {
            loadButton.interactable = true;
        }
    }

    public void StartNewGame()
    {
        if (PlayerPrefs.HasKey("posX"))
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("GameReal");
        }

        else
        {
            SceneManager.LoadScene("GameReal");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("posX"))
        {
            SceneManager.LoadScene("GameReal");
        }
    }
}

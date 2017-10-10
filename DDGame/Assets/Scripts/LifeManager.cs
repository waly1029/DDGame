using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

    //public int startingLives;

    public int lifeCounter;

    private Text theText;

    public GameObject gameOverScreen;

    public PlayerController player;

    public string mainMenu;

    public float waitAfterGameOver;
	// Use this for initialization
	void Start () {
        theText = GetComponent<Text>();

        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");

        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        theText.text = "x " + lifeCounter;

        if (lifeCounter < 0)
        {
            gameOverScreen.SetActive(true);

            player.gameObject.SetActive(false);
        }

        if (gameOverScreen.activeSelf)
        {
            waitAfterGameOver -= Time.deltaTime;
        }

        if (waitAfterGameOver < 0)
        {
            //Application.LoadLevel(mainMenu);
            SceneManager.LoadScene(mainMenu);
        }
	}

    public void GiveLife()
    {
        lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

    public void TakeLife()
    {
        lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }
}

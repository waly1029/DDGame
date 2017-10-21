using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

    public int lifeCounter;

    [SerializeField]
    private Text theText;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private string mainMenu;

    [SerializeField]
    private float waitAfterGameOver;

    private PlayerController player;

    // Use this for initialization
    void Start( ) {

        theText = transform.Find("Text").GetComponent<Text>();

        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");

        player = FindObjectOfType<PlayerController>();

        gameOverScreen = GameObject.Find("Main HUD").transform.Find("GameOverScreen").gameObject;

    }

    // Update is called once per frame
    void Update( ) {

    }

    public void Life( ) {
        
        if (lifeCounter < 0) {

            gameOverScreen.SetActive(true);

            player.gameObject.SetActive(false);

        }

        if (gameOverScreen.activeSelf) {

            waitAfterGameOver -= Time.deltaTime;

        }

        if (waitAfterGameOver < 0) {

            SceneManager.LoadScene(mainMenu);

        }

    }

    public void DrawLife( ) {

        theText.text = "x " + lifeCounter;

    }

    public void GiveLife( ) {

        lifeCounter++;

        PlayerPrefs.SetInt( "PlayerCurrentLives", lifeCounter );

    }

    public void TakeLife( ) {

        lifeCounter--;

        PlayerPrefs.SetInt( "PlayerCurrentLives", lifeCounter );

    }

}

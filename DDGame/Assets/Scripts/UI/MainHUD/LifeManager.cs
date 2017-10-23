using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

    public int lifeCounter;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private string mainMenu;

    [SerializeField]
    private float waitAfterGameOver;

    private PlayerController player;

    // Use this for initialization
    void Start( ) {

        lifeCounter = PlayerPrefs.GetInt( "PlayerCurrentLives" );

        player = FindObjectOfType<PlayerController>( );

        gameOverScreen = GameObject.Find( "Main HUD" ).transform.Find( "GameOverScreen" ).gameObject;

    }

    // Update is called once per frame

    public void Update( ) {
        
        GameOver( );

    }

    void GameOver( ) {

        if ( lifeCounter < 0 ) {

            gameOverScreen.SetActive( true );

            player.gameObject.SetActive( false );

            waitAfterGameOver -= Time.deltaTime;

            if ( waitAfterGameOver < 0 ) {

                SceneManager.LoadScene( mainMenu );

            }

        }

    }

}

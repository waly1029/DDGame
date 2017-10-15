using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour {
    
    public bool playerInZone;

	// Use this for initialization
	void Start ( ) {
		
        playerInZone = false; 

    }
	
	// Update is called once per frame
	
    public void load( string nextLevelTag, string toLevelSelect, int score ) {

        if ( Input.GetAxisRaw( "Vertical" ) > 0 && playerInZone && ScoreManager.score >= score ) {

            PlayerPrefs.SetInt( nextLevelTag, 1 );

            SceneManager.LoadScene( toLevelSelect );

        }

    }

    void OnTriggerEnter2D( Collider2D other ) {
		
        if ( other.name == "Player" ) {
			
            playerInZone = true;

        }

    }

	void OnTriggerExit2D( Collider2D other ) {
		
        if ( other.name == "Player" ) {
			
            playerInZone = false;

        }

    }

}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
//using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {
    
    public bool playerInZone;

	[SerializeField]
    private string levelToLoad;

	[SerializeField]
    private int pointsToExit;

	[SerializeField]
    private string nextLevelTag;
    
	// Use this for initialization
	void Start ( ) {
		
        playerInZone = false; 

    }
	
	// Update is called once per frame
	void Update ( ) {

        if ( Input.GetAxisRaw( "Vertical" ) > 0 && playerInZone && ScoreManager.score >= pointsToExit ) {
			
            LoadLevel( );

        }

	}

    public void LoadLevel( ) {
		
		PlayerPrefs.SetInt( nextLevelTag, 1 ); 

        SceneManager.LoadScene( levelToLoad );

		Debug.Log ( PlayerPrefs.GetInt(nextLevelTag));

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

using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private int pointPenaltyOnDeath;

    [SerializeField]
    private float respawnDelay;

    public string toLevelSelect;

    public int pointsToExit;

    public string nextLevelTag;

    public GameObject currentCheckPoint;

    private PlayerController playerCor;

    public GameObject deathParticle;

    public GameObject respawnParticle;

    private new CameraController camera;

    private HealthManager healthManager;

    private LevelLoader levelLoader;
    
	void Start ( ) {

        playerCor = FindObjectOfType<PlayerController> ( );

        camera = FindObjectOfType<CameraController> ( );

        healthManager = FindObjectOfType<HealthManager> ( );

        levelLoader = FindObjectOfType<LevelLoader> ( );

    }
	
	// Update is called once per frame
	void Update ( ) {
	
        levelLoader.load( nextLevelTag, toLevelSelect, pointsToExit);

	}

    public void RespawnPlayer( ) {

        StartCoroutine( "RespawnPlayerCo" );

    }

    public IEnumerator RespawnPlayerCo( ) {

        PlayerDead( );

        Debug.Log( "Player Respawn" );

        yield return new WaitForSeconds( respawnDelay );

        RestPlayer( );

    }

    private void RestPlayer( ) {

        Instantiate( respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation );

        playerCor.transform.position = currentCheckPoint.transform.position;
        
        healthManager.FullHealth( );
        
        playerCor.gameObject.SetActive( true );

        healthManager.isDead = false;

        camera.isFollowing = true;

        FindObjectOfType<PlayerKnockEnemy>( ).knockBackCounter = 0;
        
    }

    private void PlayerDead( ) {

        Instantiate( deathParticle, playerCor.transform.position, playerCor.transform.rotation );

        playerCor.gameObject.SetActive( false );

        camera.isFollowing = false;

        ScoreManager.AddPionts( -pointPenaltyOnDeath );

    }
}

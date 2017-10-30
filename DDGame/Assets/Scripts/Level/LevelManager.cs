using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    public static Transform tran;

    [SerializeField]
    private int pointPenaltyOnDeath;

    [SerializeField]
    private float respawnDelay;

    public string toLevelSelect;

    public int pointsToExit;

    public string nextLevelTag;

    public GameObject currentCheckPoint;

    public GameObject deathParticle;

    public GameObject respawnParticle;

    private new CameraController camera;

    private HealthModel healthModel;

    private LevelLoader levelLoader;

	private LifeController lifeCor;

	private TimeController timeCor;

	private PlayerController playerCor;

	void Start ( ) {

        playerCor = FindObjectOfType<PlayerController> ( );

        camera = FindObjectOfType<CameraController> ( );

        healthModel = FindObjectOfType<HealthModel> ( );

		lifeCor = FindObjectOfType<LifeController> ( );

        levelLoader = FindObjectOfType<LevelLoader> ( );

		timeCor = FindObjectOfType<TimeController>( );

    }
	
	// Update is called once per frame
	void Update ( ) {
	
        levelLoader.load( nextLevelTag, toLevelSelect, pointsToExit );

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

		timeCor.RestTime( );
        
        playerCor.gameObject.SetActive( true );

        healthModel.isDead = false;

        camera.isFollowing = true;

		HealthController.FullHealth( );

        FindObjectOfType<PlayerKnockEnemy>( ).knockBackCounter = 0;
        
    }

    private void PlayerDead( ) {

        Instantiate( deathParticle, playerCor.transform.position, playerCor.transform.rotation );

        playerCor.gameObject.SetActive( false );

        camera.isFollowing = false;

		lifeCor.TakeLife( );

		ScoreController.AddPionts( -pointPenaltyOnDeath );

    }

}

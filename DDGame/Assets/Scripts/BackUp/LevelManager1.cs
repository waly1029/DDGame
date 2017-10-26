using UnityEngine;
using System.Collections;

public class LevelManager1 : MonoBehaviour {

    public GameObject currentCheckPoint;

    private PlayerController playerCor;

    public GameObject deathParticle;

    public GameObject respawnParticle;

    [SerializeField]
    private int pointPenaltyOnDeath;

    [SerializeField]
    private float respawnDelay;

    private new CameraController camera;

    private HealthModel healthModel;
    
    private GameObject player;
	// Use this for initialization
	void Start ( ) {

        playerCor = FindObjectOfType<PlayerController> ( );

        camera = FindObjectOfType<CameraController> ( );

		healthModel = FindObjectOfType<HealthModel> ( );
        
        player = GameObject.Find( "Player" );
    }
	
	// Update is called once per frame
	void Update ( ) {
	
	}

    public void RespawnPlayer( ) {
        //Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        //player.transform.position = currentCheckPoint.transform.position;
        //Instantiate(respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
        StartCoroutine( "RespawnPlayerCo" );

    }

    public IEnumerator RespawnPlayerCo( ) {

        Instantiate( deathParticle, playerCor.transform.position, playerCor.transform.rotation );

        playerCor.gameObject.SetActive( false );

        //playerCor.GetComponent<CircleCollider2D>( ).enabled = false;

        //playerCor.transform.Find( "Player_Sword" ).GetComponent<BoxCollider2D>( ).enabled = false;

        //playerCor.transform.Find( "Player_Sword" ).GetComponent<Renderer>( ).enabled = false;

        camera.isFollowing = false;

        //playerCor.GetComponent<Renderer>( ).enabled = false;

        ScoreController.AddPionts( -pointPenaltyOnDeath );

        //gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
        //player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        //player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Debug.Log( "Player Respawn" );

        yield return new WaitForSeconds( respawnDelay );

        //playerCor.GetComponent<CircleCollider2D>( ).enabled = true;

        //playerCor.transform.Find( "Player_Sword" ).GetComponent<BoxCollider2D>( ).enabled = true;

        //playerCor.transform.Find( "Player_Sword" ).GetComponent<Renderer>( ).enabled = true;

        //player.GetComponent<Rigidbody2D>().gravityScale = player.gravityStore;
        //player.onLadder = false;
        HealthController.FullHealth( );

//        healthModel.isDead = false;

        camera.isFollowing = true;

        playerCor.gameObject.SetActive( true );

        //playerCor.GetComponent<Renderer>( ).enabled = true;

        playerCor.transform.position = currentCheckPoint.transform.position;

		FindObjectOfType<PlayerKnockEnemy>( ).knockBackCounter = 0;

        Instantiate( respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation );

    }

}

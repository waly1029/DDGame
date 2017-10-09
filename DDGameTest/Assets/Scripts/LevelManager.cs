using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckPoint;

    public PlayerController player;

    public GameObject deathParticle;

    public GameObject respawnParticle;

    public int pointPenaltyOnDeath;

    //private float gravityStore;

    public float respawnDelay;

    public new CameraController camera;

    public HealthManager healthManager;
    
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();

        camera = FindObjectOfType<CameraController>();

        healthManager = FindObjectOfType<HealthManager>();
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RespawnPlayer()
    {
        //Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        //player.transform.position = currentCheckPoint.transform.position;
        //Instantiate(respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<CircleCollider2D>().enabled = false;
        player.transform.Find("Player_Sword").GetComponent<BoxCollider2D>().enabled = false;
        player.transform.Find("Player_Sword").GetComponent<Renderer>().enabled = false;
        camera.isFollowing = false;
        player.GetComponent<Renderer>().enabled = false;
        ScoreManager.AddPionts(-pointPenaltyOnDeath);
        //gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
        //player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        //player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Debug.Log("Player Respawn");

        yield return new WaitForSeconds(respawnDelay);

        player.GetComponent<CircleCollider2D>().enabled = true;
        player.transform.Find("Player_Sword").GetComponent<BoxCollider2D>().enabled = true;
        player.transform.Find("Player_Sword").GetComponent<Renderer>().enabled = true;
        //player.GetComponent<Rigidbody2D>().gravityScale = player.gravityStore;
        //player.onLadder = false;
        healthManager.FullHealth();
        healthManager.isDead = false;
        camera.isFollowing = true;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        player.transform.position = currentCheckPoint.transform.position;
		FindObjectOfType<PlayerKnockEnemy>().knockBackCounter = 0;
        Instantiate(respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
    }
}

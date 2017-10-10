using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

    [SerializeField]
    private float gravityStore;

    [SerializeField]
    private float climbVelocity;

    [SerializeField]
    private float climbSpeed;
    
    private Rigidbody2D playerRigidbody;

    [SerializeField]
    private bool onLadder;

	// Use this for initialization
	void Start ( ) {

        gravityStore = FindObjectOfType<PlayerController>().GetComponent<Rigidbody2D>().gravityScale;

        playerRigidbody = FindObjectOfType<PlayerController>().GetComponent<Rigidbody2D>();

        climbSpeed = 5f;

    }
	
	// Update is called once per frame
	void Update ( ) {
	    
         if ( onLadder ) {
           
            climbVelocity = climbSpeed * Input.GetAxisRaw( "Vertical" );

            playerRigidbody.gravityScale = 0f;

            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, climbVelocity);

        }

        if ( !onLadder ) {

            playerRigidbody.gravityScale = gravityStore;

        }

	}

    void OnTriggerEnter2D( Collider2D other ) {

        if ( other.name == "Player" ) {

            onLadder = true;

        }
        
    }

    void OnTriggerExit2D( Collider2D other ) {

        if ( other.name == "Player" ) {

            onLadder = false;

        }

    }
}

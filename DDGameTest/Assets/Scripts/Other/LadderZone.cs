using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

    private PlayerController playerCor;

    private Rigidbody2D playerRigidbody;

    private bool onLadder;

	// Use this for initialization
	void Start () {

        playerCor = FindObjectOfType<PlayerController>();

        playerRigidbody = playerCor.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
	    
         if (onLadder)
        {
            playerCor.climbVelocity = playerCor.climbSpeed * Input.GetAxisRaw("Vertical");
            playerCor.GetComponent<Rigidbody2D>().gravityScale = 0f;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, playerCor.climbVelocity);
            //Debug.Log("on ladder" + gravityStore);
        }
        if (!onLadder)
        {
            playerRigidbody.gravityScale = playerCor.gravityStore;
            //Debug.Log("not on ladder" + gravityStore);

        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            onLadder = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            onLadder = false;
        }

    }
}

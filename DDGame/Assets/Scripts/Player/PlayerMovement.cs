using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	public bool canDoubleJump;

	[SerializeField]
	public float jumpHeight;

	[SerializeField]
	public float moveVelocity;

	[SerializeField]
	private float moveSpeed;

	private Rigidbody2D playerRigidbody;

	private PlayerCheckGround playerCheckGround;

	//private PlayerMovement playerMovement;
	// Use this for initialization
	void Start ( ) {

		playerRigidbody = GetComponent<Rigidbody2D> ( );

		playerCheckGround = FindObjectOfType<PlayerCheckGround> ( );

		//playerMovement = FindObjectOfType<PlayerMovement> ( );

		moveSpeed = 5f;

		jumpHeight = 15f;

	}
	
	public void Move( float moveInput ) {
		
		moveVelocity = moveInput * moveSpeed;
        
	}

	public void Jump( ) {

        if ( Input.GetButtonDown ( "Jump" ) && playerCheckGround.grounded ) {
			
			playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, jumpHeight);

		}

        if ( Input.GetButtonDown( "Jump" ) && !playerCheckGround.grounded && canDoubleJump ) {

            playerRigidbody.velocity = new Vector2( playerRigidbody.velocity.x, jumpHeight );

            canDoubleJump = false;

        }

    }

    public void CheckDoubleJump( ) {

        if ( playerCheckGround.grounded ) {

            canDoubleJump = true;

        }
    }

    /*public void DoubleJump( ) {

		if ( Input.GetButtonDown ("Jump") && !playerCheckGround.grounded && playerMovement.canDoubleJump ) {
			
			playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, jumpHeight);

			canDoubleJump = false;

		}
	}*/
}

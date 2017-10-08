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

	[SerializeField]
	private Rigidbody2D playerRigidbody;

	[SerializeField]
	private PlayerCheckGround playerCheckGround;

	[SerializeField]
	private PlayerMovement playerMovement;
	// Use this for initialization
	void Start () {

		playerRigidbody = GetComponent<Rigidbody2D> ();

		playerCheckGround = FindObjectOfType<PlayerCheckGround> ();

		playerMovement = FindObjectOfType<PlayerMovement> ();

		moveSpeed = 5f;

		jumpHeight = 15f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Move( float moveInput ) {
		
		moveVelocity = moveInput * moveSpeed;

		Debug.Log (moveVelocity);

	}

	public void Jump( ) {
			
		if ( Input.GetButtonDown ("Jump") && playerCheckGround.grounded ) {
			
			playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, jumpHeight);

		}

	}

	public void DoubleJump( ) {

		if ( Input.GetButtonDown ("Jump") && !playerCheckGround.grounded && playerMovement.canDoubleJump ) {
			
			playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, jumpHeight);

			canDoubleJump = false;
		}
	}
}

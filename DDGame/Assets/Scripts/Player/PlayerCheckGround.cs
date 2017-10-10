using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckGround : MonoBehaviour {

	[SerializeField]
	public bool grounded;

	[SerializeField]
	private LayerMask whatIsGround;

	[SerializeField]
	private GameObject groundCheck;

	[SerializeField]
	private float groundCheckRadius;

	// Use this for initialization
	void Start ( ) {

		groundCheck = transform.FindChild ( "Ground Check" ).gameObject;

		groundCheckRadius = 0.1f;

	}

	void FixedUpdate( ) {
		
		grounded = Physics2D.OverlapCircle( groundCheck.transform.position, groundCheckRadius, whatIsGround );

	}

	// Update is called once per frame
	void Update ( ) {

		Debug.DrawLine( groundCheck.transform.position, new Vector2( groundCheck.transform.position.x, groundCheck.transform.position.y - groundCheckRadius ), Color.red );

	}
}

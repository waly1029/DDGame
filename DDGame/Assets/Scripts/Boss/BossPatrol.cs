using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrol : MonoBehaviour {

	[SerializeField]
    private float moveSpeed;

	[SerializeField]
	private float ySize;

	[SerializeField]
	private float wallCheckRadius;

	[SerializeField]
    private Transform wallCheck;

	[SerializeField]
	private Transform edgeCheck;

	[SerializeField]
    private LayerMask whatIsWall;

	[SerializeField]
    private bool hittingWall;

	[SerializeField]
	private bool moveRight;

	[SerializeField]
    private bool notAtEdge;

    private Rigidbody2D myrigidbody2D;

    void Start( ) {

		wallCheck = transform.Find( "Wall Check" );

		edgeCheck = transform.Find( "Edge Check" );

        myrigidbody2D = GetComponent<Rigidbody2D>( );

        ySize = transform.localScale.y;

    }

    void Update( ) {

		WallCheck( );
		
		EdgeCheck( );

		MoveDirection( );

		Movement( );

    }

	void WallCheck( ) {

		hittingWall = Physics2D.OverlapCircle( wallCheck.position, wallCheckRadius, whatIsWall );

	}

	void EdgeCheck( ) {

		notAtEdge = Physics2D.OverlapCircle( edgeCheck.position, wallCheckRadius, whatIsWall );

	}

	void Movement( ) {

		if ( moveRight ) {

			transform.localScale = new Vector3( -ySize, transform.localScale.y, transform.localScale.z );

			myrigidbody2D.velocity = new Vector2( moveSpeed, GetComponent<Rigidbody2D>( ).velocity.y );

		} else {

			transform.localScale = new Vector3( ySize, transform.localScale.y, transform.localScale.z );

			myrigidbody2D.velocity = new Vector2( -moveSpeed, GetComponent<Rigidbody2D>( ).velocity.y );

		}

	}

	void MoveDirection( ) {

		if ( hittingWall || !notAtEdge ) {

			moveRight = !moveRight;

		}

	}

}

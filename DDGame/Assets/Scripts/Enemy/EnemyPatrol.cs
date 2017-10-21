using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float wallCheckRadius;

    [SerializeField]
    private bool moveRight;

    [SerializeField]
    private bool hittingWall;

    [SerializeField]
    private bool notAtEdge;

    [SerializeField]
    private LayerMask whatIsWall;

    [SerializeField]
    private Transform wallCheck;

    [SerializeField]
    private Transform edgeCheck;
    
	// Use this for initialization
	void Start ( ) {

        wallCheck = transform.Find( "Wall Check" );

        edgeCheck = transform.Find( "Edge Check" );

    }
	
	// Update is called once per frame
	void Update ( ) {

        hittingWall = Physics2D.OverlapCircle( wallCheck.position, wallCheckRadius, whatIsWall );

        notAtEdge = Physics2D.OverlapCircle( edgeCheck.position, wallCheckRadius, whatIsWall );

        if ( hittingWall || !notAtEdge ) {

            moveRight = !moveRight;

        }

        if ( moveRight ) {

            transform.localScale = new Vector3( -1f, 1f, 1f );

            GetComponent<Rigidbody2D>( ).velocity = new Vector2( moveSpeed, GetComponent<Rigidbody2D>( ).velocity.y );

        } else {

            transform.localScale = new Vector3( 1f, 1f, 1f );

            GetComponent<Rigidbody2D>( ).velocity = new Vector2( -moveSpeed, GetComponent<Rigidbody2D>( ).velocity.y );

        }

	}

}

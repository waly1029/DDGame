﻿using System.Collections;
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

		wallCheck = transform.FindChild( "Wall Check" );

		edgeCheck = transform.FindChild( "Edge Check" );

        myrigidbody2D = GetComponent<Rigidbody2D>( );

        ySize = transform.localScale.y;

    }

    void Update( ) {

        hittingWall = Physics2D.OverlapCircle( wallCheck.position, wallCheckRadius, whatIsWall );

        notAtEdge = Physics2D.OverlapCircle( edgeCheck.position, wallCheckRadius, whatIsWall );

        if ( hittingWall || !notAtEdge ) {
			
            moveRight = !moveRight;

        }

        if ( moveRight ) {
			
            transform.localScale = new Vector3( -ySize, transform.localScale.y, transform.localScale.z );

            myrigidbody2D.velocity = new Vector2( moveSpeed, GetComponent<Rigidbody2D>().velocity.y );

        } else {
			
            transform.localScale = new Vector3( ySize, transform.localScale.y, transform.localScale.z );

            myrigidbody2D.velocity = new Vector2( -moveSpeed, GetComponent<Rigidbody2D>().velocity.y );

        }

    }

}
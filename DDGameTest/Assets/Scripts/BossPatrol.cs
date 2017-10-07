using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrol : MonoBehaviour {

    public float moveSpeed;

    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    public Transform edgeCheck;
    public bool notAtEdge;

    public float ySize;
    private Rigidbody2D myrigidbody2D;
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        ySize = transform.localScale.y;
    }

    void Update()
    {

        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall || !notAtEdge)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            transform.localScale = new Vector3(-ySize, transform.localScale.y, transform.localScale.z);
            myrigidbody2D.velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(ySize, transform.localScale.y, transform.localScale.z);
            myrigidbody2D.velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockEnemy : MonoBehaviour {

	[SerializeField]
	public bool knockFromRight;

	[SerializeField]
	public float knockBackCounter;

	[SerializeField]
	public float knockBackLength;

	[SerializeField]
	private float knockBack;
    
	private Rigidbody2D playerRigidbody;

    private PlayerMovement playerMovement;

	// Use this for initialization
	void Start ( ) {

		playerRigidbody = FindObjectOfType<PlayerController> ( ).GetComponent<Rigidbody2D> ( );

        playerMovement = FindObjectOfType<PlayerMovement>( );

		knockBackLength = 0.2f;

		knockBack = 6f;

	}

	public void PlayerJumpOnEnemy( ) {

        if ( knockBackCounter <= 0 ) {

			playerMovement.PlayerVelocity( );

        }  else {

            if ( knockFromRight ) {//if player jumps on enemy from left如果敌人在右边则向左位移(-knockBack, knockBack)


                playerRigidbody.velocity = new Vector2( -knockBack, knockBack );

            }

            if ( !knockFromRight ) {//if player jumps on enemy from right如果敌人在左边则向右位移(-knockBack, knockBack)

                playerRigidbody.velocity = new Vector2( knockBack, knockBack );

            }

            knockBackCounter -= Time.deltaTime;
        }

	}
}

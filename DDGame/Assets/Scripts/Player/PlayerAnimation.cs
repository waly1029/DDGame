using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    
	private Animator anim;
    
	private PlayerCheckGround playerCheckGround;

    private Rigidbody2D playerRigidbody;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>( );

		playerCheckGround = FindObjectOfType<PlayerCheckGround> ( );

        playerRigidbody = GetComponent<Rigidbody2D> ( );

	}
	
	// Update is called once per frame
	

	public void PlayerAnim( ) {

        anim.SetBool( "Grounded", playerCheckGround.grounded );

        anim.SetFloat( "Speed", Mathf.Abs( playerRigidbody.velocity.x ) );

        if ( playerRigidbody.velocity.x > 0 ) {

            transform.localScale = new Vector3( 1f, 1f, 1f );

        } else if ( playerRigidbody.velocity.x < 0 ) {

            transform.localScale = new Vector3( -1f, 1f, 1f );

        }
        
    }

    public void RestSword( ) {

        if ( anim.GetBool( "Sword" ) ) {

            anim.SetBool( "Sword", false );

        }

    }

    public void Sword( ) {
		Debug.Log ("1");
        anim.SetBool( "Sword", true );

    }
}

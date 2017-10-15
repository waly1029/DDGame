using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTimeCounter : MonoBehaviour {

    [SerializeField]
    private float startingTime;

    [SerializeField]
    private float countingTime;

    [SerializeField]
    private float existTime;

    [SerializeField]
    private bool isOnBlock;

    private Animator anim;

    void Start( ) { 

		anim = GetComponent< Animator > ( );

        countingTime = startingTime;

		anim.SetBool ( "Flash", false );

    }

    void Update( ) {

        if ( isOnBlock ) {

			anim.SetBool ( "Flash", true );

            countingTime -= Time.deltaTime;
            
            if ( countingTime <= existTime ) {

                gameObject.GetComponent< BoxCollider2D >( ).enabled = false;

                gameObject.GetComponent< Renderer >( ).enabled = false;

            }
            
			if ( countingTime <= existTime - 0.5f ) {

				anim.SetBool ( "Flash", false );

			}

            if ( countingTime <= 0 ) {

                countingTime = startingTime;

                isOnBlock = false;

            }

        }

        else {

            gameObject.GetComponent< BoxCollider2D >( ).enabled = true;

            gameObject.GetComponent< Renderer >( ).enabled = true;

        }

    }

    // Update is called once per frame
    void OnTriggerEnter2D( Collider2D other ) {

        if ( other.gameObject.name == "PlayerFeet" ) {

            isOnBlock = true;

			Debug.Log( "PlayerOnBlock" );

        }
        
    }

}

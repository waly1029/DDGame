using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {

    [SerializeField]
    private int healthToGive;

    private AudioSource pickUpSound;

    void Start( ) {

        pickUpSound = gameObject.transform.parent.GetComponent<AudioSource>();

    }

    void OnTriggerEnter2D( Collider2D other ) {

        if( other.GetComponent<PlayerController>( ) == null ) {

            return;

        }

        UIController.HurtPlayer( -healthToGive );

        pickUpSound.Play( );

        Destroy( gameObject );

    }

}

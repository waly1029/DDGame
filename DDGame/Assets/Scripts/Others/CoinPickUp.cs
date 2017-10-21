using UnityEngine;
using System.Collections;

public class CoinPickUp : MonoBehaviour {

    [SerializeField]
    private int pointsToAdd;

    private AudioSource coinSoundEffect;

    void Start( ) {

        coinSoundEffect = gameObject.transform.parent.GetComponent< AudioSource >( );

    }

    void OnTriggerEnter2D( Collider2D other ) {

        if ( other.GetComponent<PlayerController>( ) == null ) {

            return;

        }
        
        UIController.AddPionts( pointsToAdd );

        coinSoundEffect.Play( );

        Destroy( gameObject );

    }

}

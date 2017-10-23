using UnityEngine;
using System.Collections;

public class LifePickUp : MonoBehaviour {

    private LifeController lifeCor;

    private AudioSource lifeSoundEffect;
    // Use this for initialization
    void Start ( ) {

        lifeCor = FindObjectOfType<LifeController>( );

        lifeSoundEffect = gameObject.transform.parent.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update ( ) {
	
	}

    void OnTriggerEnter2D(Collider2D other) {

        if ( other.GetComponent<PlayerController>( ) == null ) {

            return;

        }

        lifeSoundEffect.Play( );

        lifeCor.GiveLife( );

        Destroy( gameObject );

    }

}

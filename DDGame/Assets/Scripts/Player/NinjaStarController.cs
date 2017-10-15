using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour {

	[SerializeField]
    private float speed;

	[SerializeField]
    private GameObject enemyDeathEffect;

	[SerializeField]
	private GameObject impactEffect;

	[SerializeField]
    private int pointsForKill;

	[SerializeField]
    private float rotationSpeed;

	[SerializeField]
    private int damageToGive;

	private PlayerController playerCro;
	// Use this for initialization
	void Start ( ) {

		playerCro = FindObjectOfType<PlayerController>( );

		if ( playerCro.transform.localScale.x < 0 ) {
			
            speed = -speed;

            rotationSpeed = -rotationSpeed;

        }
	}
	
	// Update is called once per frame
	void Update ( ) {
		
        GetComponent<Rigidbody2D>( ).velocity = new Vector2( speed, GetComponent<Rigidbody2D>( ).velocity.y );

        GetComponent<Rigidbody2D>( ).angularVelocity = rotationSpeed;

	}

    void OnTriggerEnter2D( Collider2D other ) {
		
        if ( other.tag == "Enemy" ) {

            Debug.Log( "touchEnemy" );

            other.GetComponent<EnemyHealthManager>( ).giveDamage( damageToGive );

        }

        if ( other.tag == "Boss" ) {

            Debug.Log( "touchBoss" );

            other.GetComponent<BossHealthManager>( ).giveDamage( damageToGive );

        }

        Instantiate( impactEffect, transform.position, transform.rotation );

        Destroy( gameObject );

    }

}

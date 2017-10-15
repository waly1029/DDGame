using UnityEngine;
using System.Collections;

public class EnemyStarController : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private PlayerController player;

    public GameObject impactEffect;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private int damageToGive;

    private LifeManager playerLife;
    // Use this for initialization
    void Start( ) {

        player = FindObjectOfType<PlayerController> ( );

        playerLife = FindObjectOfType<LifeManager> ( );

        if ( playerLife.lifeCounter >= 0 && player.enabled == true ) {

            if ( player.transform.position.x < transform.position.x ) {

                speed = -speed;

                rotationSpeed = -rotationSpeed;

            }

        }

    }

    // Update is called once per frame
    void Update( ) {

        GetComponent<Rigidbody2D>( ).velocity = new Vector2( speed, GetComponent<Rigidbody2D> ( ).velocity.y );

        GetComponent<Rigidbody2D>( ).angularVelocity = rotationSpeed;

    }

    void OnTriggerEnter2D( Collider2D other ) {

        if ( other.name == "Player" ) {

            Debug.Log( "touchPlayer" );

            HealthManager.HurtPlayer( damageToGive );

        }

        Instantiate( impactEffect, transform.position, transform.rotation );

        Destroy( gameObject );

    }

}


using UnityEngine;
using System.Collections;

public class EnemyStarController : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject player;

    public GameObject impactEffect;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private int damageToGive;

    private LifeModel lifeModel;
    // Use this for initialization
    void Start( ) {

		lifeModel = FindObjectOfType<LifeModel> ( );

		player = FindObjectOfType<PlayerController> ( ).gameObject;

		if ( lifeModel.lifeCounter >= 0 && player.activeSelf == true ) {

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

            UIController.HurtPlayer( damageToGive );

        }

        Instantiate( impactEffect, transform.position, transform.rotation );

        Destroy( gameObject );

    }

}


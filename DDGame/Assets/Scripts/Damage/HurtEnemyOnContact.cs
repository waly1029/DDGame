using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour {

	[SerializeField]
    private int damageToGive;

	[SerializeField]
    private float bounceOnEnemy;

    private Rigidbody2D myrigidbody2D;
	// Use this for initialization
	void Start ( ) {
		
        myrigidbody2D = transform.parent.GetComponent<Rigidbody2D>( );

	}

    void OnTriggerEnter2D( Collider2D other ) {
		
        if ( other.tag == "Enemy" ) {
			
            other.GetComponent<EnemyHealthManager>( ).giveDamage( damageToGive );

            myrigidbody2D.velocity = new Vector2( myrigidbody2D.velocity.x, bounceOnEnemy );

        }

        if ( other.tag == "Boss" ) {
			
            other.GetComponent<BossHealthManager>( ).giveDamage( damageToGive );

            myrigidbody2D.velocity = new Vector2( myrigidbody2D.velocity.x, bounceOnEnemy );

        }

    }

}

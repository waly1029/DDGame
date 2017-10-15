using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

    [SerializeField]
    private int enemyHealth;

    [SerializeField]
    private int pointsOnDeath;

    public GameObject deathEffect;

    //public GameObject key;
    // Use this for initialization
    void Start ( ) {
	
	}
	
	// Update is called once per frame
	void Update ( ) {

        if ( enemyHealth <= 0 ) {

            Instantiate( deathEffect, transform.position, transform.rotation );

            ScoreManager.AddPionts( pointsOnDeath );

            Destroy( gameObject );

        }

	}

    public void giveDamage( int damageToGive ) {

        enemyHealth -= damageToGive;

        GetComponent<AudioSource>( ).Play( );

    }

}

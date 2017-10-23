using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour {

	public GameObject bossPrefab;

	public GameObject deathEffect;

	[SerializeField]
    private int bossHealth;

	[SerializeField]
    private int cloneBossHealth;

	[SerializeField]
    private int pointsOnDeath;

	[SerializeField]
    private float minSize;

	private GameObject clone1, clone2;

	void Start( ) {

	}

    void Update( ) {
		
        if ( bossHealth <= 0 ) {
			
            Instantiate( deathEffect, transform.position, transform.rotation );

            ScoreController.AddPionts( pointsOnDeath );

            if( transform.localScale.y > minSize ) {

				CloneBoss( );

				SetCloneBossHealth( );
                //GameObject clone1 = Instantiate( bossPrefab, new Vector3( transform.position.x + 0.5f, transform.position.y, transform.position.z ), transform.rotation ) as GameObject;

                //GameObject clone2 = Instantiate( bossPrefab, new Vector3( transform.position.x - 0.5f, transform.position.y, transform.position.z ), transform.rotation ) as GameObject;

                //clone1.transform.localScale = new Vector3( transform.localScale.y * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z );

                //clone1.GetComponent<BossHealthManager>( ).bossHealth = cloneBossHealth;

                //clone2.transform.localScale = new Vector3( transform.localScale.y * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z );

                //clone2.GetComponent<BossHealthManager>( ).bossHealth = cloneBossHealth;

            }

            Destroy( gameObject );

        }


    }

	void CloneBoss( ) {
	
		clone1 = Instantiate( bossPrefab, new Vector3( transform.position.x + 0.5f, transform.position.y, transform.position.z ), transform.rotation ) as GameObject;

		clone2 = Instantiate( bossPrefab, new Vector3( transform.position.x - 0.5f, transform.position.y, transform.position.z ), transform.rotation ) as GameObject;

		clone1.transform.localScale = new Vector3( transform.localScale.y * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z );

		clone2.transform.localScale = new Vector3( transform.localScale.y * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z );

	}

	void SetCloneBossHealth( ) {

		clone1.GetComponent<BossHealthManager>( ).bossHealth = cloneBossHealth;

		clone2.GetComponent<BossHealthManager>( ).bossHealth = cloneBossHealth;

	}

    public void giveDamage( int damageToGive ) {
		
        bossHealth -= damageToGive;

        GetComponent<AudioSource>( ).Play( );

    }

}

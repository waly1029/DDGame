using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField]
    public GameObject ninjaStar;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float shotCounter;

    [SerializeField]
    private float shotDelay;

    private PlayerAnimation playerAnim;
	// Use this for initialization
	void Start ( ) {

        playerAnim = FindObjectOfType<PlayerAnimation> ( );

		firePoint = transform.Find ("Fire Point");

        shotDelay = 0.3f;
        
    }
	
	// Update is called once per frame
	void Update ( ) {
		
	}

    public void SwordAttack()
    {

        if ( Input.GetButtonDown( "Fire1" ) ) {
			
            playerAnim.Sword( );

        }

    }

    public void NinjaStarAttack( ) {

        if ( Input.GetButton( "Fire2" ) ) {

            shotCounter -= Time.deltaTime;

            if ( shotCounter <= 0 ) {

                shotCounter = shotDelay;
                
                FireStar( );

            }
        }

    }

    public void FireStar( ) {

        Instantiate( ninjaStar, firePoint.position, firePoint.rotation );

    }

}

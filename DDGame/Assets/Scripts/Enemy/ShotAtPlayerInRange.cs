using UnityEngine;
using System.Collections;

public class ShotAtPlayerInRange : MonoBehaviour {

    [SerializeField]
    private float playerRange;

    [SerializeField]
    private Transform launchPoint;

    [SerializeField]
    private float waitBetweenShot;

    [SerializeField]
    private float shotCounter;

    public GameObject enemyStar;

    private PlayerController playerCor;
    // Use this for initialization
    void Start ( ) {

        launchPoint = transform.Find( "Launch Point" );

        playerCor = FindObjectOfType<PlayerController> ( );

        shotCounter = waitBetweenShot;

	}
	
	// Update is called once per frame
	void Update ( ) {

        Debug.DrawLine( new Vector3( transform.position.x - playerRange, transform.position.y, transform.position.z),
             
                        new Vector3( transform.position.x + playerRange, transform.position.y, transform.position.z ) );

        shotCounter -= Time.deltaTime;

        if ( transform.localScale.x < 0 && playerCor.transform.position.x > transform.position.x &&

             playerCor.transform.position.x < transform.position.x + playerRange && shotCounter < 0 && playerCor.gameObject.activeSelf ) {

            Instantiate( enemyStar, launchPoint.position, launchPoint.rotation );

            shotCounter = waitBetweenShot;

        }

        if ( transform.localScale.x > 0 && playerCor.transform.position.x < transform.position.x &&

			 playerCor.transform.position.x > transform.position.x - playerRange && shotCounter < 0 && playerCor.gameObject.activeSelf ) {

            Instantiate( enemyStar, launchPoint.position, launchPoint.rotation );

            shotCounter = waitBetweenShot;

        }
        
	}

}

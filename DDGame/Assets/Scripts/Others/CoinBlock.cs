using UnityEngine;
using System.Collections;

public class CoinBlock : MonoBehaviour {
    
	[SerializeField]
    private int scoreEachTime;

	[SerializeField]
    private int blockLives;

	void Start( ) {
	
		scoreEachTime = 5;

	}

    void OnTriggerEnter2D( Collider2D other ) {
		
        if ( other.name == "Player Head" ) {
			
            ScoreManager.AddPionts( scoreEachTime );

            //Debug.Log("HeadTouched");

            blockLives--;

        }

        if ( blockLives <= 0 ) {
			
            Destroy( gameObject );

        }

    }

}

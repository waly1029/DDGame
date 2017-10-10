using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnMovingPlatForm : MonoBehaviour {

	void OnCollisionEnter2D( Collision2D other ) {
		
		if ( other.transform.tag == "MovingPlatform" ) {
			
			transform.parent = other.transform;

		}

	}

	void OnCollisionExit2D( Collision2D other ) {
		
		if ( other.transform.tag == "MovingPlatform" ) {
			
			transform.parent = null;

		}

	}
}

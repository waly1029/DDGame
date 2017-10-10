using UnityEngine;
using System.Collections;

public class DestoryBlockOnContact : MonoBehaviour {

	[SerializeField]
    private string nameOfTag;

    void OnTriggerEnter2D( Collider2D other ) {
		
        if ( other.tag == nameOfTag ) {
			
            Destroy( other.gameObject );

        }

    }
}

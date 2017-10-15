using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    private LevelManager levelManager;
	// Use this for initialization
	void Start ( ) {

        levelManager = FindObjectOfType<LevelManager>( );

	}

    void OnTriggerEnter2D( Collider2D other ) {

        if ( other.name == "Player" )  {

            levelManager.currentCheckPoint = gameObject;

            Debug.Log( "Actived CheckPoint" + transform.position );

        }

    }

}

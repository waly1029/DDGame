using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    private LevelManager levelManager;

	private GameObject checkPointText;

	// Use this for initialization
	void Start ( ) {

        levelManager = FindObjectOfType<LevelManager>( );

		//checkPointText = FindObjectOfType<CheckPointText>( ).gameObject;

	}

    void OnTriggerEnter2D( Collider2D other ) {

        if ( other.name == "Player" )  {

            levelManager.currentCheckPoint = gameObject;

			//checkPointText.SetActive( true );

            Debug.Log( "Actived CheckPoint" + transform.position );

        }

    }

}

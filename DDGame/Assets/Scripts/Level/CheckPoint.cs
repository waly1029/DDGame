using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    private LevelManager levelManager;

    [SerializeField]
	private GameObject checkPointText;

    [SerializeField]
    private GameObject root;

    [SerializeField]
    private float countingTime;

    [SerializeField]
    private bool touchedCheckPoint;

	// Use this for initialization
	void Start ( ) {

        levelManager = FindObjectOfType<LevelManager>( );

        root = GameObject.Find( "Main HUD" );

		checkPointText = root.transform.Find( "CheckPoint" ).gameObject;

	}

    void Update( ) {

        if ( touchedCheckPoint ) {

            countingTime -= Time.deltaTime;

            if ( countingTime < -1f ) {

                checkPointText.SetActive( false );

                Destroy( gameObject.GetComponent<CheckPoint> ( ) );

            }

        }
    }

    void OnTriggerEnter2D( Collider2D other ) {

        if ( other.name == "Player" && checkPointText.activeSelf == false ) {

            levelManager.currentCheckPoint = gameObject;

			checkPointText.SetActive( true );

            touchedCheckPoint = true;

            Debug.Log( "Actived CheckPoint" + transform.position );

        }

    }

}

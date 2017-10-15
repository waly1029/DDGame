using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMovement : MonoBehaviour {

	public float distanceBelowLock;

	public int positionSelector;

	public bool touchMode;

	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private bool isPressed;

	private LevelSelectInformation levelSelInfo;
	// Use this for initialization
	void Start ( ) {

		levelSelInfo = FindObjectOfType<LevelSelectInformation> ( );

	}
	
	// Update is called once per frame
	void Update ( ) {
		
	}

	public void LevelSelectMove( ) {

		if ( !isPressed ) {

			if ( Input.GetAxis( "Horizontal" ) > 0.25f ) {

				Debug.Log( ">>" );

				positionSelector += 1;

				isPressed = true;

			}

			if ( Input.GetAxis( "Horizontal" ) < -0.25f ) {

				Debug.Log( "<<" );

				positionSelector -= 1;

				isPressed = true;

			}

			if ( positionSelector >= levelSelInfo.levelTags.Length ) {

				positionSelector = levelSelInfo.levelTags.Length - 1;

			}

			if ( positionSelector < 0 ) {

				positionSelector = 0;

			}

		}

		if ( isPressed ) {

			if ( Input.GetAxis( "Horizontal" ) < 0.25f && Input.GetAxis( "Horizontal" ) > -0.25f ) {

				isPressed = false;

			}

		}

		transform.position = Vector3.MoveTowards( transform.position, levelSelInfo.locks[ positionSelector ].transform.position + new Vector3( 0, distanceBelowLock, 0 ), moveSpeed * Time.deltaTime );

	}

	public void LoadScene( ) {

		if ( Input.GetButtonDown( "Fire1" ) || Input.GetButtonDown( "Jump" ) ) {

			if ( levelSelInfo.levelUnlocked[ positionSelector ] && !touchMode ) {

				PlayerPrefs.SetInt( "PlayerLevelSelectPosition", positionSelector );

				//Application.LoadLevel(levelName[positionSelector]);
				SceneManager.LoadScene( levelSelInfo.levelName[ positionSelector ] );

			}

		}

	}

	/*public void SetPos( ) {

		positionSelector = PlayerPrefs.GetInt( "PlayerLevelSelectPosition" );

		transform.position = levelSelInfo.locks[ positionSelector ].transform.position + new Vector3( 0, distanceBelowLock, 0 );

	}*/

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelectTouch : MonoBehaviour {

	private LevelSelectMovement levelSelMov;

	private LevelSelectInformation levelSelInfo;

	// Use this for initialization
	void Start ( ) {

		levelSelInfo = FindObjectOfType<LevelSelectInformation> ( );

		levelSelMov = FindObjectOfType<LevelSelectMovement> ( );

		levelSelMov.touchMode = true;

	}
	
	public void MoveLeft( ) {
		
		levelSelMov.positionSelector -= 1;

		if( levelSelMov.positionSelector < 0 ) {
			
			levelSelMov.positionSelector = 0;

        }

    }

    public void MoveRight( ) {
		
		levelSelMov.positionSelector += 1;

		if ( levelSelMov.positionSelector >= levelSelInfo.levelTags.Length ) {
			
			levelSelMov.positionSelector = levelSelInfo.levelTags.Length - 1;

        }

    }

    public void LoadLevel( ) {
		
		if ( levelSelInfo.levelUnlocked[ levelSelMov.positionSelector ] ) {
			
			PlayerPrefs.SetInt( "PlayerLevelSelectPosition", levelSelMov.positionSelector );

			SceneManager.LoadScene( levelSelInfo.levelName[ levelSelMov.positionSelector ] );

        }

    }

}

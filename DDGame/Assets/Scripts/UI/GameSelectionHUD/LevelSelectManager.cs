using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelectManager : MonoBehaviour {

	private LevelSelectMovement levelSelMov;

	private LevelSelectInformation levelSelInfo;

    // Use this for initialization
	void Start ( ) {

		levelSelMov = FindObjectOfType<LevelSelectMovement> ( ); 

		levelSelInfo = FindObjectOfType<LevelSelectInformation> ( );

		levelSelInfo.FindLevelLocks ( );

		levelSelInfo.SetLevelTags ( );

		levelSelInfo.CheckLevelLocks ( );

		levelSelMov.positionSelector = PlayerPrefs.GetInt( "PlayerLevelSelectPosition" );

		transform.position = levelSelInfo.locks[ levelSelMov.positionSelector ].transform.position + new Vector3( 0, levelSelMov.distanceBelowLock, 0 );

	} 
	
	// Update is called once per frame
	void Update ( ) {

		levelSelMov.LevelSelectMove ( );

		levelSelMov.LoadScene ( );

	}

}

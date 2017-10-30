using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectInformation : MonoBehaviour {

	[SerializeField]
	private const int MAX_LEVEL = 8;

	public GameObject[ ] locks;

	public bool[ ] levelUnlocked;

	public string[ ] levelTags;

	public string[ ] levelName;

	void Start ( ) {
	
	}

	public void FindLevelLocks( ) {

		string locksNum = "";

		locks = new GameObject[ MAX_LEVEL ];

		for( int i = 0; i < MAX_LEVEL; i++ ) {

			locksNum = "Level_Select_Lock_0" + ( i + 1 );

			locks[ i ] = GameObject.Find( locksNum );

		}

	}

	public void SetLevelTags( ) {

		levelTags = new string[ MAX_LEVEL ];

		for( int i = 0; i < MAX_LEVEL; i++ ) {

			levelTags[ i ] = "Level0" + ( i + 1 );

		}

	}

	public void CheckLevelLocks( ) {

		levelUnlocked = new bool[ MAX_LEVEL ];

		for ( int i = 0; i < levelTags.Length; i++ ) {

			if ( PlayerPrefs.GetInt( levelTags[ i ] ) == 0 ) {

				levelUnlocked[ i ] = false;

			} else if ( PlayerPrefs.GetInt( levelTags[ i ] ) == 1 ) {

				levelUnlocked[ i ] = true;

			} if (levelUnlocked[ i ] == true ) {

				locks[ i ].SetActive( false );

			}

		}

	}

}

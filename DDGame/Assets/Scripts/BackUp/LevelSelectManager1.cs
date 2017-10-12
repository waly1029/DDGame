using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelectManager1 : MonoBehaviour {

    public const int MAX_LEVEL = 8;

    public string[ ] levelTags;

	public string[ ] levelName;

	public bool[ ] levelUnlocked;

	public int positionSelector;

	public bool touchMode;

	[SerializeField]
    private float moveSpeed;

	[SerializeField]
    private bool isPressed;

	[SerializeField]
    private float distanceBelowLock;

	[SerializeField]
	private GameObject[ ] locks;
    
	private LevelSelectInformation levelSelectInfor;

    // Use this for initialization
    void Start ( ) {

		levelSelectInfor = FindObjectOfType<LevelSelectInformation> ( );

		FindLevelLocks( );

		SetLevelTags( );

		CheckLevelLocks( );

        positionSelector = PlayerPrefs.GetInt( "PlayerLevelSelectPosition" );
        
        transform.position = locks[ positionSelector ].transform.position + new Vector3( 0, distanceBelowLock, 0 );

	}
	
	// Update is called once per frame
	void Update ( ) {

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

            if ( positionSelector >= levelTags.Length ) {
				
                positionSelector = levelTags.Length - 1;

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

        transform.position = Vector3.MoveTowards( transform.position, locks[ positionSelector ].transform.position + new Vector3( 0, distanceBelowLock, 0 ), moveSpeed * Time.deltaTime );

        if ( Input.GetButtonDown( "Fire1" ) || Input.GetButtonDown( "Jump" ) ) {
			
            if ( levelUnlocked[ positionSelector ] && !touchMode ) {
				
                PlayerPrefs.SetInt( "PlayerLevelSelectPosition", positionSelector );

                //Application.LoadLevel(levelName[positionSelector]);
                SceneManager.LoadScene( levelName[ positionSelector ] );

            }

        }

	}

     private void FindLevelLocks( ) {

		string locksNum = "";

		locks = new GameObject[ MAX_LEVEL ];

		for( int i = 0; i < MAX_LEVEL; i++ ) {
            
            locksNum = "Level_Select_Lock_0" + ( i + 1 );

            locks[ i ] = GameObject.Find( locksNum );

        }

    }

	private void SetLevelTags( ) {

		levelTags = new string[ MAX_LEVEL ];

		for( int i = 0; i < MAX_LEVEL; i++ ) {

			levelTags[ i ] = "Level0" + ( i + 1 );

		}

	}

	private void CheckLevelLocks( ) {

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

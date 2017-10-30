using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private const int MAX_LEVEL = 8;

    [SerializeField]
    private string startLevel;

    [SerializeField]
    private string levelSelect;

    [SerializeField]
    private int playerLives;

    [SerializeField]
    private int playerHealth;

    [SerializeField]
    private string levelTag;
    
    [SerializeField]
    private GameObject gameButtonPanel;

    void Awake( ) {

        gameButtonPanel = transform.Find( "OnGameButtonPanel" ).gameObject;

    }

    public void NewGame( ) {

		SetStartInfo( );

        PlayerPrefs.SetInt( "PlayerLevelSelectPosition", 0 );

        SceneManager.LoadScene( startLevel );

    }

    public void LevelSelect( ) {

		SetStartInfo( );

        if ( !PlayerPrefs.HasKey( "PlayerLevelSelectPosition" ) ) {

            PlayerPrefs.SetInt( "PlayerLevelSelectPosition", 0 );

        }

        SceneManager.LoadScene( levelSelect );

    }
    
    public void GameButton( ) {

        gameButtonPanel.SetActive( true );

    }

    public void OnGameButtonPanel_Back( ) {

        gameButtonPanel.SetActive( false );

    }

    public void QuitGame( ) {

		PlayerPrefs.DeleteAll( );

        Debug.Log( "Data Cleard & Game Exited" );

        Application.Quit( );

    }

	public void SetStartInfo( ) {

		PlayerPrefs.SetInt( "PlayerCurrentLives", playerLives );

		PlayerPrefs.SetInt( "CurrentPlayerScores", 0 );

		PlayerPrefs.SetInt( "PlayerCurrentHealth", playerHealth );

		PlayerPrefs.SetInt( "PlayerMaxHealth", playerHealth );

		PlayerPrefs.SetInt( levelTag, 1 );

	}

}

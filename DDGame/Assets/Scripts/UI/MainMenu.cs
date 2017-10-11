using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private string startLevel;

    [SerializeField]
    private string levelSelect;

    [SerializeField]
    private int playerLives;

    [SerializeField]
    private int playerHealth;

    [SerializeField]
    private string level1Tag;
    
    [SerializeField]
    private GameObject gameButtonPanel;

    void Start( ) {

        gameButtonPanel = transform.FindChild("OnGameButtonPanel").gameObject;

    }

    public void NewGame( ) {

        PlayerPrefs.SetInt( "PlayerCurrentLives", playerLives );

        PlayerPrefs.SetInt( "CurrentPlayerScores", 0 );

        PlayerPrefs.SetInt( "PlayerCurrentHealth", playerHealth );

        PlayerPrefs.SetInt( "PlayerMaxHealth", playerHealth );

        PlayerPrefs.SetInt( level1Tag, 1 );

        PlayerPrefs.SetInt( "PlayerLevelSelectPosition", 0 );

        //Application.LoadLevel(startLevel);
        SceneManager.LoadScene( startLevel );

    }

    public void LevelSelect( ) {

        PlayerPrefs.SetInt( "PlayerCurrentLives", playerLives );

        PlayerPrefs.SetInt( "CurrentPlayerScores", 0 );

        PlayerPrefs.SetInt( "PlayerCurrentHealth", playerHealth );

        PlayerPrefs.SetInt( "PlayerMaxHealth", playerHealth );

        PlayerPrefs.SetInt( level1Tag, 1 );

        if (!PlayerPrefs.HasKey( "PlayerLevelSelectPosition" ) ) {

            PlayerPrefs.SetInt( "PlayerLevelSelectPosition", 0 );

        }
        //Application.LoadLevel(levelSelect);
        SceneManager.LoadScene( levelSelect );

    }
    
    public void GameButton( ) {

        gameButtonPanel.SetActive( true );

    }

    public void OnGameButtonPanel_Back( ) {

        gameButtonPanel.SetActive( false );

    }

    public void QuitGame( ) {

        PlayerPrefs.DeleteKey( "Level_1_Lock"　);

        PlayerPrefs.DeleteKey( "Level_2_Lock"　);

        PlayerPrefs.DeleteKey( "Level_3_Lock"　);

        PlayerPrefs.DeleteKey( "Level_4_Lock"　);

        PlayerPrefs.DeleteKey( "Level_5_Lock"　);

        PlayerPrefs.DeleteKey( "Level_6_Lock"　);

        PlayerPrefs.DeleteKey( "Level_7_Lock"　);

        PlayerPrefs.DeleteKey( "Level_8_Lock"　);

        Debug.Log(　"Game Exited"　);

        Application.Quit(　);

    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	[SerializeField]
    private string levelSelect;

	[SerializeField]
    private string mainMenu;

	private PauseMenuController pauseMenuCor;

	private PauseMenuUI pauseMenuUI;

	public bool isPaused;

    void Start( ) {

		pauseMenuCor = FindObjectOfType<PauseMenuController> ( );

		pauseMenuUI = FindObjectOfType<PauseMenuUI> ( );

	}

    void Update( ) {
		
        if ( isPaused ) {
			
			pauseMenuUI.DrawPauseMenu( true );

            Time.timeScale = 0f;

        } else {
			
			pauseMenuUI.DrawPauseMenu( false );

            Time.timeScale = 1f;

        }
			
		PauseUnpause ( );

    }

    public void PauseUnpause( ) {

		if ( pauseMenuCor.GetPaused( ) ) {

			isPaused = !isPaused;

		}

    }

    public void Resume( ) {
		
        isPaused = false;

    }

    public void LevelSelect( ) {
		
        SceneManager.LoadScene( levelSelect );

    }

    public void Quit( ) {
		
        SceneManager.LoadScene( mainMenu );

    }

}

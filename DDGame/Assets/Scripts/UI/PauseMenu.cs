using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	[SerializeField]
    private string levelSelect;

	[SerializeField]
    private string mainMenu;

	[SerializeField]
    private GameObject pauseMenuCanvas;

    public bool isPaused;

	private PauseMenuController pauseMenuCor;

    void Start( ) {

		pauseMenuCanvas = transform.Find ( "Canvas" ).gameObject;

		pauseMenuCor = FindObjectOfType<PauseMenuController> ( );

	}

    void Update( ) {
		
        if ( isPaused ) {
			
            pauseMenuCanvas.SetActive( true );

            Time.timeScale = 0f;

        } else {
			
            pauseMenuCanvas.SetActive( false );

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

using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

    private LevelLoader levelLoader;

    private PauseMenu thePauseMenu;

	private PlayerMovement playerMovement;

    private PlayerAnimation playerAnim;

    private PlayerAttack playerAttack;

    private LevelManager levelManager;

	// Use this for initialization
	void Start ( ) {

        levelLoader = FindObjectOfType<LevelLoader> ( );

        thePauseMenu = FindObjectOfType<PauseMenu> ( );

		playerMovement = FindObjectOfType<PlayerMovement> ( );

        playerAnim = FindObjectOfType<PlayerAnimation> ( );

        playerAttack = FindObjectOfType<PlayerAttack> ( );

        levelManager = FindObjectOfType<LevelManager> ( ); 

	}
	
	public void LeftArrow( ) {
		
		playerMovement.Move( -1 );

    }

    public void RightArrow( ) {
		
		playerMovement.Move( 1 );

    }

    public void UnpressedArrow( ) {
		
		playerMovement.Move( 0 );

    }

    public void Sword( ) {
		
        playerAnim.Sword( );

    }

    public void RestSword( ) {
		
        playerAnim.RestSword( );

    }

    public void Star( ) {
		
        playerAttack.FireStar( );

    }

    public void Jump( ) {
		
		FindObjectOfType<PlayerMovement>( ).Jump( );

        if ( levelLoader.playerInZone ) {

            levelLoader.load( levelManager.nextLevelTag, levelManager.toLevelSelect, levelManager.pointsToExit);

        }

    }

    public void Pause( ) {
		
        thePauseMenu.PauseUnpause( );

    }

}

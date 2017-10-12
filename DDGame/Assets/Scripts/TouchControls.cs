using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

    private LevelLoader levelExit;

    private PauseMenu thePauseMenu;

	private PlayerMovement playerMovement;

    private PlayerAnimation playerAnim;

    private PlayerAttack playerAttack;

	// Use this for initialization
	void Start ( ) {

        levelExit = FindObjectOfType<LevelLoader> ( );

        thePauseMenu = FindObjectOfType<PauseMenu> ( );

		playerMovement = FindObjectOfType<PlayerMovement> ( );

        playerAnim = FindObjectOfType<PlayerAnimation> ( );

        playerAttack = FindObjectOfType<PlayerAttack> ( );
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

        if ( levelExit.playerInZone ) {
			
            levelExit.LoadLevel( );

        }

    }

    public void Pause( ) {
		
        thePauseMenu.PauseUnpause( );

    }

}

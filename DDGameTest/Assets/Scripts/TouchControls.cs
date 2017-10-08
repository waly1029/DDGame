using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

    private PlayerController thePlayer;

    private LevelLoader levelExit;

    private PauseMenu thePauseMenu;

	private PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();

        levelExit = FindObjectOfType<LevelLoader>();

        thePauseMenu = FindObjectOfType<PauseMenu>();

		playerMovement = FindObjectOfType<PlayerMovement> ();
	}
	
	public void LeftArrow()
    {
		playerMovement.Move(-1);
    }

    public void RightArrow()
    {
		playerMovement.Move(1);
    }

    public void UnpressedArrow()
    {
		playerMovement.Move(0);
    }

    public void Sword()
    {
        thePlayer.Sword();
    }

    public void RestSword()
    {
        thePlayer.RestSword();
    }

    public void Star()
    {
        thePlayer.FireStar();
    }

    public void Jump()
    {
		FindObjectOfType<PlayerMovement>().Jump();

        if (levelExit.playerInZone)
        {
            levelExit.LoadLevel();
        }
    }

    public void Pause()
    {
        thePauseMenu.PauseUnpause();
    }
}

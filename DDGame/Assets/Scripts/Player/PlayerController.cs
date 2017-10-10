using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private PlayerKnockEnemy playerKnockEnemy;

	private PlayerMovement playerMovement;

    private PlayerAnimation playerAnim;

    private PlayerAttack playerAttack;

	// Use this for initialization
	void Start ( ) {
	
		playerKnockEnemy = FindObjectOfType<PlayerKnockEnemy> ( );

		playerMovement = FindObjectOfType<PlayerMovement> ( );

        playerAnim = FindObjectOfType<PlayerAnimation> ( );

        playerAttack = FindObjectOfType<PlayerAttack> ( );

	}

	// Update is called once per frame
	void Update ( ) {

        playerMovement.CheckDoubleJump( );
        

#if UNITY_STANDALONE || UNITY_WEBPLAYER

		playerMovement.Jump( );

		playerMovement.Move( Input.GetAxisRaw( "Horizontal" ) );

#endif
        
        playerKnockEnemy.PlayerJumpOnEnemy( );

        playerAnim.PlayerAnim( );
        

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        playerAnim.RestSword( );

        playerAttack.SwordAttack( );

        playerAttack.NinjaStarAttack();

#endif

    }

}

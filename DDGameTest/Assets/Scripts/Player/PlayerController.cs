using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //public float moveSpeed;
    //private float moveVelocity;
    //public float jumpHeight;

    //public Transform groundCheck;
    //public float groundCheckRadius;
    //public LayerMask whatIsGround;
    //private bool grounded;

    //public bool canDoubleJump;

    private Animator anim;
    Rigidbody2D myRigidbody2D;

    public Transform firePoint;
    public GameObject ninjaStar;

    public float shotDelay;
    private float shotCounter;

    /*when player on ladder*/
    public float climbSpeed;
    public float climbVelocity;
    public float gravityStore;
    /*---------------------*/
	private PlayerKnockEnemy playerKnockEnemy;

	private PlayerCheckGround playerCheckGround;

	private PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {
		
        myRigidbody2D = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        gravityStore = myRigidbody2D.gravityScale;

		playerKnockEnemy = FindObjectOfType<PlayerKnockEnemy> ();

		playerCheckGround = FindObjectOfType<PlayerCheckGround> ();

		playerMovement = FindObjectOfType<PlayerMovement> ();

	}

	// Update is called once per frame
	void Update () {

		if ( playerCheckGround.grounded ) {
			
            playerMovement.canDoubleJump = true;

        }

		anim.SetBool("Grounded", playerCheckGround.grounded);

#if UNITY_STANDALONE || UNITY_WEBPLAYER

		playerMovement.Jump( );

	    playerMovement.DoubleJump( );

		playerMovement.Move( Input.GetAxisRaw( "Horizontal" ) );

#endif

		if ( playerKnockEnemy.knockBackCounter <= 0 ) {
			
			myRigidbody2D.velocity = new Vector2 ( playerMovement.moveVelocity, myRigidbody2D.velocity.y );

		} else {
			
			playerKnockEnemy.PlayerJumpOnEnemy ( );

		}

        anim.SetFloat("Speed", Mathf.Abs(myRigidbody2D.velocity.x));

        if (myRigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (myRigidbody2D.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        if ( Input.GetButtonDown( "Fire2" ) ) {
            //Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
            FireStar( );

            shotCounter = shotDelay;

        }

        if ( Input.GetButton( "Fire2" ) ) {
			
            shotCounter -= Time.deltaTime;

            if ( shotCounter <= 0 ) {
				
                shotCounter = shotDelay;

                //Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
                FireStar();

            }
        }

        if ( anim.GetBool( "Sword" ) ) {
            //anim.SetBool("Sword", false);
            RestSword( );
        }

        if ( Input.GetButtonDown( "Fire1" ) ) {
            //anim.SetBool("Sword", true);
            Sword( );
        }

#endif

    }

    /*public void Move(float moveInput)
    {
        moveVelocity = moveInput * moveSpeed;
    }*/

    public void FireStar()
    {
        Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
    }

    public void Sword()
    {
        anim.SetBool("Sword", true);
    }

    public void RestSword()
    {
        anim.SetBool("Sword", false);
    }

    /*public void Jump()
    {
		if (playerCheckGround.grounded)
        {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);
        }

		if (!playerCheckGround.grounded && canDoubleJump)
        {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);
            canDoubleJump = false;
        }

    }*/

    /*void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }*/
}

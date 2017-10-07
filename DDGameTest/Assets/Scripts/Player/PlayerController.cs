using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float moveVelocity;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    public bool canDoubleJump;

    private Animator anim;
    Rigidbody2D myRigidbody2D;

    public Transform firePoint;
    public GameObject ninjaStar;

    public float shotDelay;
    private float shotCounter;

    public float knockBack;
    public float knockBackLength;
    public float knockBackCounter;
    public bool knockFromRight;

    public bool onLadder;

    /*when player on ladder*/
    public float climbSpeed;
    public float climbVelocity;
    public float gravityStore;
    /*---------------------*/

	// Use this for initialization
	void Start () {
		
        myRigidbody2D = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        gravityStore = myRigidbody2D.gravityScale;
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }
	// Update is called once per frame
	void Update () {

        Debug.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckRadius), Color.red);

        if(grounded){
            canDoubleJump = true;
        }

        anim.SetBool("Grounded", grounded);

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        if (Input.GetButtonDown("Jump") && grounded)
        {
            //myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);
            Jump();
        }

        if (Input.GetButtonDown("Jump") && !grounded && canDoubleJump)
        {
            //myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);
            Jump();
            canDoubleJump = false;
        }

        //moveVelocity = 0f;//if no buttons is pressed,keep moveVelocity Zero;

        //moveVelocity = Input.GetAxisRaw("Horizontal") * moveSpeed;
        Move(Input.GetAxisRaw("Horizontal"));

#endif

        if (knockBackCounter <= 0)
        {
            //movement
            myRigidbody2D.velocity = new Vector2(moveVelocity, myRigidbody2D.velocity.y);
        }
        else
        {
            if (knockFromRight)//如果敌人在右边则向左位移(-knockBack, knockBack)
            {
                myRigidbody2D.velocity = new Vector2(-knockBack, knockBack);
            }
            if (!knockFromRight)//如果敌人在左边则向右位移(-knockBack, knockBack)
            {
                myRigidbody2D.velocity = new Vector2(knockBack, knockBack);
            }
            knockBackCounter -= Time.deltaTime;
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

        if (Input.GetButtonDown("Fire2"))
        {
            //Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
            FireStar();
            shotCounter = shotDelay;
        }

        if (Input.GetButton("Fire2"))
        {
            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                shotCounter = shotDelay;
                //Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
                FireStar();
            }
        }

        if(anim.GetBool("Sword")){
            //anim.SetBool("Sword", false);
            RestSword();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //anim.SetBool("Sword", true);
            Sword();
        }

#endif

    }

    public void Move(float moveInput)
    {
        moveVelocity = moveInput * moveSpeed;
    }

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

    public void Jump()
    {
        if (grounded)
        {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);
        }

        if (!grounded && canDoubleJump)
        {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);
            canDoubleJump = false;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
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
    }
}

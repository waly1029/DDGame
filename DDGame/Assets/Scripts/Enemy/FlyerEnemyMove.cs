using UnityEngine;
using System.Collections;

public class FlyerEnemyMove : MonoBehaviour {

    private PlayerController playerCor;

	[SerializeField]
	private LayerMask playerLayer;

	[SerializeField]
    private float moveSpeed;

	[SerializeField]
    private float playerRange;

	[SerializeField]
    private bool playerInRange;

	[SerializeField]
    private bool facingAway;

	[SerializeField]
    private bool followOnLookAway;
	// Use this for initialization
	void Start ( ) {
		
		playerCor = FindObjectOfType<PlayerController>( );

	}
	
	// Update is called once per frame
	void Update ( ) {
        //检测circle内指定layer的物体是否进入
        playerInRange = Physics2D.OverlapCircle( transform.position, playerRange, playerLayer );

        //范围内跟随类似跟踪导弹
        /*if (!followOnLookAway)
        {
            if (playerInRange)
            {
                //movetowards跟随目标以所给速度
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, Time.deltaTime * moveSpeed);
                return;
            }
        }*/

        //马里奥幽灵跟随
		if ( ( playerCor.transform.position.x < transform.position.x && playerCor.transform.localScale.x < 0 ) || 
			
			 ( playerCor.transform.position.x > transform.position.x && playerCor.transform.localScale.x > 0 ) ) {
			//若player在指定物体左边并且面朝左边(localScale的负)或者在右边并且面朝右边(localScale的正)

            followOnLookAway = true;

        } else {
			
            followOnLookAway = false;

        }

        if ( playerInRange && followOnLookAway ) {
			
			transform.position = Vector3.MoveTowards( transform.position, playerCor.transform.position, Time.deltaTime * moveSpeed );

        }

	}

	void OnDrawGizmosSelected( ) { //Gizmos中可更改设置
        //画图制作3D球
        Gizmos.DrawSphere( transform.position, playerRange );

    }

}

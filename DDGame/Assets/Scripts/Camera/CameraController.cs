using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private PlayerController player;
    
    public bool isFollowing;

    [SerializeField]
    private float xOffset;

    [SerializeField]
    private float yOffset;
	// Use this for initialization
	void Start ( ) {

        player = FindObjectOfType<PlayerController>();

        isFollowing = true;

        xOffset = 3f;

        yOffset = 1f;


    }
	
	// Update is called once per frame
	void Update ( ) {

        if ( isFollowing ) {

            transform.position = new Vector3( player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z );

        }

	}
}

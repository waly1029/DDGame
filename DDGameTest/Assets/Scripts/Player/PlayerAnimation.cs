using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	[SerializeField]
	private Animator anim;

	[SerializeField]
	private PlayerCheckGround playerCheckGround;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();

		playerCheckGround = FindObjectOfType<PlayerCheckGround> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayerAnim( ) {

		anim.SetBool("Grounded", playerCheckGround.grounded);

	}
}

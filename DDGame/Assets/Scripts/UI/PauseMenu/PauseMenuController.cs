using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

	// Use this for initialization
	void Start ( ) {

	}
	
	// Update is called once per frame

	public bool GetPaused( ) {

		if ( Input.GetKeyDown ( KeyCode.Escape ) ) {

			return true;

		}

		return false;

	}

}

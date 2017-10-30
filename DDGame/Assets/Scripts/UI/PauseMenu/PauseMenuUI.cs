using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour {

	[SerializeField]
	private GameObject pauseMenuCanvas;

	// Use this for initialization
	void Start ( ) {

		pauseMenuCanvas = transform.Find ( "Canvas" ).gameObject;

	}
	
	// Update is called once per frame
	void Update ( ) {
		
	}

	public void DrawPauseMenu( bool setPauseMenu ) {

		pauseMenuCanvas.SetActive( setPauseMenu );

	}
}

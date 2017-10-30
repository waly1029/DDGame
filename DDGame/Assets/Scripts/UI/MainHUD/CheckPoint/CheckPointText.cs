using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointText : MonoBehaviour {

	[SerializeField]
	private Text checkPointText;
	// Use this for initialization
	void Start ( ) {

		checkPointText = transform.Find( "CheckPointText" ).GetComponent<Text>( );

	}
	
	// Update is called once per frame
	void Update ( ) {

		checkPointText.text = "Actived CheckPoint";

	}
}

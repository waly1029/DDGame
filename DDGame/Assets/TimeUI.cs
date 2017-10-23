using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour {

    [SerializeField]
    private Text theText;

    private TimeManager timeManager;
    // Use this for initialization
    void Start ( ) {

        theText = transform.Find( "TimeCounter" ).GetComponent<Text>( );

        timeManager = FindObjectOfType<TimeManager> ( );

    }
	
	// Update is called once per frame
	void Update ( ) {
		
        DrawUI( );

	}

    void DrawUI( ) {

        theText.text = "" + Mathf.Round( timeManager.countingTime );

    }
}

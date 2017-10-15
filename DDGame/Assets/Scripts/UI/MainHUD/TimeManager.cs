using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	[SerializeField]
    private float startingTime;

	[SerializeField]
    private float countingTime;

	[SerializeField]
    private Text theText;
    
    private PauseMenu thePauseMenu;
    
    private HealthManager healthManager;

	// Use this for initialization
	void Start ( ) {

        countingTime = startingTime;

        theText = transform.FindChild( "TimeCounter" ).GetComponent<Text> ( );

        thePauseMenu = FindObjectOfType<PauseMenu>( );

        healthManager = FindObjectOfType<HealthManager>( );
        //player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ( ) {

	}

    public void TimeCount( ) {

        if ( thePauseMenu.isPaused ) {

            return;
            //退出循环
        }

        countingTime -= Time.deltaTime;

        if ( countingTime <= 0 ) {

            healthManager.KillPlayer( );

        }

        theText.text = "" + Mathf.Round( countingTime );

    }

    public void RestTime( ) {
		
        countingTime = startingTime;

    }
}

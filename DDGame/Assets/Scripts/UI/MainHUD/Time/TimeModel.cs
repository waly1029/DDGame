using UnityEngine;
using System.Collections;

public class TimeModel : MonoBehaviour {

    public float startingTime;

    public float countingTime;

    private PauseMenu thePauseMenu;
    
    // Use this for initialization
    void Start( ) {

        countingTime = startingTime;

        thePauseMenu = FindObjectOfType<PauseMenu>( );
        
    }

	void Update( ) {

		TimeCount( );

	}

    public void TimeCount( ) {

        if ( thePauseMenu.isPaused ) {

            return;
            //退出循环
        }

        countingTime -= Time.deltaTime;

        if ( countingTime <= 0 ) {

            HealthController.KillPlayer( );

        }

    }

}

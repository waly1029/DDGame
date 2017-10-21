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
    
    // Use this for initialization
    void Start( ) {

        countingTime = startingTime;

        theText = transform.Find("TimeCounter").GetComponent<Text>();

        thePauseMenu = FindObjectOfType<PauseMenu>();
        
    }

    public void TimeCount( ) {

        if ( thePauseMenu.isPaused ) {

            return;
            //退出循环
        }

        countingTime -= Time.deltaTime;

        if ( countingTime <= 0 ) {

            UIController.KillPlayer( );

        }

    }

    public void DrawTimeCount( ) {

        theText.text = "" + Mathf.Round(countingTime);

    }

    public void RestTime( ) {
		
        countingTime = startingTime;

    }
}

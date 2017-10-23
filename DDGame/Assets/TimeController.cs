using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    private TimeManager timeManager;
    // Use this for initialization
    void Start ( ) {

        timeManager = FindObjectOfType<TimeManager>();

    }
	
	// Update is called once per frame
	void Update ( ) {
		
	}

    public void RestTime( ) {

        timeManager.countingTime = timeManager.startingTime;

    }

}

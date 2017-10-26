using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    private TimeModel timeModel;
    // Use this for initialization
    void Start ( ) {

		timeModel = FindObjectOfType<TimeModel>();

    }

    public void RestTime( ) {

		timeModel.countingTime = timeModel.startingTime;

    }

}

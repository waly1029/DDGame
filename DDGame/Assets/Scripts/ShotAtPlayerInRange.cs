﻿using UnityEngine;
using System.Collections;

public class ShotAtPlayerInRange : MonoBehaviour {

    public float playerRange;

    public GameObject enemyStar;

    public PlayerController player;

    public Transform launchPoint;

    public float waitBetweenShot;
    private float shotCounter;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();

        shotCounter = waitBetweenShot;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));

        shotCounter -= Time.deltaTime;

        if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0)
        {
            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShot;
        }

        if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0)
        {
            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShot;
        }


	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDoor : MonoBehaviour {
    
    public Rigidbody2D[] enemyRigidbody;
    
    void Start () {
        
    }

	void Update () {

        for(int i = 0; i <= 1; i++) { 

            if(enemyRigidbody[i] != null) {
                return;
            }
        }
        
        Destroy(gameObject);

    }
}

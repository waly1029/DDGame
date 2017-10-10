using UnityEngine;
using System.Collections;

public class DestoryObjectOverTime : MonoBehaviour {

    [SerializeField]
    private float lifeTime;
	// Use this for initialization
	
	// Update is called once per frame
	void Update ( ) {

        lifeTime -= Time.deltaTime;

        if ( lifeTime < 0 ) {

            Destroy( gameObject );

        }
	}
}

using UnityEngine;
using System.Collections;

public class DestoryFinishedParticle : MonoBehaviour {

    private ParticleSystem thisParticleSystem;
	// Use this for initialization
	void Start () {
        thisParticleSystem = FindObjectOfType<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (thisParticleSystem.isPlaying)
        {
            return;
        }
        Destroy(gameObject);
	}

    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }
}

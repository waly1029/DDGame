using UnityEngine;
using System.Collections;

public class DestoryBlockOnContact : MonoBehaviour {
    public string nameOfTag;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == nameOfTag)
        {
            Destroy(other.gameObject);
        }
    }
}

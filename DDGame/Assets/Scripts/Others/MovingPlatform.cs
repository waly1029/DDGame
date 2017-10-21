using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    [SerializeField]
    private GameObject platForm;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Transform currentPoint;

    [SerializeField]
    private Transform[ ] points;

    [SerializeField]
    private int pointSelect;
	// Use this for initialization
	void Start ( ) {

        platForm = transform.Find( "Platform" ).gameObject;

        currentPoint = points[ pointSelect ];

	}
	
	// Update is called once per frame
	void Update ( ) {
        //这个函数的返回值是一个点，以maxdistancedelta为单位速度沿着当前的和目标之间的线接近目标点。
        //移动不会超过目标。maxdistancedelta为负值时，可以用来从目标推开该向量。
        platForm.transform.position = Vector3.MoveTowards( platForm.transform.position, currentPoint.position, Time.deltaTime * moveSpeed );

        if ( platForm.transform.position == currentPoint.position ) {

            pointSelect++;

            if ( pointSelect == points.Length ) {

                pointSelect = 0;

            }

            currentPoint = points[ pointSelect ];

        }

	}

}

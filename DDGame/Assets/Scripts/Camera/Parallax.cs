using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

    [SerializeField]
    private Transform[ ] backgrounds;

    [SerializeField]
    private float[ ] parallaxScales;

    [SerializeField]
    private float smoothing;

    [SerializeField]
    private Transform cam;

    [SerializeField]
    private Vector3 previousCamPos;

	// Use this for initialization
	void Start ( ) {

        cam = Camera.main.transform;

        previousCamPos = cam.position;

        parallaxScales = new float[ backgrounds.Length ];

        for ( int i = 0; i < backgrounds.Length; i++ ) {

            parallaxScales[ i ] = backgrounds[ i ].position.z * -1;
            //正负1代表背景移动方向
        }

	}
	
	// Update is called once per frame
    void LateUpdate ( ) {//使用LateUpdate在update之后读取相机位置

        for ( int i = 0; i < backgrounds.Length; i++ ) {

            float parallax = ( previousCamPos.x - cam.position.x ) * parallaxScales[ i ];

            float backgroundTargetPosX = backgrounds[ i ].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3( backgroundTargetPosX, backgrounds[ i ].position.y, backgrounds[ i ].position.z );

            backgrounds[ i ].position = Vector3.Lerp( backgrounds[ i ].position, backgroundTargetPos, smoothing * Time.deltaTime );

            //像弹簧一样跟随目标物体
            //static function Lerp (from : Vector3, to : Vector3, t : float) : Vector3两个向量之间的线性插值
            //按照数字t在from到to之间插值。t是夹在 [0...1]之间，当t = 0时，返回from，当t = 1时，返回to。当t = 0.5 返回from和to的平均数。
        }

        previousCamPos = cam.position;

	}
}

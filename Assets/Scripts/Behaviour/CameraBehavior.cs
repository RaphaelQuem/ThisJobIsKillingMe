using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    // Use this for initialization
    public GameObject Follow;
    public GameObject LeftLimiter;
    public GameObject RightLimiter;

    private Camera camera;
    private void Awake()
    {
        camera = gameObject.GetComponent<Camera>();
    }
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (camera.WorldToViewportPoint(LeftLimiter.transform.position).x.ToString("F2").Equals("0.00") && Follow.transform.position.x < gameObject.transform.position.x)
            return;
        if (camera.WorldToViewportPoint(RightLimiter.transform.position).x.ToString("F2").Equals("1.00") && Follow.transform.position.x > gameObject.transform.position.x)
            return;


        float deltaX = Follow.transform.position.x - gameObject.transform.position.x;


        gameObject.transform.position += new Vector3( (deltaX * Time.deltaTime), 0, 0);
    }
}

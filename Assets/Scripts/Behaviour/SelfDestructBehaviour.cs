using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructBehaviour : MonoBehaviour {

    public float timer;
    private float delta;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        delta += Time.deltaTime;
        if (delta >= timer)
            GameObject.Destroy(gameObject);
	}
}

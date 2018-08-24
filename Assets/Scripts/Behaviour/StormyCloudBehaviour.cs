using Assets.Scripts.Behaviour.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormyCloudBehaviour : MonoBehaviour {

    // Use this for initialization
    public float waitingTime;
    public GameObject target;
    private float deltaTime;


	void Start () {
        waitingTime = new System.Random().Next(1,3); 
	}
	
	// Update is called once per frame
	void Update () {
        deltaTime += Time.deltaTime;
        if(deltaTime >= waitingTime)
        {
            var lightning = (GameObject)Resources.Load("Prefabs/lightning");
            lightning.transform.position = new Vector3(target.transform.position.x, lightning.transform.position.y, -1);
            GameObject.Instantiate(lightning);
            GameObject.Destroy(target);
            GameObject.Destroy(gameObject);
        }
	}
}

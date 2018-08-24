using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpBehaviour : MonoBehaviour {

    // Use this for initialization
    public GameObject Destination;
    public bool Active = true;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destination.GetComponent<WarpBehaviour>().Active = false;
       if(Active)
        collision.transform.position = Destination.transform.position;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Active = true;
    }
}

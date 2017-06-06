using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	
	private Vector3 offset;
    GameObject gm;


	// Use this for initialization
	void Start () {
        gm = GameObject.Find("Ball");
		offset = transform.position - gm.transform.position;
	}
	
	// Update is called once per frame
    //Reset the ball to the fitst
	void Update (){
		if (gm.transform.position.z < 1600f) {
			transform.position = gm.transform.position + offset;
		}		
	}

}

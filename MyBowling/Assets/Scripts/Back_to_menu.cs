using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Author : Logothetis Fragkoulis 
 * ECE
 * Electrical and Computer Engineer 
 * 
 * */

public class Back_to_menu : MonoBehaviour {
    private Button bk;
	// Use this for initialization
	void Start () {
        bk = GetComponent<Button>();
        bk.onClick.AddListener(() => return_back());
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    //When the gamer push the button ,then the Bowling scence is loaded .
    private void return_back()
    {
        Application.LoadLevel(0);
        
    }
}

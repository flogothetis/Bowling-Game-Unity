
using UnityEngine;
using System.Collections;
/*
 * Author : Logothetis Fragkoulis 
 * ECE
 * Electrical and Computer Engineer 
 * 
 * */

//_________________________________________________________Menu_______________________________________________________________
public class Menu : MonoBehaviour {

    public static bool play_with_computer = false;
	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 6, Screen.width / 5, Screen.height / 10), "Start the Game for 2 Players ")) {
             play_with_computer = false;
              Application.LoadLevel(1);
		}
        if (GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Start the Game ( Player Vs Computer )")) 
        {
            play_with_computer = true;
            Application.LoadLevel(1);
        }

        if (GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 2, Screen.width / 5, Screen.height / 10), "Options"))
        {
            Application.LoadLevel(2);
        }
		
		
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 1.5f, Screen.width / 5, Screen.height / 10), "Quit")) {
			Application.Quit();
		}
	}
}
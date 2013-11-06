using UnityEngine;
using System.Collections;
public class MenuScript : MonoBehaviour {

	void OnGUI () {		
		if (GUI.Button (new Rect (Screen.width/2-75,Screen.height/2-125,125,75), "Start sneakin'")) {
			Application.LoadLevel ("main");
		}
		if (GUI.Button (new Rect (Screen.width/2-75,Screen.height/2-50,125,75), "Dropping the bassbox")) {
        	Application.LoadLevel ("dropbox");
      	}
    	if (GUI.Button (new Rect (Screen.width/2-75,Screen.height/2+25,125,75), "Rage quit")) {
        	Application.Quit();
      }
	}
}
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	float timerSec = 0.5f; // set duration time in seconds in the Inspector
	float timerMin = 0;
	void Update(){
  	timerSec += Time.deltaTime;
		if(timerSec>60){
			timerSec=timerSec-60;
			timerMin=timerMin+1;
		}

  }
	void OnGUI(){
		if(timerMin!=0){
		GUI.Box (new Rect (Screen.width/2,Screen.height - 50,100,50), timerMin+"."+timerSec.ToString("F2"));
		}
		else{
			GUI.Box (new Rect (Screen.width/2,Screen.height - 50,100,50), timerSec.ToString("F2"));
			
		}
		}
	
}


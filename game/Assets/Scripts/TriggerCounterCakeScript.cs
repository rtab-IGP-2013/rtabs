using UnityEngine;
using System.Collections;

public class TriggerCounterCakeScript: MonoBehaviour {
	
	public GameObject cameraToDisable;
	private int counter = 0;
	private static int SWITCH_COUNT = 7;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void TriggerPressed(){
		counter++;
		Debug.Log (counter + "times hit");
		if(counter >= SWITCH_COUNT){
			Debug.Log("truning off camera");
			cameraToDisable.tag = "disabledCam";
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
			List <Camera> cameras = new List<Camera> ();
			Camera[] cameraArray = FindObjectsOfType (typeof(Camera)) as Camera[];
			Debug.Log (cameraArray.Length +"kameraa");
			GameObject manager = GameObject.FindGameObjectWithTag("Manager");
			for (int i = 0; i < cameraArray.Length; i++) {
				if(cameraArray[i].tag=="disabledCam"){	
						 manager.gameObject.SendMessage ("removeCamera",cameraArray[i], SendMessageOptions.RequireReceiver);
				}
			}
			cameraToDisable.tag = "disabledCam";
			
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FinalScript : MonoBehaviour {
	public Camera camera;
	public Light Spotlight;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		void OnTriggerEnter(Collider col) {
	
		if(col.gameObject.tag ==  "Player"){
			audio.Play();
			GameObject music = GameObject.FindGameObjectWithTag("Music");
			music.audio.Stop();
			Debug.Log("Player hit Switch");
   			Spotlight.intensity=3;
			List <Camera> cameras = new List<Camera> ();
			Camera[] cameraArray = FindObjectsOfType (typeof(Camera)) as Camera[];
			Debug.Log (cameraArray.Length +"kameraa");
			GameObject manager = GameObject.FindGameObjectWithTag("Manager");
			for (int i = 0; i < cameraArray.Length; i++) {
				if(cameraArray[i].tag=="disabledCam"){	
						 manager.gameObject.SendMessage ("removeCamera",cameraArray[i], SendMessageOptions.RequireReceiver);
				}
			}
			camera.tag="disabledCam";
		}
		
	}
	
}

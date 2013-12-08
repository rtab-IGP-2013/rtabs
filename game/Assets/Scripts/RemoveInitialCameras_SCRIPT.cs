using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RemoveInitialCameras_SCRIPT : MonoBehaviour {
	
	public List<Camera> cameras = new List<Camera> ();

	// Use this for initialization
	void Start () {
		int i = 0;
		foreach(Camera cam in cameras) {
			gameObject.GetComponent<CameraManager>().removeCamera (cam);
			i++;
			}
		Debug.Log ("Removed " + i + " cameras from rotation.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

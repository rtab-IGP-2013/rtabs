using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour
{	
	
	private List<Camera> cameras = new List<Camera> ();
	private AudioListener listener;
	private Camera followCam;
	public static Camera activeCam;
	private bool followOn = false;
	private bool cycleOn = true;
	
	// Use this for initialization
	void Start ()
	{
		Camera[] cameraArray = FindObjectsOfType (typeof(Camera)) as Camera[];
		
		for (int i = 0; i < cameraArray.Length; i++) {
			cameras.Add (cameraArray [i]);
		}
		
		Debug.Log ("Found " + cameras.Count + " cameras");
		
		//	Sort cameras into depth order starting from the lowest
		cameras.Sort (delegate(Camera cam1, Camera cam2)	{
			return cam1.depth.CompareTo (cam2.depth);
		});
		
		//	Enable first camera and its AudioListener
		activeCam = cameras [0];
		activeCam.enabled = true;
		listener = activeCam.GetComponent (typeof(AudioListener)) as AudioListener;										
		listener.enabled = true;
		
		//	Disable all other cameras and their AudioListeners
		for (int i = 1; i < cameras.Count; i++) {
			listener = cameras [i].GetComponent (typeof(AudioListener)) as AudioListener;
			listener.enabled = false;
			cameras [i].enabled = false;
		}
		
		//	Assign follow_cam and remove it from the list of cycling cameras
		foreach (Camera camera in cameras) {
			if (camera.tag == "followCam") {
				followCam = camera;
				Debug.Log ("Found a follower camera");
			}
		}
		cameras.Remove (followCam);
		
		StartCoroutine (WaitAndCycle (4));
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.F)) {
			followOn = returnOpposite (followOn);
			if (!followOn) {
				activeCam = cameras [0];
				SwitchCameras (followCam, activeCam);
			}
		}
		if (Input.GetKeyDown (KeyCode.Y)) {
			cycleOn = returnOpposite (cycleOn);
		}
		if (followOn) {
			SwitchCameras (activeCam, followCam);
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			CycleCameras ();
		}

	}

	IEnumerator WaitAndCycle (float lag)
	{
		while (true) {
			yield return new WaitForSeconds(lag);
			if (cycleOn) {
				CycleCameras ();
			}
		}
	}
	
	private void CycleCameras ()
	{	
		//	Finds active camera from cameras[] and switches to the next one.		
		for (int i = 0; i < cameras.Count; i++) {
			if (cameras [i].enabled == true) {
				if (i == cameras.Count - 1) {
					SwitchCameras (cameras [i], cameras [0]);
					return;
				} else {
					SwitchCameras (cameras [i], cameras [i + 1]);
					return;
				}
			}
		}
	}
	
	private void SwitchCameras (Camera fromCamera, Camera toCamera)
	{
		listener = fromCamera.GetComponent (typeof(AudioListener)) as AudioListener;
		listener.enabled = false;
		fromCamera.enabled = false;
		
		listener = toCamera.GetComponent (typeof(AudioListener)) as AudioListener;
		listener.enabled = true;
		toCamera.enabled = true;
		
		activeCam = toCamera;
	}
	
	public static Camera getActiveCamera ()
	{
		return activeCam;
	}
	
	private bool returnOpposite (bool boolean)
	{
		if (boolean) {
			return false;
		}
		return true;
	}
}

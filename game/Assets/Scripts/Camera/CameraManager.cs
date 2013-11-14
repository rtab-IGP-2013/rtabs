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
	private string guiText = "omglol";
	private int myGuiWidth = 200;
	
	void OnGUI ()
	{
		GUI.color = Color.yellow;
		Rect rect = new Rect (Screen.width - myGuiWidth - 150, Screen.height - 50, myGuiWidth, 50);
		
		GUI.Box (rect, guiText);;
		
		// Security camera borders
		int frameBorderLength = 50;
		int screenEdgeOffset = 20;
		int frameThickness = 2;
		Color frameColor = new Color32(100, 220, 31, 131);
		
		Texture2D horizontalTexture = new Texture2D(frameBorderLength, frameThickness);
		Texture2D verticalTexture = new Texture2D(frameThickness, frameBorderLength);
		for (int i = 0; i < frameBorderLength; i++) {
			for (int j = 0; j < frameThickness; j++) {
				horizontalTexture.SetPixel (i, j, frameColor);
				verticalTexture.SetPixel(j, i, frameColor);
			}
		}
		horizontalTexture.Apply();
		verticalTexture.Apply ();
		
		GUIStyle horizontalStyle = new GUIStyle();
		GUIStyle verticalStyle = new GUIStyle();
		horizontalStyle.normal.background = horizontalTexture;
		verticalStyle.normal.background = verticalTexture;
		
		GUI.Box (new Rect(screenEdgeOffset, screenEdgeOffset, frameBorderLength, frameThickness), "", horizontalStyle); // horizontal bar
		GUI.Box (new Rect(screenEdgeOffset, screenEdgeOffset, frameThickness, frameBorderLength), "", verticalStyle); // vertical bar
		
		GUI.Box (new Rect(screenEdgeOffset, Screen.height - screenEdgeOffset, frameBorderLength, frameThickness), "", horizontalStyle); // horizontal bar
		GUI.Box (new Rect(screenEdgeOffset, Screen.height - (screenEdgeOffset + frameBorderLength), frameThickness, frameBorderLength), "", verticalStyle); // vertical bar
		
		GUI.Box (new Rect(Screen.width - (screenEdgeOffset + frameBorderLength), screenEdgeOffset, frameBorderLength, frameThickness), "", horizontalStyle); // horizontal bar
		GUI.Box (new Rect(Screen.width - screenEdgeOffset, screenEdgeOffset, frameThickness, frameBorderLength), "", verticalStyle); // vertical bar
		 
		GUI.Box (new Rect(Screen.width - (screenEdgeOffset + frameBorderLength), Screen.height - screenEdgeOffset, frameBorderLength, frameThickness), "", horizontalStyle); // horizontal bar
		GUI.Box (new Rect(Screen.width - screenEdgeOffset, Screen.height - (screenEdgeOffset + frameBorderLength), frameThickness, frameBorderLength), "", horizontalStyle); // vertical bar
	}
	
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
		
		guiText = activeCam.gameObject.name;
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
		
		guiText = activeCam.gameObject.name;
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

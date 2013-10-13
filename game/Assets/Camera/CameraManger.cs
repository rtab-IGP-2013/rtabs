using UnityEngine;
using System.Collections;

public class CameraManger : MonoBehaviour
{
	
	public Camera cam1;
	public Camera cam2;
	public Camera cam3;
	public Camera cam4;
	public Camera cam5;
	
	// Use this for initialization
	void Start ()
	{
		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
		cam4.enabled = false;
		cam5.enabled = false;
		
		StartCoroutine (WaitAndCycle (2));
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.C)) {
			CycleCameras ();
		}
	}

	IEnumerator WaitAndCycle (float lag)
	{
		while (true) {
			yield return new WaitForSeconds(lag);
			CycleCameras ();
		}
	}
	
	void CycleCameras ()
	{
		if (cam1.enabled) {
			cam1.enabled = false;
			cam2.enabled = true;
		} else if (cam2.enabled) {
			cam2.enabled = false;	
			cam3.enabled = true;
		} else if (cam3.enabled) {
			cam3.enabled = false;
			cam4.enabled = true;
		} else if (cam4.enabled) {
			cam4.enabled = false;	
			cam5.enabled = true;
		} else if (cam5.enabled) {
			cam5.enabled = false;	
			cam1.enabled = true;
		}
	}
}
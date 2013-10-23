using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour
{

	public GUIStyle menuStyle;
	public Transform target; //checks if the player is visible and nothing is blocking the view
	Camera activecam;
	
	void Start ()
	{
	}
	
	void Update ()
	{
		if (CanSeePlayer ()) {
			Debug.LogWarning("Detector.CanSeePlayer() OLI TRUE");
			WaitAndLoadLevel(2.0f);
		}
	}
	
	bool CanSeePlayer ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		Vector3 viewPos = CameraManger.getActiveCamera().WorldToViewportPoint(player.transform.position);					//	CameraManger can't be found -> Causes NullReferenceException
		Vector3 here = GameObject.FindGameObjectWithTag ("activeCam").transform.position;
		Vector3 pos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		RaycastHit hit; 
		bool linecastHit = Physics.Linecast (here, pos, out hit);
		if (linecastHit && checkViewPos (viewPos) && hit.transform == player.transform) {
			return true;
		}
		return false;
	}
	
	bool checkViewPos (Vector3 viewPos)
	{
		if (viewPos.x > 0 && viewPos.y > 0 && viewPos.x < 1 && viewPos.y < 1 && viewPos.z > 0) {
			return true;
		} else {
			return false;
		}
	}
	
	void LoadGui ()
	{
		GUI.Label (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 100, 1000, 50), "Camera spotted you!", menuStyle);
	}
	
//	IEnumerator WaitAndLoadLevel (float wait)
	void WaitAndLoadLevel (float wait)
	{
		LoadGui ();
		//yield return new WaitForSeconds(wait);
		Application.LoadLevel (Application.loadedLevel);
	}
}
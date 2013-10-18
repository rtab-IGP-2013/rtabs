using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour
{

	public GUIStyle menuStyle;
	public Transform target; //checks if the player is visible and nothing is blocking the view
	
	void Start ()
	{
		
	}
	
	void Update ()
	{
		if (CanSeePlayer ()) {
			WaitAndLoadLevel(2.0f);
		}
	}
	
	bool CanSeePlayer ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		Vector3 viewPos = GameObject.FindGameObjectWithTag ("activeCam").GetComponent<Camera> ().WorldToViewportPoint (player.transform.position);
		Vector3 here = GameObject.FindGameObjectWithTag ("activeCam").transform.position;
		Vector3 pos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		// do a Linecast:
		RaycastHit hit; 
		bool linecastHit = Physics.Raycast (here, pos, out hit);
		//if (linecastHit && checkViewPos (viewPos) && hit.transform == player.transform) {
		if (player.collider == hit.collider) Debug.Log("HMMMMMMMMMMMMM collider mätsää");
		if (linecastHit) Debug.Log ("Hmm linecast hittaa");
		if (checkViewPos (viewPos)) Debug.Log ("Posseee");
		Debug.DrawLine(player.transform.position, player.transform.position + new Vector3(10,10,0));
		Debug.DrawLine(target.transform.position, target.transform.position + new Vector3(10,10,0));
		if (linecastHit && checkViewPos (viewPos) && hit.collider == player.collider) {
			Debug.LogWarning(" NO VITTU KOKO AJAN TRUE SAATANA ");
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
	
	IEnumerator WaitAndLoadLevel (float wait)
	{
		Debug.LogError("NO VOI HELVETTI");
		LoadGui ();
		yield return new WaitForSeconds(wait);
		Application.LoadLevel (Application.loadedLevel);
	}
}
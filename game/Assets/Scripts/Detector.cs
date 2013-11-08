using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour
{

	public GUIStyle menuStyle;
	public Transform target; 		//checks if the player is visible and nothing is blocking the view
	public Vector3 threshold;		//	How fast the player can move without being detected. Use this to compensate for movement smoothing (deceleration) if even necessary.
	public Vector3 start_position;
	public Transform start_marker;
	GameObject player;
	private SuspicionMeter suspicionMeter;
	Transform playerObject;
	private static float dToCorner = 0.4f;
	private Vector3[] corners = new Vector3[] {
                        new Vector3 (dToCorner, dToCorner, dToCorner),
                        new Vector3 (dToCorner, dToCorner, -dToCorner),
                        new Vector3 (dToCorner, -dToCorner, dToCorner),
                        new Vector3 (dToCorner, -dToCorner, -dToCorner),
                        
                        new Vector3 (-dToCorner, dToCorner, dToCorner),
                        new Vector3 (-dToCorner, dToCorner, -dToCorner),
                        new Vector3 (-dToCorner, -dToCorner, dToCorner),
                        new Vector3 (-dToCorner, -dToCorner, -dToCorner)
                };
	
	void Start ()
	{
		start_position = start_marker.position; //setting the respawn point
		threshold = new Vector3 (0.8f, 0, 0);		//	The direction of this vector does not matter, only the magnitude.
		FindPlayer ();
		playerObject = player.transform.Find ("w_box_5_w_box_5_w_box_5");
	}
	
	void Update ()
	{
		if (player == null){
			FindPlayer ();
		}
		if (CanSeePlayer ()) {
			Debug.Log ("Seen player");
			if (playerMoving () && !WinCondition.WinOrNot) {
				Debug.Log ("Seen player moving");
				this.gameObject.SendMessage ("AdjustSuspicionBar", 3, SendMessageOptions.RequireReceiver);
				//player.transform.position = start_position;  //port player to respawn BROKEN
						
				// WaitAndLoadLevel(2.0f);
			}
		}
	}
	
	void FindPlayer ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerObject = player.transform.Find ("w_box_5_w_box_5_w_box_5");
	}
	
	//	Checks if the active camera sees the player. If the player is behind another object the player is not seen.
	//	TODO:	Only detects if the center of the player object is visible. Needs to be changed to the whole player collider.
	//			player.collider.bounds.Contains (hit.transform.position) doesn't seem to be doing the trick :(
	bool CanSeePlayer ()
	{
		Vector3 viewPos = CameraManager.getActiveCamera ().WorldToViewportPoint (player.transform.position);
		Vector3 here = CameraManager.getActiveCamera ().transform.position;
		Vector3 pos = player.transform.position;
                
		foreach (Vector3 v in corners) {
			RaycastHit rch;
			bool didhit = Physics.Linecast (here, pos + v, out rch);
			Debug.DrawRay (new Vector3 (0, 0, 0), pos + v);
			if (checkViewPos (viewPos) && didhit) {
				if (rch.transform == player.transform) {
					Debug.Log ("You are seen");
					return true;
				}
//                                Debug.DrawRay (new Vector3 (0, 0, 0), rch.transform.position);
			}
		}
		return false;
	}
	
	//	Checks if player is within the given view.
	bool checkViewPos (Vector3 viewPos)
	{
		if (viewPos.x > 0 && viewPos.y > 0 && viewPos.x < 1 && viewPos.y < 1 && viewPos.z > 0) {
			return true;
		} else {
			return false;
		}
	}
	
	bool playerMoving ()
	{	
		if (player.rigidbody.velocity.magnitude > threshold.magnitude)
			return true;
		else
			return false;
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
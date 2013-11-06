using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour
{

	public GUIStyle menuStyle;
	public Vector3 threshold;		//	How fast the player can move without being detected. Use this to compensate for movement smoothing (deceleration) if even necessary.
	public Transform start_marker;
	GameObject player;
	private SuspicionMeter suspicionMeter;
	public GUIText debugGui;
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
		player = GameObject.FindGameObjectWithTag ("Player");
		threshold = new Vector3 (0.8f, 0, 0);		//	The direction of this vector does not matter, only the magnitude.
	}
	
	void Update ()
	{
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");	
		}
		if (CanSeePlayer ()) {
			if (playerMoving () && !WinCondition.WinOrNot) {
				Debug.Log ("Seen player moving");
				this.gameObject.SendMessage ("AdjustSuspicionBar", 3, SendMessageOptions.RequireReceiver);
			}
		}
	}
	
	//	Checks if the active camera sees the player. If the player is behind another object the player is not seen.
	//	TODO:	Only detects if the center of the player object is visible. Needs to be changed to the whole player collider.
	//			player.collider.bounds.Contains (hit.transform.position) doesn't seem to be doing the trick :(
	bool CanSeePlayer ()
	{
		Vector3 viewPos = CameraManger.getActiveCamera ().WorldToViewportPoint (player.transform.position);
		Vector3 here = CameraManger.getActiveCamera ().transform.position;
		Vector3 pos = player.transform.position;
		
		foreach (Vector3 v in corners) {
			RaycastHit rch;
			bool didhit = Physics.Linecast (here, pos + v, out rch);
			
			if (checkViewPos (viewPos) && didhit) {
				if (rch.transform == player.transform) {
					Debug.Log("You are seen");
					return true;
				}
//				Debug.DrawRay (new Vector3 (0, 0, 0), rch.transform.position);
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
}
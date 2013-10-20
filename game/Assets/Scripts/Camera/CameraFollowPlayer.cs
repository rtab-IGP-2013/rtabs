using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {
	int DistanceAway = 5;
	Vector3 PlayerPOS = GameObject.Find("w_box_5_w_box_5_w_box_5").transform.transform.position;
	
	// Use this for initialization
	void Start () {
	transform.Rotate(30, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 PlayerPOS = GameObject.Find("w_box_5_w_box_5_w_box_5").transform.transform.position;
		transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y + DistanceAway, PlayerPOS.z - DistanceAway);

	}
}

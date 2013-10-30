using UnityEngine;
using System.Collections;

public class Conveyor_SCRIPT : MonoBehaviour {
	
	public float speed = 0.5f;
	public float maxSpeed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//	Moves player (can be set to any object with tags) in direction of CONVEYOR BELT'S LOCAL Z AXIS
	void OnCollisionStay(Collision col)	
	{
		if(col.gameObject.rigidbody == null)	{
			return;
		}

		Rigidbody rigidbody = col.gameObject.rigidbody;
		
		if(rigidbody.velocity.magnitude < maxSpeed)
			rigidbody.AddForce(speed * transform.forward, ForceMode.VelocityChange);
	}
}

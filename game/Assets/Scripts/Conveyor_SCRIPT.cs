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
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag.Equals("Player")) {
			GameObject.FindGameObjectWithTag("Manager").SendMessage("SetOnConveyerBelt", true, SendMessageOptions.RequireReceiver);
		}
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
	
	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.tag.Equals("Player")) {
			GameObject.FindGameObjectWithTag("Manager").SendMessage("SetOnConveyerBelt", false, SendMessageOptions.RequireReceiver);
		}
	}
	
	public float getSpeed()	{
		return this.speed;
	}

	public void setSpeed(float targetSpeed)	{
		this.speed = targetSpeed;
	}
}

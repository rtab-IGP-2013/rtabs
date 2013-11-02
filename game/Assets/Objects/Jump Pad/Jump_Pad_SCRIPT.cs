using UnityEngine;
using System.Collections;

public class Jump_Pad_SCRIPT : MonoBehaviour {

	public float multiplier = 1.5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.rigidbody == null)
			return;
		
		Rigidbody rigidbody = col.gameObject.rigidbody;
		rigidbody.velocity = rigidbody.velocity + new Vector3 (0f, rigidbody.velocity.y * multiplier, 0f);
	}
}

using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {
	public static int speed = 1;
	float movement = 0.1f * speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		float player_x = Input.GetAxis("Mouse X");
//		float player_y = Input.GetAxis("Mouse Y");
		
//		transform.position = new Vector3(transform.position.x + player_x, transform.position.y + player_y, 0);
	
		if (Input.GetKey (KeyCode.LeftArrow)){
			rigidbody.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + movement);	
		
		}
		else if (Input.GetKey (KeyCode.RightArrow)){
			rigidbody.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - movement);
		}
		else if (Input.GetKey (KeyCode.DownArrow)){
			rigidbody.position = new Vector3 (transform.position.x - movement, transform.position.y, transform.position.z);
		}
		else if (Input.GetKey (KeyCode.UpArrow)){
			rigidbody.position = new Vector3 (transform.position.x + movement, transform.position.y, transform.position.z);
		}
		
	}
}

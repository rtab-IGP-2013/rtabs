using UnityEngine;
using System.Collections;

public class PlayerSoundController : MonoBehaviour {

	public AudioClip slideSound;
	public AudioClip dropSound;

	// Use this for initialization
	void Start () {
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "floor") {

		}
	}

	void OnCollisionStay(Collision col)	{
		if(col.gameObject.tag == "floor") {
			audio.volume = gameObject.transform.rigidbody.velocity.magnitude / gameObject.GetComponent<PlayerMovementController>().maxspeed;
		}
	}

	void OnCollisionExit(Collision col)	{
		if(col.gameObject.tag == "floor") {
			audio.volume = 0;
			Debug.Log("Exited collision");
		}
	}

}

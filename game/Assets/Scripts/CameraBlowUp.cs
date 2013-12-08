using UnityEngine;
using System.Collections;

public class CameraBlowUp : MonoBehaviour {

	public GameObject target;
	public Camera camera;
	public Light candle;
	private GameObject manager;
	
	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag("Manager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider col) {
		//audio.Play ();
		if(col.gameObject.tag ==  "Player"){
			Debug.Log("Player hit Switch");
			manager.SendMessage("TriggerPressed",SendMessageOptions.RequireReceiver);
			gameObject.collider.enabled = false;
			target.rigidbody.constraints=RigidbodyConstraints.None;
			target.rigidbody.AddForce(new Vector3(0,1,0));
   			candle.intensity=3;
			camera.tag="disabledCam";
		}
	}
}
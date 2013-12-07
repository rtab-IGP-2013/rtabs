using UnityEngine;
using System.Collections;

public class CameraBlowUp : MonoBehaviour {

	public GameObject target;
	public Camera camera;
	public Light candle;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider col) {
		//audio.Play ();
		if(col.gameObject.tag ==  "Player"){
			Debug.Log("Player hit Switch");
		target.rigidbody.constraints=RigidbodyConstraints.None;
		target.rigidbody.AddForce(new Vector3(0,1,0));
   		candle.intensity=3;
		camera.tag="disabledCam";
		}
	}
}
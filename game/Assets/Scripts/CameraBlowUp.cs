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
		if(col.gameObject.tag ==  "Player")
			Debug.Log("Player hit Switch");
		Destroy(target);
   		candle.intensity=3;
		GameObject manager = GameObject.FindGameObjectWithTag("Manager");
		manager.gameObject.SendMessage ("removeCamera",camera, SendMessageOptions.RequireReceiver);
	}
}
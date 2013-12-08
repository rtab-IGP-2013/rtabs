using UnityEngine;
using System.Collections;

public class RespawnPointScript : MonoBehaviour {
	
	public Transform startMarker;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(){
		startMarker.position = this.transform.position;	
	}
}

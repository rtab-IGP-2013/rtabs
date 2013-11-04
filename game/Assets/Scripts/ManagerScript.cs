using UnityEngine;
using System.Collections;

public class ManagerScript : MonoBehaviour {
	public GameObject player;
	public Transform startMarker;
	
	// Use this for initialization
	void Start () {
		Instantiate(player, startMarker.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void KillPlayer() {
		Debug.Log ("Well fuu I'm dead");
	}
}

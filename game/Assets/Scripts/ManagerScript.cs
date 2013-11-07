using UnityEngine;
using System.Collections;

public class ManagerScript : MonoBehaviour
{
	public GameObject explosionPrefab;
	private GameObject explosion;
	public GameObject player;
	public Transform startMarker;	
	
	// Use this for initialization
	void Start ()
	{
		Instantiate (player, startMarker.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.End)){
			explosion = (GameObject)Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			KillPlayer ();
			explosion.particleSystem.Play();
			Destroy (explosion, 2.0f);
		}
	}
	
	void KillPlayer ()
	{
		Debug.Log ("Well fuu I'm dead");
		SendMessage ("ResetSuspicionMeter", SendMessageOptions.RequireReceiver);
		Destroy (GameObject.FindGameObjectWithTag ("Player"));
		Instantiate (player, startMarker.position, Quaternion.identity);
	}
}

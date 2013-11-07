using UnityEngine;
using System.Collections;

public class ManagerScript : MonoBehaviour
{
	public GameObject explosionPrefab;
	private GameObject explosion;
	public GameObject playerPrefab;
	private GameObject player;
	public Transform startMarker;	
	
	// Use this for initialization
	void Start ()
	{
		Instantiate (playerPrefab, startMarker.position, Quaternion.identity);
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.End)){
			player = GameObject.FindGameObjectWithTag("Player");
			explosion = (GameObject)Instantiate (explosionPrefab, player.transform.position, new Quaternion(-1.0f, 0.0f, 0.0f, 1.0f));
			explosion.particleSystem.Play();
			Destroy (explosion, 2.0f);
			KillPlayer ();
		}
	}
	
	void KillPlayer ()
	{
		Debug.Log ("Well fuu I'm dead");
		SendMessage ("ResetSuspicionMeter", SendMessageOptions.RequireReceiver);
		Destroy (GameObject.FindGameObjectWithTag ("Player"));
		Instantiate (playerPrefab, startMarker.position, Quaternion.identity);
		player = GameObject.FindGameObjectWithTag("Player");
	}
}

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
		//unlock this level
		PlayerPrefs.SetInt ("unlocked" + Application.loadedLevelName, 1);
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
		//go back to menu
		if (Input.GetKeyDown(KeyCode.M)){
			Application.LoadLevel("menu");
		}
		//reset save history
		if (Input.GetKeyDown(KeyCode.R)){
			PlayerPrefs.SetInt("unlockedLevel2", 0);
			PlayerPrefs.SetInt("unlockedLevel3", 0);
			PlayerPrefs.SetInt("unlockedLevel4", 0);
			PlayerPrefs.SetInt("unlockedLevel5", 0);
			PlayerPrefs.SetInt("unlockedLevel6", 0);
			PlayerPrefs.SetInt("unlockedLevel7", 0);
			PlayerPrefs.SetInt("unlockedLevel8", 0);
			PlayerPrefs.SetInt("unlockedLevel9", 0);
			PlayerPrefs.SetInt("unlockedLevel10", 0);
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

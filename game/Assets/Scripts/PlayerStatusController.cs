using UnityEngine;
using System.Collections;

public class PlayerStatusController : MonoBehaviour {

	private GameObject explosion;
	private GameObject gameManager;
	
	private void Start(){
		explosion = GameObject.FindGameObjectWithTag("explosion");
		gameManager = GameObject.FindGameObjectWithTag("Manager");
		//explosion.particleSystem.Stop();
	}

	public void Update(){
		if (Input.GetKeyDown(KeyCode.End)){
			explosion.transform.position = transform.position;
			Destroy(gameObject);
			gameManager.SendMessage ("KillPlayer", SendMessageOptions.RequireReceiver);
			explosion.particleSystem.Play();
		}
	}
}

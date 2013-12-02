using UnityEngine;
using System.Collections;

public class BlockCrusherScript : MonoBehaviour {
	
	GameObject gameManager;
	
	void OnTriggerEnter (Collider box)
	{
		if (box.tag.Equals("Player")) gameManager.SendMessage("KillPlayer", SendMessageOptions.RequireReceiver);
		else Destroy(box.gameObject);
	}
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag("Manager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

﻿using UnityEngine;
using System.Collections;

public class SwitchOnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag ==  "Player"){
			this.renderer.material.mainTextureOffset = new Vector2(0,0);
			
			GameObject manager = GameObject.FindGameObjectWithTag("Manager");	
			manager.gameObject.SendMessage ("findCameras", SendMessageOptions.RequireReceiver);
		}
	}
}

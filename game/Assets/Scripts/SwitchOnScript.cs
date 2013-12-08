using UnityEngine;
using System.Collections;

public class SwitchOnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(){
		this.renderer.material.mainTextureOffset = new Vector2(0,0);	
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WinBlock_SCRIPT : MonoBehaviour {
	
	public GUITexture[] winTexts = new GUITexture[1];
	
	void Start () {
	}
	
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision col)	{
		if(col.gameObject.tag  == "Player")
			Win();
	}
	
	void Win()	{
		int rand = Random.Range(0, winTexts.Length);
		Instantiate(winTexts[rand], new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
		Destroy (gameObject);
	}
}

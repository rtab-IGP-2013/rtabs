using UnityEngine;
using System.Collections;

public class ChangeToCredits : MonoBehaviour {
	private float timeToCredits;
	private bool doIt=false;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider col) {
		//audio.Play ();
		if(col.gameObject.tag ==  "Player"){
			doIt = true;	
		}
	}
	// Update is called once per frame
	void Update () {
		if(doIt){
		timeToCredits += Time.deltaTime;
		}
		if (timeToCredits > 2){
			Application.LoadLevel("Credits");
		}
	}
}

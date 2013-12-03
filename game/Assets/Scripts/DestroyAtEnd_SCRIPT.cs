using UnityEngine;
using System.Collections;

public class DestroyAtEnd_SCRIPT : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Spawned drop sound");
		audio.Play();
		Countdown();
		//Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Countdown()	{
		Debug.Log ("Sound length: " + gameObject.audio.clip.length);
		yield return new WaitForSeconds(gameObject.audio.clip.length);
	}
}

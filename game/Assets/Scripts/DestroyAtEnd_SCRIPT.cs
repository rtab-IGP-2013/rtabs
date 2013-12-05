using UnityEngine;
using System.Collections;

public class DestroyAtEnd_SCRIPT : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Spawned drop sound");
		audio.Play ();
		StartCoroutine ("CountdownAndDestroy");
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	WaitForSeconds Countdown ()
	{
		Debug.Log ("Sound length: " + gameObject.audio.clip.length);
		return new WaitForSeconds (gameObject.audio.clip.length);
	}
	
	IEnumerator CountdownAndDestroy ()
	{
		for (int i = 0; i < 2; i++) {
			yield return Countdown();
			Destroy (gameObject);	
		}
	}
}

using UnityEngine;
using System.Collections;

public class PlaySoundOnStart : MonoBehaviour {
	
	public AudioClip sound;
	
	// Use this for initialization
	void Start () {
		if(sound != null)
			audio.PlayOneShot (sound);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
public class FinalScript : MonoBehaviour {
	public Camera camera;
	public Light Spotlight;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		void OnTriggerEnter(Collider col) {
	
		if(col.gameObject.tag ==  "Player"){
			audio.Play();
			GameObject music = GameObject.FindGameObjectWithTag("Music");
			music.audio.Stop();
			Debug.Log("Player hit Switch");
   			Spotlight.intensity=3;
			
		}
		
	}
	
}

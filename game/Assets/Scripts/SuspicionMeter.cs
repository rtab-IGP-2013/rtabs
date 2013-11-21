using UnityEngine;
using System.Collections;


public class SuspicionMeter : MonoBehaviour {
	private int maxSuspicion = 100;
	private int currentSuspicion = 0;
	private float suspicionBarLength;
	private int frameCounter = 0;
	private int decaysSuspicion = 5; // every 5 frames
    private string text = "SUSPICIOUS";
	
	// Use this for initialization
	void Start () {
		suspicionBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.currentSuspicion == maxSuspicion) {
			currentSuspicion = 0;
			this.gameObject.SendMessage ("KillPlayer", SendMessageOptions.RequireReceiver);
		}
		
		if (frameCounter == 0) {
			AdjustSuspicionBar(-1);
		}
		frameCounter = (frameCounter + 1) % decaysSuspicion;
	}
	
	void OnGUI() {

        GUI.Box(new Rect(Screen.width / 2 - 200, 10, Mathf.Max(suspicionBarLength, 15), 20), text.Substring(0, Mathf.Min((int)Mathf.Floor(currentSuspicion / (text.Length-2)), text.Length))); // As numbers: currentSuspicion + "/" + maxSuspicion
	}
	
	void ResetSuspicionMeter() {
		currentSuspicion = 0;	
	}
	
	void AdjustSuspicionBar(int adj) {
		currentSuspicion += adj;
		if (currentSuspicion < 0) {
			currentSuspicion = 0;
		}
		
		if (currentSuspicion > maxSuspicion) {
			currentSuspicion = maxSuspicion;	
		}
		
		 suspicionBarLength = (Screen.width / 2) * (currentSuspicion / (float)maxSuspicion);
	}
}

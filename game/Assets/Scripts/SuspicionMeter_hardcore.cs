using UnityEngine;
using System.Collections;


public class SuspicionMeter_hardcore : MonoBehaviour {
	private int maxSuspicion = 100;
	private int currentSuspicion = 0;
	private float suspicionBarLength;
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
	}
	
	void OnGUI() {

        GUI.Box(new Rect(10, 10, Mathf.Max(suspicionBarLength, 15), 20), text.Substring(0, Mathf.Min((int)Mathf.Floor(currentSuspicion / (text.Length-2)), text.Length))); // As numbers: currentSuspicion + "/" + maxSuspicion
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

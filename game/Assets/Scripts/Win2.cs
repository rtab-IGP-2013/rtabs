using UnityEngine;
using System.Collections;

public class Win2 : MonoBehaviour {
	static string text = "";
	public static bool WinOrNot = false;
	void OnGUI(){
		GUI.Label(new Rect(10,10,200,80),text);
	}
		IEnumerator OnTriggerEnter (Collider box) {

		text = "You win the game!!!";
		WinOrNot = true;
		yield return new WaitForSeconds(2);
		Application.LoadLevel ("turningCameras"); 

}

}


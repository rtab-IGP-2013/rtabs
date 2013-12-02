using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour
{
	static string text = "";
	public static bool WinOrNot = false;
	public GUITexture[] winTexts = new GUITexture[1];

	void OnGUI ()
	{
		GUI.Label (new Rect (10, 10, 200, 80), text);
		
		
		
	}

	IEnumerator OnTriggerEnter (Collider box)
	{
		if(box.tag == "Player") {
			int rand = Random.Range (0, winTexts.Length);
			Instantiate (winTexts [rand], new Vector3 (0.5f, 0.5f, 0), Quaternion.identity);
			text = "You win the game!!!";
			WinCondition.WinOrNot = true;
			gameObject.renderer.enabled = false;
			gameObject.collider.enabled = false;
			yield return new WaitForSeconds(2);
			WinCondition.WinOrNot = false;
			text = "";
			
			Application.LoadLevel (Application.loadedLevel + 1);
		}
		
	}
	
	void Update ()
	{	
		//cheat to win if V is pressed
		if (Input.GetKeyDown (KeyCode.V)) {
			WinCondition.WinOrNot = true;
			gameObject.renderer.enabled = false;
			gameObject.collider.enabled = false;
			
			WinCondition.WinOrNot = false;
			text = "";
			
			Application.LoadLevel (Application.loadedLevel + 1);
			
		}
	}
	
	
	
}


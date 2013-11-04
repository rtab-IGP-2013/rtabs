using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour
{
	static string text = "";
	public static bool WinOrNot = false;

	void OnGUI ()
	{
		GUI.Label (new Rect (10, 10, 200, 80), text);
	}
	// Use this for initialization
	void Start ()
	{
        
	}
        
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.z > 40.0f) {
			//do something
			text = "You win the game!!!";
			WinOrNot = true;


		}
	}
}
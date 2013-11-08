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

	IEnumerator OnTriggerEnter (Collider box)
	{
		text = "You win the game!!!";
		WinCondition.WinOrNot = true;
		yield return new WaitForSeconds(2);
		WinCondition.WinOrNot = false;
		text = "";
		Application.LoadLevel ("menu"); 

	}

}


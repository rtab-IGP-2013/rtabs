using UnityEngine;
using System.Collections;

public class Win2 : MonoBehaviour
{
	static string text = "";
	public GUITexture[] winTexts = new GUITexture[1];

	void OnGUI ()
	{
		GUI.Label (new Rect (10, 10, 200, 80), text);
	}

	void OnCollisionEnter (Collision box)
	{
		StartCoroutine ("Win", box);
		gameObject.collider.enabled = false;
	}
	
	IEnumerator Win (Collision box)
	{
		text = "You win the game!!!";
		WinCondition.WinOrNot = true;
		if (box.gameObject.tag == "Player") {
			int rand = Random.Range (0, winTexts.Length);
			Instantiate (winTexts [rand], new Vector3 (0.5f, 0.5f, 0), Quaternion.identity);
		}
		Debug.Log ("got to the endBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
		yield return new WaitForSeconds(2);
		Debug.Log ("got to the endAJHSJHGSAJHGFSAJHGFSAJHGFSAJHGFSAJHGFSASAHGFHGFSAHGFSA");
		WinCondition.WinOrNot = false;
		text = "";
		Application.LoadLevel ("menu");
		Destroy (gameObject);
	}

}


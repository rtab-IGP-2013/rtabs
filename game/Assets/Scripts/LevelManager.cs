using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{



	void Start ()
	{
		PlayerPrefs.SetInt ("unlockedLevel1", 1);
		
	}

	void OnGUI ()
	{
		GUILayout.BeginArea (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 400));
		GUILayout.FlexibleSpace ();
		
		for (int i = 1; i < 99; i++) {
			if (PlayerPrefs.GetInt ("unlockedLevel" + i, 0) == 1) {
				if (GUILayout.Button ("Level " + i, GUILayout.Height (50))) {
					LoadLevel (i);
				}
			}
		}
		
		if (GUILayout.Button ("Go back to menu", GUILayout.Height (50))) {
			Application.LoadLevel ("menu");
		}
	
		GUILayout.FlexibleSpace ();
		GUILayout.EndArea ();
		
        
	}
	
	void LoadLevel (int levelNumber)
	{
		Application.LoadLevel ("Level" + levelNumber);
		
	}

}
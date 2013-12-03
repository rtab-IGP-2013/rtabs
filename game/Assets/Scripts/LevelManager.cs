using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	private string LevelName;
	void Start ()
	{
		PlayerPrefs.SetInt ("unlockedLevel1", 1);
		
	}

	void OnGUI ()
	{
		GUILayout.BeginArea (new Rect (Screen.width / 2 - 300, Screen.height / 2 - 100, 600, 400));
		
		GUILayout.FlexibleSpace ();
		
		for (int i = 1; i < 8; i++) {
			
			switch(i){
			case 1:
				LevelName = "Level 1 - Tutorial";
				break;
			case 2:
				LevelName = "Level 2 - Dropbox";
				break;
			case 3:
				LevelName = "Level 3 - Freudian Slip";
				break;
			case 4:
				LevelName = "Level 4 - Down the well";
				break;
			case 5:
				LevelName = "Level 5 - Box Office";
				break;
			case 6:
				LevelName = "Level 6 - Maritime Museum";
				break;
			case 7:
				LevelName = "Level 7 - Mesa Box";
				break;		
			}
			
			
			
			if (i == 1 || i == 3 || i == 5 || i == 7) {
				GUILayout.BeginHorizontal ();
			}			
			if (PlayerPrefs.GetInt ("unlockedLevel" + i, 0) == 1) {
				if (GUILayout.Button (LevelName, GUILayout.Height (50), GUILayout.Width (280))) {
					LoadLevel (i);
				}
			}
			if (i == 2 || i == 4 || i == 6 || i == 7) {
				GUILayout.EndHorizontal ();
			}
		}
		
		
		
		
		if (GUILayout.Button ("Go back to menu", GUILayout.Height (50), GUILayout.Width (565))) {
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
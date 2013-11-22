using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{



	void Start ()
	{
        
	}

	void OnGUI ()
	{
		GUILayout.BeginArea (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 400));
		GUILayout.FlexibleSpace ();
		if (GUILayout.Button ("Play!", GUILayout.Height (50))) {
			SelectLevel ();
		}
		if (GUILayout.Button ("Setting", GUILayout.Height (50))) {
			
		}
		if (GUILayout.Button ("Help", GUILayout.Height (50))) {
			
		}
		if (GUILayout.Button ("Rage quit", GUILayout.Height (50))) {
			Application.Quit ();
		}
		
		GUILayout.FlexibleSpace ();
		GUILayout.EndArea ();
		
        
	}

	void SelectLevel ()
	{
		Application.LoadLevel ("LevelManager");
	}

}
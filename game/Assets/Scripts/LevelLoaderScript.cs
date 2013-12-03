using UnityEngine;
using System.Collections;

public class LevelLoaderScript : MonoBehaviour
{
	float progress = 0.0f;
	Vector2 pos = new Vector2 ((Screen.width / 2) - 300, (Screen.height / 2) - 10);
	Vector2 size = new Vector2 (600, 20);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	void OnGUI ()
	{
		GUI.DrawTexture (new Rect (pos.x, pos.y, size.x, size.y), progressBarEmpty);
		GUI.DrawTexture (new Rect (pos.x, pos.y, size.x * Mathf.Clamp01 (progress), size.y), progressBarFull);
	} 
	
	// Update is called once per frame
	void Update ()
	{
		if (Application.GetStreamProgressForLevel (Application.loadedLevel + 1) == 1) {
			Application.LoadLevel (Application.loadedLevel + 1);
		}
		progress = Application.GetStreamProgressForLevel(Application.loadedLevel + 1);
		
	}
}

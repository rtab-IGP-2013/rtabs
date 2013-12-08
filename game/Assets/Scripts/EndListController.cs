using UnityEngine;
using System.Collections;

public class EndListController : MonoBehaviour
{
	private float scrollspeed;
	private string list = "              RTABS\n\n\n         -Programming-\n\n            Gameplay\n\n        Lassi Vapaakallio\n\n          Misa Jokisalo\n\n          Ville Virtanen\n\n         Tony Kovanen\n\n            Jiawei Jin\n\n\n               Sound\n\n          Misa Jokisalo\n\n          Ville Virtanen\n\n         Tony Kovanen\n\n            Jiawei Jin\n\n       Lassi Vapaakallio\n\n\n              Physics\n\n          Ville Virtanen\n\n         Tony Kovanen\n\n            Jiawei Jin\n\n       Lassi Vapaakallio\n\n          Misa Jokisalo\n\n\n          -Game Design-\n\n         Tony Kovanen\n\n            Jiawei Jin\n\n       Lassi Vapaakallio\n\n          Misa Jokisalo\n\n          Ville Virtanen\n\n\n          -Level Design-\n\n            Jiawei Jin\n\n       Lassi Vapaakallio\n\n          Misa Jokisalo\n\n          Ville Virtanen\n\n         Tony Kovanen\n\n\n        -Concept Design-\n\n        Lassi Vapaakallio\n\n\n     -Original Soundtrack-\n\n           Jimi Welling\n\n\n      -Sound Engineering-\n\n          Juuso Leinonen\n\n           Misa Jokisalo\n\n\n           -Voice Actor-\n\n           Misa Jokisalo\n\n\n-Animation Technical Director-\n\n         Misacorp Visuals\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n   Thank you for playing!";
	private bool switchToMenu;
	private int i;
	private float flagTime;
	public GUIStyle myStyle;
	public Texture2D logo_RTABS;
	// Use this for initialization
	void Start ()
	{
		
		scrollspeed = 0;
		i = 0;
		flagTime  = 0f;
	}
	
	void OnGUI ()
	{
		GUI.DrawTexture(new Rect(Screen.width * 0.05f,Screen.height * 0.1f, Screen.width * 0.35f, Screen.height * 0.20f),logo_RTABS);
		
		GUI.Label (new Rect (Screen.width / 2-100, Screen.height - scrollspeed, 400, 4000), list,myStyle);
		if(scrollspeed <= 4100){
			scrollspeed = scrollspeed + (float)Screen.height * 0.001f;
		}
		
		if(!switchToMenu && scrollspeed > 4100){
			switchToMenu = !switchToMenu;
			
			
		}
		
		
			
		
	}
	
	
	
	// Update is called once per frame
	void Update ()
	{
		if(switchToMenu){
			flagTime += Time.deltaTime;
		}
		if (flagTime > 4){
			Application.LoadLevel("menu");
		}
		
	}
}

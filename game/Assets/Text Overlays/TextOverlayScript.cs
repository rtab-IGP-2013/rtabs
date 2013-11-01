using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextOverlayScript : AbstractOverlayScript {

	// Use this for initialization
	void Start () {		
		Texture2D[] frames = new Texture2D[28];
		fps = 20;
		width = 1025;
		height = 512;
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		if(play)
			PlayAnimation();
	}
	
}

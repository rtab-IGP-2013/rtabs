using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelIntroAnimationScript : MonoBehaviour {
	
	public Texture2D[] frames = new Texture2D[29];
	public int fps = 20;
	private bool play;
	
	// Use this for initialization
	void Start () {
		float width = 1025;
		float height = 512;
		guiTexture.pixelInset = new Rect(-1 * width/2, -1 * height/2, width, height);
		play = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(play)
			PlayAnimation();
	}
	
	//	Can someone try to get the game to wait 1 second before it plays the animation?
	void PlayAnimation()	{
		int index = (int)(Time.time * fps);
		index = index % frames.Length;

		guiTexture.texture = frames[index];
		
		if(index >= frames.Length-1)
			play = false;
	}
}

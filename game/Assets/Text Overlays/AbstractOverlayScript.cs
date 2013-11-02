using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractOverlayScript : MonoBehaviour {
	
	public Texture2D[] frames;
	public int fps;
	public float width;
	public float height;
	protected bool play;
	
	protected void Start () {
		//	Initialize these in your subclass here:
		//	frames size
		//	fps
		//	width
		//	height		
		guiTexture.pixelInset = new Rect(-1 * width/2, -1 * height/2, width, height);
		play = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(play)
			PlayAnimation();
	}
	
	//	Can someone try to get the game to wait 1 second before it plays the animation?
	protected void PlayAnimation()	{
		int index = (int)(Time.time * fps);
		index = index % frames.Length;

		guiTexture.texture = frames[index];
		
		if(index >= frames.Length-1)	{
			play = false;
			Destroy(gameObject);
		}
	}
}

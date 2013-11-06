/*
 * 
 * 
 * THIS SCRIPT IS OUTDATED. PLEASE USE ANIMATIONSCRIPT.CS
 * 
 * 
 * 
 * */


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractOverlayScript : MonoBehaviour {
	
	public Texture2D[] frames;
	public int loopFrame;					//	Which frame to loop. This is the one with the full text.
	public int loopDuration; 				//	How many frames to loop for.
	public int fps;
	public float width;
	public float height;
	protected bool play;
	private int phase;
	
	
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
		phase = 0;
		if(play)
			PlayAnimation();
	}
	
	//	Can someone try to get the game to wait 1 second before it plays the animation?
	protected void PlayAnimation()	{
		/*int index = (int)(Time.time * fps);
		index = index % frames.Length;

		guiTexture.texture = frames[index];
		
		if(index >= frames.Length-1)	{
			play = false;
			Destroy(gameObject);
		}*/
		
		if(phase == 0)
			StartAnimation();
		else if(phase == 1)
			LoopAnimation();
		else if(phase == 2)
			EndAnimation ();
	}
	
	void StartAnimation()	{
		int index = (int)(Time.time * fps);
		index = index % frames.Length;

		guiTexture.texture = frames[index];
		
		if(index >= loopFrame)	{
			phase = 1;
		}
	}
	
	void LoopAnimation()	{
		int i = (int)(Time.time * fps);
		i = i % frames.Length;
		
		Debug.Log("i = " + i);
		guiTexture.texture = frames[loopFrame];
		if(i > loopDuration)	{
			Debug.Log ("i > loopDuration");
			phase = 2;
		}
	}
	
	void EndAnimation()	{
		int index = (int)(Time.time * fps);
		index = index % frames.Length;
		
		guiTexture.texture = frames[index];
		
		if(index >= frames.Length-1)	{
			play = false;
			Destroy(gameObject);
		}
	}
}

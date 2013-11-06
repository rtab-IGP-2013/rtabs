using UnityEngine;
using System.Collections;


public class AnimationScript : MonoBehaviour {
	
	public int framesPerSecond = 40;
	public Texture2D[] myTextures;
	
	//	These are defined by the textures. Don't change them arbitrarily unless you want nasty scaling to happen!
	public int width = 1024;
	public int height = 512;
	
	public int loopFrame = 8;					//	Which frame to loop
	public int loopDuration = 20;				//	How many frames to loop for?
	
	
	// Use this for initialization
	void Start () {
		guiTexture.pixelInset = new Rect(-1 * width/2, -1 * height/2, width, height);
		StartCoroutine(PlayAnim());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator PlayAnim()	{
		float waitTime = 1.0f/framesPerSecond;
		for (int i = 0; i < myTextures.Length; i++)	{
			if(i == loopFrame)	{								// Loop de loop AKA just stop for a fixed amount of time to display the text.
				for (int j = 0; j < loopDuration; j++)	{
					yield return new WaitForSeconds(waitTime);
				}
			}
			guiTexture.texture = myTextures[i];
			yield return new WaitForSeconds (waitTime);
		}
		guiTexture.enabled = false;
		Destroy (gameObject);
	}
	
	
	
}

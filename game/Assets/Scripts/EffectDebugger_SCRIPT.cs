using UnityEngine;
using System.Collections;

public class EffectDebugger_SCRIPT : MonoBehaviour {
	
	public GUITexture[] debugTexts = new GUITexture[1];
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("left alt"))	{
			int rand = Random.Range(0, debugTexts.Length);
			Instantiate(debugTexts[rand], new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
		}
	}
}

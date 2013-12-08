using UnityEngine;
using System.Collections;

public class ExplosionColor_SCRIPT : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			child.gameObject.renderer.material.color = new Color(Random.value, Random.value, Random.value);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

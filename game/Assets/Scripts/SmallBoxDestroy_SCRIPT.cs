using UnityEngine;
using System.Collections;

public class SmallBoxDestroy_SCRIPT : MonoBehaviour {

	public Transform audioPrefab;
	private bool firstcollision;
	// Use this for initialization
	void Start () {
		firstcollision = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {
		if(firstcollision == true) {

			if(col.gameObject.tag == "Player") {
				Instantiate(audioPrefab, new Vector3(0,0,0), Quaternion.identity);
				Destroy (gameObject);
			}
		}
	}

	void OnCollisionExit()	{
		firstcollision = true;
	}

}

using UnityEngine;
using System.Collections;

public class Switch_Explosion_SCRIPT : MonoBehaviour {

	public GameObject target;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag ==  "Player")
			Debug.Log("Player hit Switch");
		target.GetComponent<ExplosionForce_SCRIPT>().Explode();
	}
}

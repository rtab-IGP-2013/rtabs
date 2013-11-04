using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public static int PlayerLife;
	bool respawn = false;
	
	void Start()	{
		PlayerLife = 1;	
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerLife <= 0){
			respawn = true;
		}
		else {
			respawn = false;
		}
		if (respawn){
			transform.position = new Vector3(0,transform.position.y,0);
			PlayerLife++;
		}
	}
}

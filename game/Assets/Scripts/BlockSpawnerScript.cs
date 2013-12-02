using UnityEngine;
using System.Collections;

public class BlockSpawnerScript : MonoBehaviour {
	public GameObject Spawned;
	public int SpawnTime;

	// Use this for initialization
	void Start () {
		StartCoroutine("WaitAndSpawn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator WaitAndSpawn ()
	{
		while (true) {
			yield return new WaitForSeconds(SpawnTime);
			Instantiate(Spawned, this.transform.position, Quaternion.identity);
		}
	}
}

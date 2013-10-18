using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour {

	private GUIStyle menuStyle;
	public Transform target; //checks if the player is visible and nothing is blocking the view
	
	void Start () {
		
	}
	
	void Update (){
		if(CanSeePlayer()){
			Reset ();
		}
	}
	
	void Reset(){
		OnGUI();
		Application.LoadLevel(Application.loadedLevel);
	}
	
	bool CanSeePlayer(){
		Vector3 viewPos = GameObject.FindGameObjectWithTag("activeCam").GetComponent<Camera>().WorldToViewportPoint (target.position);
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Vector3 here = GameObject.FindGameObjectWithTag("activeCam").transform.position;
		Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
		// do a Linecast:
      	RaycastHit hit; 
		Physics.Linecast(here, pos, out hit);
		if(checkViewPos(viewPos) && hit.transform == player.transform){
			return false;
		}
		return true;
	}
	
	bool checkViewPos(Vector3 viewPos){
		if(viewPos.x>0 && viewPos.y>0 && viewPos.x<1 && viewPos.y<1 && viewPos.z>0){
			return true;
		}
		else{
			return false;
		}
	}
	
	void OnGUI(){
		GUI.Label(new Rect(Screen.width/2-200,Screen.height/2-100,1000,50),"Camera spotted you!", menuStyle);
	}
}
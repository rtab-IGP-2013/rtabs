using UnityEngine;
using System.Collections;

public class SecurityCameraControl : MonoBehaviour {
	public enum Axis { HORIZONTAL, VERTICAL };
	
	public Axis axis = Axis.HORIZONTAL;
	public int positiveRadius = 200;
	public int negativeRadius = 500;
	public float turningSpeed = 0.8f;
	
	float currentAngle;
	public bool movingInPositiveDirection = true;
	

	// Use this for initialization
	void Start () {
		currentAngle = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (axis == Axis.VERTICAL) {
			if (movingInPositiveDirection) {
				transform.Rotate (new Vector3(turningSpeed, 0, 0));
				currentAngle++;
				if (currentAngle >= positiveRadius) movingInPositiveDirection = false; 
			} else {
				transform.Rotate (new Vector3(-turningSpeed, 0, 0));
				currentAngle--;
				if (currentAngle <= -negativeRadius) movingInPositiveDirection = true;
			}
		} else {
			if (movingInPositiveDirection) {
				transform.Rotate (new Vector3(0, turningSpeed, 0));
				currentAngle++;
				if (currentAngle >= positiveRadius) movingInPositiveDirection = false; 
			} else {
				transform.Rotate (new Vector3(0, -turningSpeed, 0));
				currentAngle--;
				if (currentAngle <= -negativeRadius) movingInPositiveDirection = true;
			}
		}
	}
}

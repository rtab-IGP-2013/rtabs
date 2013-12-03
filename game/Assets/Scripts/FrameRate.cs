using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {
    void Awake() { //set framerate
        Application.targetFrameRate = 60;
    }
}
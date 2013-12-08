using UnityEngine;
using System.Collections;

public class FrameRate : MonoBehaviour {
    void Awake() { //set framerate
        Application.targetFrameRate = 60;
    }
}
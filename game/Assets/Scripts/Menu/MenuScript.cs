using UnityEngine;
using System.Collections;
public class MenuScript : MonoBehaviour {

    public float buttonWidth = 400.0f;
    public float buttonHeight = 75.0f;
    public float margin = 10.0f;
    float hCenter;
    float vCenter;

    void Start()
    {
        hCenter = (Screen.width / 2) - (buttonWidth / 2);
        vCenter = (Screen.height / 2) - (buttonHeight / 2);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(hCenter, vPosition(0), buttonWidth, buttonHeight), "Start sneakin'"))
        {
            Application.LoadLevel("main");
        }
        if (GUI.Button(new Rect(hCenter, vPosition(1), buttonWidth, buttonHeight), "Dropping the bassbox"))
        {
            Application.LoadLevel("dropbox");
        }
        if (GUI.Button(new Rect(hCenter, vPosition(2), buttonWidth, buttonHeight), "Rage quit"))
        {
            Application.Quit();
        }
    }

    float vPosition(int order)
    {
        return vCenter + (order * (buttonHeight + margin));
    }
}
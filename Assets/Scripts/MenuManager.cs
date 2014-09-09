using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    int BUTTON_WIDTH;
    int BUTTON_HEIGHT;
    int BUTTON_POS_X;
    int BUTTON_POS_Y;

	void Start() {
        BUTTON_WIDTH = (int)(Screen.width * 0.10f);
        BUTTON_HEIGHT = (int)(Screen.height * 0.10f);
        BUTTON_POS_X = Screen.width/2 - BUTTON_WIDTH/2;
        BUTTON_POS_Y = Screen.height * 7/12;
	}

    void OnGUI() {
        if (GUI.Button(new Rect(BUTTON_POS_X, BUTTON_POS_Y, BUTTON_WIDTH, BUTTON_HEIGHT), "Play")) {
            Debug.Log("Play");
        }
        if (GUI.Button(new Rect(BUTTON_POS_X, BUTTON_POS_Y + BUTTON_HEIGHT + 10, BUTTON_WIDTH, BUTTON_HEIGHT), "About")) {
            Debug.Log("About");
        }
    }

	void Update() {
	
	}
}

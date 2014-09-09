using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    Object talismanPrefab;
    float TALISMAN_START_X;
    float TALISMAN_END_X;
    float TALISMAN_TOP_Y;
    float TALISMAN_BOTTOM_Y;
    int TALISMAN_NUM;

	void Start() {
        talismanPrefab = Resources.Load("Talisman");
        TALISMAN_START_X = -5.0f;
        TALISMAN_END_X = 175.0f;
        TALISMAN_TOP_Y = 5.0f;
        TALISMAN_BOTTOM_Y = -5.0f;
        TALISMAN_NUM = 150;

        float interval = (TALISMAN_END_X - TALISMAN_START_X) / TALISMAN_NUM;
        for (int i = 0; i < TALISMAN_NUM; i++) {
            Vector3 pos = new Vector3(TALISMAN_START_X + interval * i, TALISMAN_TOP_Y, 0);
            GameObject talisman = Instantiate(talismanPrefab, pos, Quaternion.identity) as GameObject;
        }
        for (int i = 0; i < TALISMAN_NUM; i++) {
            Vector3 pos = new Vector3(TALISMAN_START_X + interval * i, TALISMAN_BOTTOM_Y, 0);
            GameObject talisman = Instantiate(talismanPrefab, pos, Quaternion.identity) as GameObject;
        }
	}

	void Update() {
	    
	}
}

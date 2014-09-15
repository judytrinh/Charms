using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Charms { 
    public enum TalismanType{RED, GREEN, GOLD, BLUE, DIAMOND};
}

public class GameManager : MonoBehaviour {
    // References
    Object talismanPrefab;
    Object obstaclePrefab;

    // Constants
    float TALISMAN_START_X;
    float TALISMAN_END_X;
    float TALISMAN_TOP_Y;
    float TALISMAN_BOTTOM_Y;
    int TALISMAN_NUM;
    Charms.TalismanType[] TALISMAN_SELECTION;

    int health;
    Charms.TalismanType[] onDeckTalisman;

	void Start() {
        talismanPrefab = Resources.Load("Talisman");
        obstaclePrefab = Resources.Load("Obstacle");

        TALISMAN_START_X = -5.0f;
        TALISMAN_END_X = 175.0f;
        TALISMAN_TOP_Y = 5.0f;
        TALISMAN_BOTTOM_Y = -5.0f;
        TALISMAN_NUM = 150;
        Charms.TalismanType[] TALISMAN_SELECTION = {Charms.TalismanType.RED, Charms.TalismanType.GREEN, Charms.TalismanType.GOLD, Charms.TalismanType.BLUE, Charms.TalismanType.DIAMOND};

        health = 100;

        List<Charms.TalismanType> onDeckTalisman = new List<Charms.TalismanType>();
        for (int i = 0; i < 100; i++) {
            int typeIndex = Random.Range(0, TALISMAN_SELECTION.Length - 1);
            onDeckTalisman.Add(TALISMAN_SELECTION[typeIndex]);
        }

        //====================================================================================================
        // Instantiate talisman locations
        //====================================================================================================
        float interval = (TALISMAN_END_X - TALISMAN_START_X) / TALISMAN_NUM;
        for (int i = 0; i < TALISMAN_NUM; i++) {
            Vector3 pos = new Vector3(TALISMAN_START_X + interval * i, TALISMAN_TOP_Y, 0);
            GameObject talisman = Instantiate(talismanPrefab, pos, Quaternion.identity) as GameObject;
            talisman.GetComponent<Talisman>().Create(Charms.TalismanType.RED, true, TALISMAN_TOP_Y, TALISMAN_BOTTOM_Y);
        }
        for (int i = 0; i < TALISMAN_NUM; i++) {
            Vector3 pos = new Vector3(TALISMAN_START_X + interval * i, TALISMAN_BOTTOM_Y, 0);
            GameObject talisman = Instantiate(talismanPrefab, pos, Quaternion.identity) as GameObject;
            talisman.GetComponent<Talisman>().Create(Charms.TalismanType.BLUE, false, TALISMAN_TOP_Y, TALISMAN_BOTTOM_Y);
        }
        //====================================================================================================
        // Instantiate obstacle locations
        //====================================================================================================
        for (int i = 0; i < TALISMAN_NUM / 4; i++) {
            Vector3 pos = new Vector3(TALISMAN_START_X + interval * i * 4, Random.Range(TALISMAN_TOP_Y - 1.5f, TALISMAN_BOTTOM_Y + 1.5f), 0);
            GameObject obstacle = Instantiate(obstaclePrefab, pos, Quaternion.identity) as GameObject;
            float newScale = Random.Range(0.5f, 2.0f);
            obstacle.transform.localScale = new Vector3(newScale, newScale, newScale);
        }
	}

	void Update() {
	    
	}
}

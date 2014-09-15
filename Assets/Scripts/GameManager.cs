using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Charms { 
    public enum TalismanType{RED, GREEN, GOLD, BLUE, DIAMOND};
}

public class GameManager : MonoBehaviour {
    // References
    public GameObject healthText;

    Object talismanPrefab;
    Object obstaclePrefab;

    // Constants
    float TALISMAN_START_X;
    float TALISMAN_END_X;
    float TALISMAN_TOP_Y;
    float TALISMAN_BOTTOM_Y;
    int TALISMAN_NUM;
    int MAX_HEALTH;
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
        MAX_HEALTH = 100;
        Charms.TalismanType[] TALISMAN_SELECTION = {Charms.TalismanType.RED, Charms.TalismanType.GREEN, Charms.TalismanType.GOLD, Charms.TalismanType.BLUE, Charms.TalismanType.DIAMOND};

        health = MAX_HEALTH;

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
            talisman.GetComponent<Talisman>().Create(TALISMAN_SELECTION[Random.Range(0, TALISMAN_SELECTION.Length - 1)], true, TALISMAN_TOP_Y, TALISMAN_BOTTOM_Y);
        }
        for (int i = 0; i < TALISMAN_NUM; i++) {
            Vector3 pos = new Vector3(TALISMAN_START_X + interval * i, TALISMAN_BOTTOM_Y, 0);
            GameObject talisman = Instantiate(talismanPrefab, pos, Quaternion.identity) as GameObject;
                talisman.GetComponent<Talisman>().Create(TALISMAN_SELECTION[Random.Range(0, TALISMAN_SELECTION.Length - 1)], false, TALISMAN_TOP_Y, TALISMAN_BOTTOM_Y);
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

    public void AddHealth(int h) {
        health = (health + h > MAX_HEALTH) ? MAX_HEALTH : health + h;
        Debug.Log(health);
        healthText.GetComponent<GUIText>().text = "Health: " + health;
    }

    public void RemoveHealth(int h) {
        health = (health - h < 0) ? 0 : health - h;
        Debug.Log(health);
        healthText.GetComponent<GUIText>().text = "Health: " + health;
    }

	void Update() {
	    
	}
}

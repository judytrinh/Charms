using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Charms { 
    public enum TalismanType{RED, GREEN, GOLD, BLUE, DIAMOND};
}

public class GameManager : MonoBehaviour {
    // References
    public GameObject youLose;

    public GameObject healthText;
    public GameObject onDeckText;
    public GameObject amountLeft;

    GUIText onDeckGuiText;

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
    List<Charms.TalismanType> onDeckTalisman;
    public int numLeft;

    void Awake() {
        numLeft = 15;
        
        TALISMAN_SELECTION = new Charms.TalismanType[5];
        TALISMAN_SELECTION[0] = Charms.TalismanType.RED;
        TALISMAN_SELECTION[1] = Charms.TalismanType.GREEN;
        TALISMAN_SELECTION[2] = Charms.TalismanType.GOLD;
        TALISMAN_SELECTION[3] = Charms.TalismanType.BLUE;
        TALISMAN_SELECTION[4] = Charms.TalismanType.DIAMOND;

        onDeckTalisman = new List<Charms.TalismanType>();
        for (int i = 0; i < 15; i++) {
            int typeIndex = Random.Range(0, TALISMAN_SELECTION.Length - 1);
            onDeckTalisman.Add(TALISMAN_SELECTION[typeIndex]);
//            Debug.Log(onDeckTalisman[i]);
        }
    }

	void Start() {

        youLose.GetComponent<GUIText>().text = "";
        talismanPrefab = Resources.Load("Talisman");
        obstaclePrefab = Resources.Load("Obstacle");

        onDeckGuiText = onDeckText.GetComponent<GUIText>();

        TALISMAN_START_X = -5.0f;
        TALISMAN_END_X = 175.0f;
        TALISMAN_TOP_Y = 5.0f;
        TALISMAN_BOTTOM_Y = -5.0f;
        TALISMAN_NUM = 150;
        MAX_HEALTH = 200;

        health = MAX_HEALTH;

        //====================================================================================================
        // Instantiate talisman locations
        //====================================================================================================

        float lastXLocation = TALISMAN_START_X;

        float interval = (TALISMAN_END_X - TALISMAN_START_X) / TALISMAN_NUM;
        for (int i = 0; i < TALISMAN_NUM; i++) {
            float realInterval = Random.Range(1.5f, 7.0f);
            float newLoc = lastXLocation + realInterval;
            Vector3 pos = new Vector3(newLoc, TALISMAN_TOP_Y, 0);
            GameObject talisman = Instantiate(talismanPrefab, pos, Quaternion.identity) as GameObject;
            Charms.TalismanType type = TALISMAN_SELECTION[Random.Range(0, TALISMAN_SELECTION.Length - 1)];
            talisman.GetComponent<Talisman>().Create(type, true, TALISMAN_TOP_Y, TALISMAN_BOTTOM_Y);
            talisman.GetComponent<Talisman>().SetType(type);
            lastXLocation = newLoc;
        }
        lastXLocation = TALISMAN_START_X;
        for (int i = 0; i < TALISMAN_NUM; i++) {
            float realInterval = Random.Range(1.5f, 7.0f);
            float newLoc = lastXLocation + realInterval;
            Vector3 pos = new Vector3(newLoc, TALISMAN_BOTTOM_Y, 0);
            GameObject talisman = Instantiate(talismanPrefab, pos, Quaternion.identity) as GameObject;
            Charms.TalismanType type = TALISMAN_SELECTION[Random.Range(0, TALISMAN_SELECTION.Length - 1)];
            talisman.GetComponent<Talisman>().Create(type, false, TALISMAN_TOP_Y, TALISMAN_BOTTOM_Y);
            talisman.GetComponent<Talisman>().SetType(type);
            lastXLocation = newLoc;
        }
        //====================================================================================================
        // Instantiate obstacle locations
        //====================================================================================================
        for (int i = 0; i < 250; i++) {
            Vector3 pos = new Vector3(TALISMAN_START_X + interval * i * 7, Random.Range(TALISMAN_TOP_Y - 1.5f, TALISMAN_BOTTOM_Y + 1.5f), 0);
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

    public Charms.TalismanType GetOnDeckTalisman() {
        return onDeckTalisman[0];
    }

    public void NextTalisman() {
        onDeckTalisman.RemoveAt(0);
        Debug.Log(onDeckTalisman [0]);
        numLeft--;
    }

	void Update() {
        if (health == 0)
            youLose.GetComponent<GUIText>().text = "You Lose";
        
        amountLeft.GetComponent<GUIText>().text = numLeft + " Left!"; 

        Charms.TalismanType type = GetOnDeckTalisman();
        switch (type) {
            case Charms.TalismanType.BLUE:
                onDeckGuiText.text = "BLUE";
                onDeckGuiText.color = Color.blue;
                break;
            case Charms.TalismanType.RED:
                onDeckGuiText.text = "RED";
                onDeckGuiText.color = Color.red;
                break;
            case Charms.TalismanType.DIAMOND:
                onDeckGuiText.text = "DIAMOND";
                onDeckGuiText.color = Color.white;
                break;
            case Charms.TalismanType.GREEN:
                onDeckGuiText.text = "GREEN";
                onDeckGuiText.color = Color.green;
                break;
            case Charms.TalismanType.GOLD:
                onDeckGuiText.text = "GOLD";
                onDeckGuiText.color = Color.yellow;
                break;
            default:
                onDeckGuiText.text = "GOLD";
                onDeckGuiText.color = Color.yellow;
                break;
        };
	}
}

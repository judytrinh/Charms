using UnityEngine;
using System.Collections;

public class Talisman : MonoBehaviour {
    bool atTheTop;
    bool isChangingSides;

    float TALISMAN_TOP_Y;
    float TALISMAN_BOTTOM_Y;
    float SPEED;

	void Start() {
        atTheTop = false;
	}

    //====================================================================================================
    // Used as an initializer later when we want different types of talisman
    // TODO: write enum, include type as param
    //====================================================================================================
    public void Create(bool top, float topY, float bottomY) {
        this.atTheTop = top;
        this.TALISMAN_TOP_Y = topY;
        this.TALISMAN_BOTTOM_Y = bottomY;
        this.SPEED = 0.2f;
    }

    //====================================================================================================
    // Checks if we want to flip sides, if so inc/dec towards a side
    //====================================================================================================
    void FlipOrNot() {
        if (isChangingSides) {
            if (atTheTop) {
                float x = this.transform.position.x;
                float y = this.transform.position.y - SPEED;
                float z = this.transform.position.z;
                this.transform.position = new Vector3(x, y, z);

                if (this.transform.position.y <= TALISMAN_BOTTOM_Y) {
                    this.transform.position = new Vector3(this.transform.position.x, TALISMAN_BOTTOM_Y, this.transform.position.z);
                    isChangingSides = false;
                    atTheTop = false;
                }
            } else {
                float x = this.transform.position.x;
                float y = this.transform.position.y + SPEED;
                float z = this.transform.position.z;
                this.transform.position = new Vector3(x, y, z);

                if (this.transform.position.y >= TALISMAN_TOP_Y) {
                    this.transform.position = new Vector3(this.transform.position.x, TALISMAN_TOP_Y, this.transform.position.z);;
                    isChangingSides = false;
                    atTheTop = true;
                }
            }
        }
    }
	
	void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            isChangingSides = true;
        }

        FlipOrNot();
	}
}

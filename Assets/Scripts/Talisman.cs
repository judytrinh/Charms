using UnityEngine;
using System.Collections;

public class Talisman : MonoBehaviour {
    bool atTheTop;
    bool isChangingSides;

    float TALISMAN_TOP_Y;
    float TALISMAN_BOTTOM_Y;
    float SPEED;

    public Material RED;
    public Material BLUE;
    public Material DIAMOND;
    public Material GREEN;
    public Material GOLD;

    Charms.TalismanType TALISMAN_TYPE;

    public AudioClip jewelSound;
    public AudioSource jSound;

	void Start() {
        atTheTop = false;
	}

    //====================================================================================================
    // Used as an initializer later when we want different types of talisman
    //====================================================================================================
    public void Create(Charms.TalismanType type, bool top, float topY, float bottomY) {
        this.atTheTop = top;
        this.TALISMAN_TOP_Y = topY;
        this.TALISMAN_BOTTOM_Y = bottomY;
        this.SPEED = 0.4f;

        TALISMAN_TYPE = type;

        GameObject taliModel = this.gameObject.transform.GetChild(0).gameObject;
        taliModel.transform.localPosition = new Vector3(1f, -1f, 0);

        switch (type) {
            case Charms.TalismanType.BLUE:
                taliModel.renderer.material = BLUE;
                break;
            case Charms.TalismanType.RED:
                taliModel.renderer.material = RED;
                break;
            case Charms.TalismanType.DIAMOND:
                taliModel.renderer.material= DIAMOND;
                break;
            case Charms.TalismanType.GREEN:
                taliModel.renderer.material = GREEN;
                break;
            case Charms.TalismanType.GOLD:
                taliModel.renderer.material = GOLD;
                break;
            default:
                taliModel.renderer.material = GOLD;
                break;
        };
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
	
    public Charms.TalismanType GetTalismanType() {
        return TALISMAN_TYPE;
    }

    public void SetType(Charms.TalismanType t) {
        TALISMAN_TYPE = t;
    }

    void OnDestory() {
        audio.Play();
    }

	void Update() {
//        GameObject taliModel = this.gameObject.transform.GetChild(0).gameObject;
        gameObject.transform.Rotate(new Vector3(0, 5.0f, 0));

        if (Input.GetKey(KeyCode.Space)) {
            isChangingSides = true;
        }

        FlipOrNot();
	}
}

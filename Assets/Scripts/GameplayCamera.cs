using UnityEngine;
using System.Collections;

public class GameplayCamera : MonoBehaviour {

    public GameObject cameraContainer;
    public Transform target;

    bool isShaking;
    bool up;

    void Start() {
        isShaking = false;
        up = true;
    }

    void ShakeTranslate() {
        if (up) {
            float y = this.gameObject.transform.position.y + 0.18f;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, y, this.gameObject.transform.position.z);
        } else {
            float y = this.gameObject.transform.position.y - 0.18f;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, y, this.gameObject.transform.position.z);
        }
    }

    void ToggleDir() {
        if (!isShaking) return;
        up = !up;
        Invoke("ToggleDir", 0.07f);
    }

    void StopShake() {
        isShaking = false;
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z);
    }

    public void ShakeMe(float s) {
        isShaking = true;
        up = true;

        Invoke("ToggleDir", 0.03f);
        Invoke("StopShake", s);
    }

	void Update() {
        float x = target.position.x;

        if (isShaking) ShakeTranslate();

        cameraContainer.transform.position = new Vector3(x, 0, -10.0f);
	}
}
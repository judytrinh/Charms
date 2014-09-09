using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
    Vector3 SPEED;

    void Start() {
        SPEED = new Vector3(0.1f, 0.1f, 0);
    }

    void Update() {

        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(new Vector3(0, SPEED.y, 0));
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(new Vector3(0, -SPEED.y, 0));
        }

        transform.Translate(new Vector3(SPEED.x, 0, 0));
    }
}
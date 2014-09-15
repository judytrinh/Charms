using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
    public GameObject gameManager;

    Vector3 SPEED;

    void Start() {
        SPEED = new Vector3(0.1f, 0.1f, 0);

        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }

    void OnCollisionEnter(Collision c) {
        if (c.gameObject.tag == "Talisman") {
            gameManager.GetComponent<GameManager>().AddHealth(10);
        }
        if (c.gameObject.tag == "Obstacle") {
            Debug.Log("COLLIDED WITH OBSTACLES");
            gameManager.GetComponent<GameManager>().RemoveHealth(20);
        }
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
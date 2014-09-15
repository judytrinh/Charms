using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
    public GameObject gameManager;

    Vector3 SPEED;

    void Start() {

        SPEED = new Vector3(0.18f, 0.15f, 0);

        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }

    void OnCollisionEnter(Collision c) {
        if (c.gameObject.tag == "Talisman") {
            Debug.Log("color of collided: " + c.gameObject.GetComponent<Talisman>().GetTalismanType());
            Debug.Log("color of on deck: " + gameManager.GetComponent<GameManager>().GetOnDeckTalisman());
            if (c.gameObject.GetComponent<Talisman>().GetTalismanType() == gameManager.GetComponent<GameManager>().GetOnDeckTalisman()) {
                Debug.Log(gameManager.GetComponent<GameManager>().GetOnDeckTalisman());
                gameManager.GetComponent<GameManager>().AddHealth(10);
                gameManager.GetComponent<GameManager>().NextTalisman();
            } else {
                gameManager.GetComponent<GameManager>().RemoveHealth(10);
            }
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == "Obstacle") {
            Debug.Log("COLLIDED WITH OBSTACLES");
            gameManager.GetComponent<GameManager>().RemoveHealth(20);
            Destroy(c.gameObject);
        }
    }

    void Update() {

        if (Input.GetKey(KeyCode.UpArrow)) {
            
            if (transform.position.y + SPEED.y > 3.45f) 
                transform.position = new Vector3(transform.position.x, 3.45f, transform.position.z);
            else
                transform.Translate(new Vector3(0, SPEED.y, 0), Space.World);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            if (transform.position.y - SPEED.y < -3.45f) 
                transform.position = new Vector3(transform.position.x, -3.45f, transform.position.z);
            else
                transform.Translate(new Vector3(0, -SPEED.y, 0), Space.World);
        }

        transform.Translate(new Vector3(SPEED.x, 0, 0), Space.World);
    }
}
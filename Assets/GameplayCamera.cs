using UnityEngine;
using System.Collections;

public class GameplayCamera : MonoBehaviour {

    public Transform target;

	void Start() {
	
	}

	void Update() {
        float x = target.transform.position.x;
        float y = target.transform.position.y;

        this.transform.position = new Vector3(x, y, this.transform.position.z);
	}
}
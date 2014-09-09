using UnityEngine;
using System.Collections;

public class GameplayCamera : MonoBehaviour {

    public Transform target;

	void Start() {
	
	}

	void Update() {
        float x = target.transform.position.x;

        this.transform.position = new Vector3(x, 0, this.transform.position.z);
	}
}
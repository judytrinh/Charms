using UnityEngine;
using System.Collections;

public class Talisman : MonoBehaviour {
    bool top;

	void Start() {
        top = false;
	}

    // Used as an initializer later when we want different types of talisman
    // TODO: write enum, include type as param
    public void Create(Vector3 pos, bool top) {
        transform.position = pos;
        this.top = top;
    }
	
	void Update() {
	    
	}
}

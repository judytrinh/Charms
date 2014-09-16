using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	void Start () {

        // Load 3d model and instantiate as a game object
        Object asterModel = Resources.Load("3D models/asteroid" + Random.Range(1,30));
        Vector3 asterPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.5f, this.gameObject.transform.position.z);
        GameObject asteroid = Instantiate(asterModel, asterPos, Quaternion.identity) as GameObject;

        // Scale it
        float randScale = Random.Range(0.01f, 0.05f);
        asteroid.transform.localScale = new Vector3(randScale, randScale, randScale);
        
        // Add collider
        GameObject asterChild = asteroid.transform.GetChild(0).gameObject;
        asterChild.AddComponent("MeshCollider");

        asteroid.transform.parent = this.gameObject.transform;
        asterChild.tag = "Obstacle";
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}

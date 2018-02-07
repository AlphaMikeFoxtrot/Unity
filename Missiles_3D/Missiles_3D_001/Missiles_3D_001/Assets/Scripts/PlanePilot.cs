using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePilot : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {

		Debug.Log ("script added to : " + transform.name);

	}
	
	// Update is called once per frame
	void Update () {

		transform.position += transform.forward * Time.deltaTime * speed;

		speed -= transform.forward.y * Time.deltaTime * 50.0f;

		if (speed < 35.00f) {
			speed = 35.00f;
		}

		if (Input.GetKey ("space")) {
		
			speed -= 10 * Time.deltaTime;
		
		} else {
		
			// speed = 100f;
		
		}

		transform.Rotate (Input.GetAxis ("Vertical") * 1.5f, 0.0f, -Input.GetAxis ("Horizontal") * 1.5f);

		float bottomTerrain = Terrain.activeTerrain.SampleHeight (transform.position);
		if (bottomTerrain - 10 > transform.position.y) {
		
			transform.position = new Vector3 (transform.position.x, bottomTerrain, transform.position.z);
		
		}

	}
}

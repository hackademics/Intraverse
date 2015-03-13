using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Rocket : MonoBehaviour {




	void FixedUpdate(){
	
		if (transform.position.y <= -10.0f) {
			Destroy(gameObject);
		}
	}


}
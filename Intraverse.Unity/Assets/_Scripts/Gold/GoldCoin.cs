using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class GoldCoin : MonoBehaviour {

	private int hits = 0;
	private bool isRotating = false;
	private float rotateSpeed = 2.0f;
	private Rigidbody rb;

	void FixedUpdate(){

		rb = GetComponent<Rigidbody> ();
		if (isRotating) {
			transform.Rotate (Vector3.up * (Time.deltaTime + rotateSpeed));
		}
	}

	void OnCollisionEnter(Collision c) {

		//shoot to shrink
		if (c.collider.gameObject.name == "ball") {

			Destroy(c.collider.gameObject);

			if (hits == 0) {
				isRotating = true;
				rotateSpeed = 5.0f;
				//transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
				rb.transform.position = new Vector3 (rb.transform.position.x, rb.transform.position.y - .7f, rb.transform.position.z);
				hits++;
			}
			else if(hits == 1){
				rotateSpeed = 10.0f;
				rb.transform.position = new Vector3 (rb.transform.position.x, rb.transform.position.y - .5f, rb.transform.position.z);
				hits++;
			}

		}

		//pick up
		if (hits > 1 && c.collider.gameObject.name == "UserView") {
			Destroy (gameObject);
			ScoreController.GoldScore++;
		}


		
	}
}

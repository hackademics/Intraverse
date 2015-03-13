using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject RocketPrefab;
	public float Force = 5000.0f;

	void Update () {
		if (Input.GetMouseButtonDown(0)) {

			GameObject g = (GameObject)Instantiate(RocketPrefab, transform.position, transform.parent.rotation);
			g.name = "ball";

			g.GetComponent<Rigidbody>().AddForce(g.transform.forward * Force);

			Destroy(g, 5.0f);
		}
	}
}

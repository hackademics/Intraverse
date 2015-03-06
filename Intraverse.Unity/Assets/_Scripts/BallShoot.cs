using UnityEngine;
using System.Collections;

public class BallShoot : MonoBehaviour {

	public Rigidbody Projectile;
	public Transform BallTransform;
	public float BallForce = 1000.0f;
	public float BallSpeed = 10.0f;
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonUp ("Fire1")) {
			var b = Instantiate(Projectile, BallTransform.position, Quaternion.identity) as Rigidbody;
			b.AddForce(BallTransform.forward * BallForce);
			Destroy(b.gameObject, 3);
		}
	}
}

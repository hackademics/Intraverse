using UnityEngine;
using System.Collections;
using System.Collections.Specialized;

public class Turret : MonoBehaviour {

	private GameObject ChaseTarget;
	public float ChaseSpeed = 5.0f;
	public float SpeedIncreaseOnKill = 1.0f;

	void Start (){
		ChaseTarget = GameObject.Find ("UserView");
	}

	void FixedUpdate () {

		transform.LookAt (ChaseTarget.transform);

		float step = ChaseSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, ChaseTarget.transform.position, step);

	}

	public void Spawn(){
		transform.position = new Vector3 (Random.Range (-200.0F, 200.0F), 3, Random.Range (-200.0F, 200.0F));
	}

	void OnCollisionEnter(Collision c) {

		if (c.collider.gameObject.name == "ball") {
			ScoreController.KillScore++;
			ChaseSpeed += SpeedIncreaseOnKill;
			Spawn ();

		} else if (c.collider.gameObject.name == "UserView") {
			ScoreController.HealthScore = ScoreController.HealthScore - 10;
			Spawn ();
		}
	}
}

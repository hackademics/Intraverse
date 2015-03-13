using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject GoldPrefab;
	public int GoldPrefabCount = 20;

	public GameObject TurretPrefab;
	public int TurretPrefabCount = 2;

	
	void Start(){

		for (var i = 0; i < GoldPrefabCount; i++) {
			var pos = new Vector3(Random.Range(-250.0F,250.0F), .5f, Random.Range(-250.0F, 250.0F));
			Instantiate(GoldPrefab, pos, Quaternion.identity);
		}

		for (var i = 0; i < TurretPrefabCount; i++) {
			var pos = new Vector3(Random.Range(-250.0F,250.0F), 5, Random.Range(-250.0F, 250.0F));
			Instantiate(TurretPrefab, pos, Quaternion.identity);
		}
	}

	void FixedUpdate(){

		if (ScoreController.HealthScore <= 0) {
			Debug.Log("you dead");
		}
	}
}

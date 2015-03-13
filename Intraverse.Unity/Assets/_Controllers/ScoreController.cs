using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {


	private Text GoldText;
	public static int GoldScore;

	private Text KillText;
	public static int KillScore;

	private Text HealthText;
	public static int HealthScore;


	void Start () {

		GoldText = GameObject.Find("GoldText").GetComponent<Text> ();
		GoldScore = 0; 

		KillText = GameObject.Find("KillText").GetComponent<Text> ();
		KillScore = 0;

		HealthText = GameObject.Find("HealthText").GetComponent<Text> ();
		HealthScore = 100;
	}

	void Awake(){
		GoldScore = 0; 
		KillScore = 0;
		HealthScore = 100;
	}

	void FixedUpdate () {

		GoldText.text = "GOLD : " + GoldScore;
		KillText.text = "KILLS : " + KillScore;
		HealthText.text = "HEALTH : " + HealthScore + "%";
	}
}

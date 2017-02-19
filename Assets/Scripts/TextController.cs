using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
	[SerializeField] Text timerText;
	[SerializeField] Text PtText;
	[SerializeField] Text bulletBoxText;
	[SerializeField] Text bulletText;
	double time = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		timerText.text = "Time:" + (int)(120 - time);
		PtText.text = "Pt:" + ScoreController.score;
		bulletBoxText.text = "BulletBox:" + GunController.bulletBoxCount + "/150";
		bulletText.text = "Bullet:" + GunController.bulletCount + "/30";
	}
}

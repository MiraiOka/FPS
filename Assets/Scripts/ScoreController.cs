using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
	public static int score = 0;
	[SerializeField] GameObject headMarker;
	[SerializeField] GameObject pCube1;
	[SerializeField] GameObject pCylinder1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GunController.isHit && Target.isStand) {
			if (GunController.hit.collider.gameObject.tag == "target") {
				if (GunController.hit.collider.gameObject == headMarker) {
					score += 100;
				} else if (GunController.hit.collider.gameObject == pCube1) {
					score += 50;
				} else if (GunController.hit.collider.gameObject == pCylinder1) {
					score += 20;
				}
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
	int targetLife = 5;
	Animator anim;
	public static bool isStand = true;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GunController.isHit) {
			HitTarget ();
		}

		if (targetLife <= 0 && !(anim.GetBool("broken"))) {
			anim.SetBool ("broken", true);
			isStand = false;
			StartCoroutine ("StandTarget");
		}
	}

	IEnumerator StandTarget(){
		yield return new WaitForSeconds(10.0f);
		targetLife = 5;
		anim.SetBool ("broken", false);
		isStand = true;
	}

	void HitTarget(){
		targetLife--;
		GunController.isHit = false;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	float bulletInterval = 0.0f;
	public Camera camera;
	int bulletCount = 30;
	int bulletBoxCount = 150;
	public GameObject gunEffect;
	AudioSource audioBullet;
	public AudioClip audioBulletClip;
	AudioSource audioReload;
	public AudioClip audioReloadClip;
	bool isRoad;
	// Use this for initialization
	void Start () {
		audioBullet = GetComponent<AudioSource> ();
		audioReload = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		bulletInterval += Time.deltaTime;

		if(Input.GetMouseButton(0) && bulletInterval > 0.1f && bulletCount > 0 && !(isRoad)){
			GenerateBullet ();
		}

		if (Input.GetKey (KeyCode.R) && bulletCount < 30 && bulletBoxCount > 0) {
			StartCoroutine ("Reload");
		}

	}

	void GenerateBullet(){
		bulletCount--;
		Ray ray = new Ray(camera.transform.position, camera.transform.forward);
		audioBullet.PlayOneShot (audioBulletClip);
		RaycastHit hit = new RaycastHit();
		Instantiate (gunEffect, transform.position + ray.direction * 0.9f + new Vector3(0,0.1f,0), Quaternion.identity);
		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
			Instantiate (gunEffect, hit.point - ray.direction, Quaternion.identity);
		}
		bulletInterval = 0.0f;
	}

	IEnumerator Reload(){
		int addBullet = (30 - bulletCount);//増やす予定の弾数
		if (bulletBoxCount < addBullet) {
			bulletCount += bulletBoxCount;
			bulletBoxCount = 0;
		} else {
			bulletCount = 30;
			bulletBoxCount -= addBullet;
		}
		audioBullet.PlayOneShot (audioReloadClip);
		isRoad = true;
		yield return new WaitForSeconds (2.5f);
		isRoad = false;
	}

}
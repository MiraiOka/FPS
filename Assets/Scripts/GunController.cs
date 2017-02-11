using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	float bulletInterval = 0.0f;
	GameObject bulletObj;
	public Camera camera;
	AudioSource audioBullet;
	// Use this for initialization
	void Start () {
		audioBullet = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		bulletInterval += Time.deltaTime;
		if(Input.GetMouseButton(0) && bulletInterval > 0.1f){
			GenerateBullet ();

		}


	}

	void GenerateBullet(){
		Ray ray = new Ray(camera.transform.position, camera.transform.forward);
		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
			bulletObj = Resources.Load<GameObject> ("Effects/BulletEffect");
			Instantiate (bulletObj, hit.point - ray.direction, Quaternion.identity);
			audioBullet.Play ();
		}
		bulletInterval = 0.0f;
	}
}

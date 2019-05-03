using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comic : MonoBehaviour {

	public GameObject nosePrefab, earPrefab;
	GameObject nose, ear;
	public Vector3 nosePosition = new Vector3(0,0.5f,-0.5f);
	public Vector3 earPosition = new Vector3(0,0.23f,0);
	public bool NE;

	bool comicBoolSaved;
	
	void Start() {
		NE = (Random.value > 0.5f);
		if(NE) {
			nose = Instantiate(nosePrefab, new Vector3(0,0,0), Quaternion.identity, gameObject.transform);
			nose.transform.localPosition = nosePosition;
		} else {
			ear = Instantiate(earPrefab, new Vector3(0,0,0), Quaternion.identity, gameObject.transform);
			ear.transform.localPosition = earPosition;
			ear.transform.localRotation = Quaternion.Euler(0,150,0);
		}

		if(Values.comic) {
			if(nose != null) nose.SetActive(true);
			if(ear != null) ear.SetActive(true);
		} else {
			if(nose != null) nose.SetActive(false);
			if(ear != null) ear.SetActive(false);
		}
		comicBoolSaved = Values.comic;
	}

	void Update() {
		if(comicBoolSaved != Values.comic) {
			if(Values.comic) {
				if(nose != null) nose.SetActive(true);
				if(ear != null) ear.SetActive(true);
			} else {
				if(nose != null) nose.SetActive(false);
				if(ear != null) ear.SetActive(false);
			}
			comicBoolSaved = Values.comic;
		}
	}
}

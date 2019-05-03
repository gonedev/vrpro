using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkersManager : MonoBehaviour {

	GameObject[] markers;
	public bool tipsSaved = false;

	void Start () {
		markers = new GameObject[gameObject.transform.childCount];
		for(int i = 0; i < gameObject.transform.childCount; i++) {
			markers[i] = gameObject.transform.GetChild(i).gameObject;
		}
	}
	
	void Update () {
		if(Values.tips != tipsSaved) {
			if(Values.tips) {
				for(int i = 0; i < markers.Length; i++){
					markers[i].SetActive(true);
				}
			} else {
				for(int i = 0; i < markers.Length; i++){
					markers[i].SetActive(false);
				}
			}
			tipsSaved = Values.tips;
		}
	}
}

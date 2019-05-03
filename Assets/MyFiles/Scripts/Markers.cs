using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Markers : MonoBehaviour {

	public float rotValue = 90;
	public float speed = 4;
	public float height = 0.15f;
	Vector3 pos;

	void Start () {
		pos = gameObject.transform.position;
	}

	void Update () {
		gameObject.transform.Rotate(Vector3.right*rotValue*Time.deltaTime);
        float newY = Mathf.Sin(Time.time * speed);
        gameObject.transform.position = new Vector3(pos.x, pos.y + (newY * height), pos.z);
	}
}

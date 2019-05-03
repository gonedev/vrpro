using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movers : MonoBehaviour {

	GameObject[] xm;
	public GameObject xmInstance;
	Transform holder;

	public float perp = 0.8f, diag = 0.65f;
	public float switchHeight = 1.5f;

	bool moversBool = true;
	bool moversBoolSaved = true;
	
	void Start () {
		holder = gameObject.transform;
		Init();
	}

	void Init() {
		xm = new GameObject[8];

		for(int i = 0; i < 8; i++){
			xm[i] = Instantiate(xmInstance, holder) as GameObject;
		}

		xm[0].gameObject.name = "x0zm";
		xm[1].gameObject.name = "x0zp";
		xm[2].gameObject.name = "xmz0";
		xm[3].gameObject.name = "xpz0";
		xm[4].gameObject.name = "xmzm";
		xm[5].gameObject.name = "xmzp";
		xm[6].gameObject.name = "xpzm";
		xm[7].gameObject.name = "xpzp";

		xm[0].transform.localPosition = new Vector3(0,0,-1) * perp;
		xm[1].transform.localPosition = new Vector3(0,0,1) * perp;
		xm[2].transform.localPosition = new Vector3(-1,0,0) * perp;
		xm[3].transform.localPosition = new Vector3(1,0,0) * perp;
		xm[4].transform.localPosition = new Vector3(-1,0,-1) * diag;
		xm[5].transform.localPosition = new Vector3(-1,0,1) * diag;
		xm[6].transform.localPosition = new Vector3(1,0,-1) * diag;
		xm[7].transform.localPosition = new Vector3(1,0,1) * diag;

		xm[0].transform.rotation = Quaternion.Euler(new Vector3(90,0,0));
		xm[1].transform.rotation = Quaternion.Euler(new Vector3(90,0,0));
		xm[2].transform.rotation = Quaternion.Euler(new Vector3(90,-90,0));
		xm[3].transform.rotation = Quaternion.Euler(new Vector3(90,-90,0));
		xm[4].transform.rotation = Quaternion.Euler(new Vector3(90,45,0));
		xm[5].transform.rotation = Quaternion.Euler(new Vector3(90,-45,0));
		xm[6].transform.rotation = Quaternion.Euler(new Vector3(90,-45,0));
		xm[7].transform.rotation = Quaternion.Euler(new Vector3(90,45,0));
	}

	public void SetMovers(bool movers) {
		moversBool = movers;
	}

	void Update () {
		if(moversBool != moversBoolSaved) {
			if(moversBool) {
				CreateMovers();
			} else {
				DestroyMovers();
			}
			moversBoolSaved = moversBool;
		}
	}

	public void DestroyMovers() {
		for(int i = 0; i < 8; i++){
			if(xm[i] != null) Destroy(xm[i]);
		}
	}

	public void CreateMovers() {
		if(xm[0] == null) Init();
	}
}

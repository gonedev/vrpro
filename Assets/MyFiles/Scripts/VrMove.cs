using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrMove : MonoBehaviour {

	public float movementSpeed = 2.5f;
	public bool move = false;
	public string dir = null;

	public CharacterController cc;

	void Start () {
		cc = GetComponent<CharacterController>();
	}

	void Update () {
		if(dir != null && move){
			if(dir == "x0zm"){
				cc.SimpleMove(new Vector3(0,0,-1) * movementSpeed);
			}
			if(dir == "x0zp"){
				cc.SimpleMove(new Vector3(0,0,1) * movementSpeed);
			}
			if(dir == "xmz0"){
				cc.SimpleMove(new Vector3(-1,0,0) * movementSpeed);
			}
			if(dir == "xpz0"){
				cc.SimpleMove(new Vector3(1,0,0) * movementSpeed);
			}
			if(dir == "xmzm"){
				cc.SimpleMove(new Vector3(-1,0,-1) * movementSpeed);
			}
			if(dir == "xmzp"){
				cc.SimpleMove(new Vector3(-1,0,1) * movementSpeed);
			}
			if(dir == "xpzm"){
				cc.SimpleMove(new Vector3(1,0,-1) * movementSpeed);
			}
			if(dir == "xpzp"){
				cc.SimpleMove(new Vector3(1,0,1) * movementSpeed);
			}
		}
	}

	public void Move (GameObject go){
		move = true;
		dir = go.gameObject.name;
	}

	public void Stop (){
		move = false;
	}
}

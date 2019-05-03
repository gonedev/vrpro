using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

	public float doorOpenTime = 1f;
	public float doorCloseTime = 1f;
	float doorOpenTick;
	float doorCloseTick;
	public string state = "close";
	
	public float doorReload = 5f;

	void Start () {
		doorOpenTick = doorOpenTime/90;
		doorCloseTick = doorCloseTime/90;
	}
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "XM" && state == "close"){
			StartCoroutine("OpenDoorCor");
		}
	}

	void Update() {
		if(state == "open") {
			StartCoroutine("Wait");
		}
		if(state == "closing") {
			StartCoroutine("CloseDoorCor");
		}
	}

	IEnumerator OpenDoorCor(){
		state = "opening";
		for(float f = 0; f < 90; f+= 1){
			gameObject.transform.localRotation = Quaternion.Euler(-90, -f, 180);
			yield return new WaitForSeconds(doorOpenTick);
		}
		state = "open";
	}

	IEnumerator Wait() {
		state = "waiting";
		yield return new WaitForSeconds(doorReload);
		state = "closing";
	}

	IEnumerator CloseDoorCor(){
		for(float f = 0; f < 90; f+= 1){
			gameObject.transform.localRotation = Quaternion.Euler(-90, f-90, 180);
			yield return new WaitForSeconds(doorCloseTick);
		}
		state = "close";
	}
}

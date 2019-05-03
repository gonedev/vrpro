using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour {

	GameObject[] humans;
	GameObject humansHolder;
	public int humanCount;
	public string state = "sitting";

	void Start () {
		humansHolder = GameObject.Find("Humans");
		humanCount = humansHolder.transform.childCount;
		humans = new GameObject[humanCount];

		for(int i = 0; i < humanCount; i++){
			humans[i] = humansHolder.transform.GetChild(i).gameObject;
		}	
	}
	
	void Update () {
		if(state == "clapped"){
			for(int i = 0; i < humanCount; i++){
				humans[i].GetComponent<Animator>().Play("Sitting");
				state = "sitting";
				Vector3 humanPos = humans[i].transform.localPosition;
				humans[i].transform.localPosition = new Vector3(humanPos.x, humanPos.y - 0.192f, humanPos.z + 0.64f);
			}
		}
	}

	public void MakeClap() {
		if(state == "sitting"){
			for(int i = 0; i < humanCount; i++){
				humans[i].GetComponent<Animator>().Play("Clapping");
				Vector3 humanPos = humans[i].transform.localPosition;
				humans[i].transform.localPosition = new Vector3(humanPos.x, humanPos.y + 0.192f, humanPos.z - 0.64f);
				state = "clapping";
				StartCoroutine("Wait");
			}
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(5);
		state = "clapped";
	}
}

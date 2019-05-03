using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour {

	public Texture[] slides;
	public int slide = 0;

	Material mat;
	Material slidesMiniMat;

	int slideCount;
	bool slideBool = false;
	bool slideChanged = true;

	public string state = "ready";

	void Start () {
		if(slides != null) slideBool = true;
		slideCount = slides.Length;
		slidesMiniMat = GameObject.Find("SlidesMini").GetComponent<Renderer>().material;
		mat = gameObject.GetComponent<Renderer>().material;
	}

	void Update () {
		if(slideChanged) {
			mat.mainTexture = slides[slide];
			slidesMiniMat.mainTexture = slides[slide];
			slideChanged = false;
			state = "waiting";
			StartCoroutine("Wait");
		}
	}

	public void Next () {
		if(state == "ready"){
			slide = slide + 1;
			if (slide > slideCount){
				slide = 0;
			}
			slideChanged = true;
		}
	}

	public void Prev () {
		if(state == "ready"){
			slide = slide - 1;
			if (slide < 0){
				slide = slideCount;
			}
			slideChanged = true;
		}
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds(3);
		state = "ready";
	}
}

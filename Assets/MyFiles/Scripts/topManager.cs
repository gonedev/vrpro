using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topManager : MonoBehaviour {
	
	Material mat;
	float colorTransitionTime = 1.0f;
	Tops tops;

	public Color initial;
	public Color final;
	public Color dc;

	string name;

	void Start(){
		tops = GameObject.Find("Top").GetComponent<Tops>();
		mat = gameObject.GetComponent<Renderer>().material;
		name = gameObject.name;
		initial = mat.color;
		final = new Color(1, 1, 1, 0.8f);
	}

	void Update(){
		ChangeColor(mat.color, final);
	}

	void ChangeColor(Color init, Color fin) {
		Vector3 v3init = new Vector3(init.r, init.g, init.b);

		Vector3 v3final = new Vector3(fin.r, fin.g, fin.b);

		if((v3final - v3init).magnitude < 0.1f){
			StopCoroutine("CycleColors");
			tops.Pressed(gameObject);
		}
	}

	public void topPointerEnter(){
		StartCoroutine("CycleColors");
	}

	public void topPointerExit(){
		mat.color = initial;
		StopCoroutine("CycleColors");
	}

	IEnumerator CycleColors() {
 
		Vector3 previousColor = new Vector3(initial.r,
										    initial.g, 
										    initial.b);
		
		Vector3 currentColor = previousColor;

		while(true) {
			Vector3 newColor = new Vector3(final.r,
										   final.g, 
										   final.b);

			Vector3 deltaColor = (newColor - previousColor) * (1.0f / colorTransitionTime);

			while(true) {
				currentColor = currentColor + deltaColor * Time.deltaTime;
				mat.color = new Color(currentColor.x,
									  currentColor.y, 
									  currentColor.z,
									  0.8f);

				dc = mat.color;

				yield return null;
			}

			previousColor = newColor;
		}
	}
}

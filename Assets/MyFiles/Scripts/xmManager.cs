using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xmManager : MonoBehaviour {
	
	public Color blueTrans = new Color(0,0,1,0.3f);
	public Color redTrans = new Color(1,0,0,0.8f);
	Material environmentMaterial;
	float colorTransitionTime = 1.0f;
	VrMove vrMove;

	void Start(){
		environmentMaterial = gameObject.GetComponent<Renderer>().material;
		vrMove = GameObject.Find("Player").GetComponent<VrMove>();
	}

	void Update(){
		Vector3 envColor = new Vector3(environmentMaterial.color.r,
									   environmentMaterial.color.g,
									   environmentMaterial.color.b);

		Vector3 newColor = new Vector3(redTrans.r,
									   redTrans.g,
									   redTrans.b);

		if((envColor - newColor).magnitude < 0.1f){
			StopCoroutine("CycleColors");
			vrMove.Move(gameObject);
		}
	}

	public void xmPointerEnter(){
		StartCoroutine("CycleColors");
	}

	public void xmPointerExit(){
		environmentMaterial.color = blueTrans;
		StopCoroutine("CycleColors");
		vrMove.Stop();
	}

	IEnumerator CycleColors() {
 
		Vector3 previousColor = new Vector3(blueTrans.r,
										    blueTrans.g, 
										    blueTrans.b);
		
		Vector3 currentColor = previousColor;

		while(true) {
			Vector3 newColor = new Vector3(redTrans.r,
										   redTrans.g, 
										   redTrans.b);

			Vector3 deltaColor = (newColor - previousColor) * (1.0f / colorTransitionTime);

			while(true) {
				currentColor = currentColor + deltaColor * Time.deltaTime;
				environmentMaterial.color = new Color(currentColor.x,
												      currentColor.y, 
												      currentColor.z,
												      0.8f);

				yield return null;
			}

			previousColor = newColor;
		}
	}
}

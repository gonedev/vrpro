using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tops : MonoBehaviour {

	GameObject settingsAll, moversAll,
			   lightsAll, heightAll,
			   comicAll, UIAll,
			   tipsAll;

	TextMesh settingsText, moversText,
			 lightsText, heightText,
			 comicText, UIText,
			 tipsText;


	GameObject settingsOn, settingsOff,
			   moversOn, moversOff,
			   lightsOn, lightsOff,
			   heightOn, heightOff,
			   comicOn, comicOff,
			   UIOn, UIOff,
			   tipsOn, tipsOff;

	bool settingsSaved = false,
	     moversSaved = true,
	     lightsSaved = false,
	     heightSaved = false,
	     comicSaved = false,
	     UISaved = false,
	     tipsSaved = false;

	Movers moversComponent;
	GameObject lightsHolder;
	Camera mainCamera;
	GameObject player;

	public GameObject toggler;
	HumanManager humanManager;
	SlideManager slideManager;
	GameObject holder;
	GameObject otherSettings;

	void Start () {
		holder = GameObject.Find("Top");
		otherSettings = GameObject.Find("Other");
		
		moversComponent = GameObject.Find("XZ").GetComponent<Movers>();

		humanManager = GameObject.Find("Humans").GetComponent<HumanManager>();
		slideManager = GameObject.Find("Slides").GetComponent<SlideManager>();
		
		lightsHolder = GameObject.Find("Lights");
		for(int i = 0; i < lightsHolder.transform.childCount; i++){
			lightsHolder.transform.GetChild(i).gameObject.SetActive(false);
		}
		
		player = GameObject.Find("Player");

		settingsAll = Instantiate(toggler, new Vector3(0,0,0), 
			Quaternion.Euler(-135, 0, 0), holder.transform) as GameObject;

		settingsAll.transform.localPosition = new Vector3(0, 1.5f, 0.3f);
		settingsAll.name = "Settings";

		settingsText = settingsAll.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>();
		settingsText.text = "Баптамалар";
	}

	void Update() {
		if(Values.settings != settingsSaved) {
			if(Values.settings){
				Init();
			} else {
				DestroyAll();
			}
			settingsSaved = Values.settings;
		}

		if(Values.movers != moversSaved) {
			if(Values.movers){
				moversComponent.SetMovers(true);
			} else {
				moversComponent.SetMovers(false);
			}
			moversSaved = Values.movers;
		}

		if(Values.lights != lightsSaved) {
			if(Values.lights){
				for(int i = 0; i < lightsHolder.transform.childCount; i++){
					lightsHolder.transform.GetChild(i).gameObject.SetActive(true);
				}
			} else {
				for(int i = 0; i < lightsHolder.transform.childCount; i++){
					lightsHolder.transform.GetChild(i).gameObject.SetActive(false);
				}
			}
			lightsSaved = Values.lights;
		}

		if(Values.height != heightSaved) {
			if(Values.height){
				Vector3 playerpos = player.transform.localPosition;
				//player.transform.localScale = new Vector3(1,1.5f,1);
				player.transform.localPosition = new Vector3(playerpos.x,playerpos.y + 1.35f,playerpos.z);
				player.GetComponent<CharacterController>().height = 4.85f;
				//Vector3 mcpos = mainCamera.transform.localPosition;
				//mainCamera.transform.localScale = new Vector3(1,1.5f,1);
				//mainCamera.transform.localPosition = new Vector3(mcpos.x,1.4f,mcpos.z);
			} else {
				Vector3 playerpos = player.transform.localPosition;
				//player.transform.localScale = new Vector3(1,1,1);
				player.transform.localPosition = new Vector3(playerpos.x,playerpos.y - 1.35f,playerpos.z);
				player.GetComponent<CharacterController>().height = 2.15f;
				//Vector3 mcpos = mainCamera.transform.localPosition;
				//mainCamera.transform.localScale = new Vector3(1,1,1);
				//mainCamera.transform.localScale = new Vector3(mcpos.x,0.9f,mcpos.z);
			}
			heightSaved = Values.height;
		}

		if(Values.comic != comicSaved) {
			if(Values.comic){
				
			} else {
				
			}
			comicSaved = Values.comic;
		}

		if(Values.UI != UISaved) {
			if(Values.UI){
				
			} else {
				
			}
			UISaved = Values.UI;
		}

		if(Values.tips != tipsSaved) {
			if(Values.tips){
				
			} else {
				
			}
			tipsSaved = Values.tips;
		}
	}

	void Init() {
		// 1
		moversAll = Instantiate(toggler, new Vector3(0,0,0), 
			Quaternion.Euler(-125, -15, 0), otherSettings.transform) as GameObject;

		moversAll.transform.localPosition = new Vector3(-0.4f, 0.6f, 0.51f);
		
		// 2
		lightsAll = Instantiate(toggler, new Vector3(0,0,0), 
			Quaternion.Euler(-125, 0, 0), otherSettings.transform) as GameObject;
		
		lightsAll.transform.localPosition = new Vector3(0,0.6f, 0.55f);

		// 3
		heightAll = Instantiate(toggler, new Vector3(0,0,0), 
			Quaternion.Euler(-125, 15, 0), otherSettings.transform) as GameObject;

		heightAll.transform.localPosition = new Vector3(0.4f, 0.6f, 0.51f);

		// 4
		comicAll = Instantiate(toggler, new Vector3(0,0,0), 
			Quaternion.Euler(-120, -10, -10), otherSettings.transform) as GameObject;

		comicAll.transform.localPosition = new Vector3(-0.4f, 0.35f, 0.58f);

		// 5
		UIAll = Instantiate(toggler, new Vector3(0,0,0), 
			Quaternion.Euler(-120, 0, 0), otherSettings.transform) as GameObject;

		UIAll.transform.localPosition = new Vector3(0, 0.35f, 0.61f);

		//6
		tipsAll = Instantiate(toggler, new Vector3(0,0,0), 
			Quaternion.Euler(-120, 10, 10), otherSettings.transform) as GameObject;

		tipsAll.transform.localPosition = new Vector3(0.4f, 0.35f, 0.58f);

		moversAll.name = "Movers";
		lightsAll.name = "Lights";
		heightAll.name = "Height";
		comicAll.name = "Comic";
		UIAll.name = "UI";
		tipsAll.name = "Tips";

		moversText = moversAll.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>();
		moversText.text = "Қимыл жебелері";

		lightsText = lightsAll.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>();
		lightsText.text = "Жарық";

		heightText = heightAll.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>();
		heightText.text = "Ұзындық";

		comicText = comicAll.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>();
		comicText.text = "Комик";

		UIText = UIAll.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>();
		UIText.text = "Көмекші";

		tipsText = tipsAll.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>();
		tipsText.text = "Маркер";
	}

	public void Pressed (GameObject go){
		if(go.name == "on"){
			if(go.transform.parent.parent.name == "Settings"){
				Values.settings = true;
			}

			if(go.transform.parent.parent.name == "Movers"){
				Values.movers = true;
			}

			if(go.transform.parent.parent.name == "Lights"){
				Values.lights = true;
			}

			if(go.transform.parent.parent.name == "Height"){
				Values.height = true;
			}

			if(go.transform.parent.parent.name == "Comic"){
				Values.comic = true;
			}

			if(go.transform.parent.parent.name == "UI"){
				Values.UI = true;
			}

			if(go.transform.parent.parent.name == "Tips"){
				Values.tips = true;
			}
		}

		if(go.name == "off"){
			if(go.transform.parent.parent.name == "Settings"){
				Values.settings = false;
			}

			if(go.transform.parent.parent.name == "Movers"){
				Values.movers = false;
			}

			if(go.transform.parent.parent.name == "Lights"){
				Values.lights = false;
			}

			if(go.transform.parent.parent.name == "Height"){
				Values.height = false;
			}

			if(go.transform.parent.parent.name == "Comic"){
				Values.comic = false;
			}

			if(go.transform.parent.parent.name == "UI"){
				Values.UI = false;
			}

			if(go.transform.parent.parent.name == "Tips"){
				Values.tips = false;
			}
		}

		if(go.name == "ClapButton"){
			humanManager.MakeClap();
		}

		if(go.transform.parent.name == "arrowLeft"){
			slideManager.Prev();
		}

		if(go.transform.parent.name == "arrowRight"){
			slideManager.Next();
		}
	}

	void DestroyAll() {
		Destroy(moversAll);
		Destroy(lightsAll);
		Destroy(heightAll);
		Destroy(comicAll);
		Destroy(UIAll);
		Destroy(tipsAll);
	}
}

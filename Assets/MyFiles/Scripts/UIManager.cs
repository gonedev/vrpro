using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	Text UIText;
	public string state = "first";
	public float tipLastTime = 6f;

	void Start () {
		UIText = GameObject.Find("UIText").GetComponent<Text>();
	}
	
	void Update () {
		if(Values.UI) {
			if(state == "first"){
				StartCoroutine("FirstTip");
			}
			if(state == "second"){
				StartCoroutine("SecondTip");
			}
			if(state == "third"){
				StartCoroutine("ThirdTip");
			}
			if(state == "fourth"){
				StartCoroutine("FourthTip");
			}
		} else {
			UIText.text = "";
		}
	}

	IEnumerator FirstTip () {
		UIText.text = "Қош келдіңіз. Бұл көпшілік алдында сөйлеуді жаттықтыруға арналған виртуалды шынайылықтың қосымшасы";
		yield return new WaitForSeconds(tipLastTime);
		state = "second";
	}

	IEnumerator SecondTip () {
		UIText.text = "Кеңістікте қозғалу үшін жан жақта орналасқан шеңберлерге қараңыз. Басқару панелін қолдану үшін үстідегі \"Баптамалар\" батырмасына көңіл аударыңыз";
		yield return new WaitForSeconds(tipLastTime);
		state = "third";
	}

	IEnumerator ThirdTip () {
		UIText.text = "Басқару панелінде жарықты, көмекшіні, қозғалыс шеңберлерін қосып өшіруге, бойды өзгертуге болады. Керекті баптаманы қосу үшін сәйкес панельдегі жасыл батырмаға қараңыз, өшіру үшін қызыл батырмаға қараңыз";
		yield return new WaitForSeconds(tipLastTime);
		state = "fourth";
	}

	IEnumerator FourthTip () {
		UIText.text = "Есіктерді ашу үшін оларға жай ғана жақындаңыз, cол жақтағы есік акт залына бағыттайды, оң жақтағы есік конференция бөлмесіне апарады";
		yield return new WaitForSeconds(tipLastTime);
		UIText.text = "";
		state = "first";
		Values.UI = false;
	}
}

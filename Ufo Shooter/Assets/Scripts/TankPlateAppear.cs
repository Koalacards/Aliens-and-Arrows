using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TankPlateAppear : MonoBehaviour {

	public GameObject regularPlate;
	public GameObject tankPlate;
	public GameObject speedyPlate;
	public GameObject zigzagPlate;
	public GameObject ztankPlate;
	public GameObject boss1Plate;
	public GameObject superPlate;
	public GameObject szigPlate;
	public GameObject tportPlate;
	public GameObject boss2Plate;
	public GameObject ultraPlate;
	public GameObject uzigPlate;
	public GameObject sspeedPlate;
	public GameObject boss3Plate;
	
	void Start () {
		ResetPlates();

		if (1 == PlayerPrefs.GetInt("RegInPlay")){
			regularPlate.gameObject.SetActive(true);
		}
		if (1 == PlayerPrefs.GetInt("TankInPlay")){
			tankPlate.gameObject.SetActive(true);
		}
		if (1 == PlayerPrefs.GetInt("SpeedyInPlay")){
			speedyPlate.gameObject.SetActive(true);
		}
		if (1 == PlayerPrefs.GetInt("ZigInPlay")){
			zigzagPlate.gameObject.SetActive(true);
		}
		if (1 == PlayerPrefs.GetInt("TZigInPlay")){
			ztankPlate.gameObject.SetActive(true);
		}
		if (1 == PlayerPrefs.GetInt("Boss1InPlay")){
			boss1Plate.gameObject.SetActive(true);
		}
		if (1 == PlayerPrefs.GetInt("SuperInPlay")){
			superPlate.gameObject.SetActive(true);
		}
		if (1 == PlayerPrefs.GetInt("SZigInPlay")){
			szigPlate.gameObject.SetActive(true);
		}
		if (1 == PlayerPrefs.GetInt("TPortInPlay")){
			tportPlate.gameObject.SetActive(true);
		}
		if (1 == PlayerPrefs.GetInt("Boss2InPlay")){
			boss2Plate.gameObject.SetActive(true);
		}
		if (1 == PlayerPrefs.GetInt("UltraInPlay")){
			ultraPlate.gameObject.SetActive(true);
		}
		if (1 == PlayerPrefs.GetInt("UZigInPlay")){
			uzigPlate.gameObject.SetActive(true);
		}
		if (1 == PlayerPrefs.GetInt("SSpeedInPlay")){
			sspeedPlate.gameObject.SetActive(true);
		}
		if (1 == PlayerPrefs.GetInt("Boss3InPlay")){
			boss3Plate.gameObject.SetActive(true);
		}
	}
	void ResetPlates(){
		regularPlate.gameObject.SetActive(false);
		tankPlate.gameObject.SetActive(false);
		speedyPlate.gameObject.SetActive(false);
		zigzagPlate.gameObject.SetActive(false);
		ztankPlate.gameObject.SetActive(false);
		boss1Plate.gameObject.SetActive(false);
		superPlate.gameObject.SetActive(false);
		szigPlate.gameObject.SetActive(false);
		tportPlate.gameObject.SetActive(false);
		boss2Plate.gameObject.SetActive(false);
		ultraPlate.gameObject.SetActive(false);
		uzigPlate.gameObject.SetActive(false);
		sspeedPlate.gameObject.SetActive(false);
		boss3Plate.gameObject.SetActive(false);
	}
}

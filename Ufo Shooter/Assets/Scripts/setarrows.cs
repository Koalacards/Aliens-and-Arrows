using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class setarrows : MonoBehaviour {
	public Image FireArrow;
	public Image IceArrow;
	public Image PoisonArrow;
	public Image BombArrow;
	public Image RegArrowRaid;
	public TextMeshProUGUI RegArrowRaidAmount;
	public Image FireArrowRaid;
	public TextMeshProUGUI FireArrowRaidAmount;
	public Image BombArrowRaid;
	public TextMeshProUGUI BombArrowRaidAmount;
	public TextMeshProUGUI fireDamage;
	public TextMeshProUGUI poisonDamage;
	public TextMeshProUGUI bombDamage;
	// Use this for initialization
	void Start () {
		if (1 == PlayerPrefs.GetInt ("firearrowactive")) {
			FireArrow.gameObject.SetActive (true);
			fireDamage.gameObject.SetActive (true);
		}
		if (0 == PlayerPrefs.GetInt ("firearrowactive")) {
			FireArrow.gameObject.SetActive (false);
			fireDamage.gameObject.SetActive (false);
		}
		if (1 == PlayerPrefs.GetInt ("icearrowactive")) {
			IceArrow.gameObject.SetActive (true);
		}
		if (0 == PlayerPrefs.GetInt ("icearrowactive")) {
			IceArrow.gameObject.SetActive (false);
		}
		if (1 == PlayerPrefs.GetInt ("poisonarrowactive")) {
			PoisonArrow.gameObject.SetActive (true);
			poisonDamage.gameObject.SetActive (true);
		}
		if (0 == PlayerPrefs.GetInt ("poisonarrowactive")) {
			PoisonArrow.gameObject.SetActive (false);
			poisonDamage.gameObject.SetActive (false);
		}
		if (1 == PlayerPrefs.GetInt ("bombarrowactive")) {
			BombArrow.gameObject.SetActive (true);
			bombDamage.gameObject.SetActive (true);
		} else {
			BombArrow.gameObject.SetActive (false);
			bombDamage.gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (1 == PlayerPrefs.GetInt ("RegRaidActive")) {
			RegArrowRaid.gameObject.SetActive (true);
			RegArrowRaidAmount.text = "" + PlayerPrefs.GetInt ("RegArrowRaidAmount");
		} else {
			RegArrowRaid.gameObject.SetActive (false);
			RegArrowRaidAmount.text = "";
		}
		if (1 == PlayerPrefs.GetInt ("FireRaidActive")) {
			FireArrowRaid.gameObject.SetActive (true);
			FireArrowRaidAmount.text = "" + PlayerPrefs.GetInt ("FireArrowRaidAmount");
		} else {
			FireArrowRaid.gameObject.SetActive (false);
			FireArrowRaidAmount.text = "";
		}
		if (1 == PlayerPrefs.GetInt ("BombRaidActive")) {
			BombArrowRaid.gameObject.SetActive (true);
			BombArrowRaidAmount.text = "" + PlayerPrefs.GetInt ("BombArrowRaidAmount");
		} else {
			BombArrowRaid.gameObject.SetActive (false);
			BombArrowRaidAmount.text = "";
		}

		if(0 < PlayerPrefs.GetInt("RegArrowRaidAmount"))
		{
			PlayerPrefs.SetInt ("RegRaidActive", 1);
		}else{
			PlayerPrefs.SetInt ("RegRaidActive", 0);
		}
		if (0 < PlayerPrefs.GetInt ("FireArrowRaidAmount")) {
			PlayerPrefs.SetInt ("FireRaidActive", 1);
		} else {
			PlayerPrefs.SetInt ("FireRaidActive", 0);
		}
		if (0 < PlayerPrefs.GetInt ("BombArrowRaidAmount")) {
			PlayerPrefs.SetInt ("BombRaidActive", 1);
		} else {
			PlayerPrefs.SetInt ("BombRaidActive", 0);
		}
	}

	public void scenechange(string scene)
	{
		SceneManager.LoadScene (scene);
	}
}

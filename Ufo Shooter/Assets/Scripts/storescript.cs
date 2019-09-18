using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class storescript : MonoBehaviour {
	public TextMeshProUGUI FireText;
	public TextMeshProUGUI IceText;
	public TextMeshProUGUI cointext;
	public TextMeshProUGUI firesold;
	public TextMeshProUGUI icesold;
	public TextMeshProUGUI poisonsold;
	public TextMeshProUGUI notenoughfunds;
	public Image poison;
	public TextMeshProUGUI PoisonText;
	public Image RegArrowRaid;
	public TextMeshProUGUI amountRegArrowRaid;
	public TextMeshProUGUI RegArrowRaidText;
	public Image FireArrowRaid;
	public TextMeshProUGUI amountFireArrowRaid;
	public TextMeshProUGUI FireArrowRaidText;
	public TextMeshProUGUI BombText;
	public TextMeshProUGUI bombsold;
	public Image Bomb;
	public TextMeshProUGUI MaxNumRaids;
	public Image BombArrowRaid;
	public TextMeshProUGUI BombArrowRaidText;
	public TextMeshProUGUI amountBombRaid;
	public TextMeshProUGUI comingSoon;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("coins", 8000);
		FireText.gameObject.SetActive (false);
		IceText.gameObject.SetActive (false);
		PoisonText.gameObject.SetActive (false);
		RegArrowRaidText.gameObject.SetActive (false);
		FireArrowRaidText.gameObject.SetActive (false);
		BombText.gameObject.SetActive (false);
		BombArrowRaidText.gameObject.SetActive (false);
		if(1 == PlayerPrefs.GetInt("firearrowactive"))
			{
			firesold.text = "Sold!";
			}
		if(1 == PlayerPrefs.GetInt("icearrowactive"))
		{
			icesold.text = "Sold!";
		}
		if(1 == PlayerPrefs.GetInt("poisonarrowactive"))
		{
			poisonsold.text = "Sold!";
		}
		if(0 == PlayerPrefs.GetInt("firearrowactive"))
		{
			firesold.text = "";
		}
		if(0 == PlayerPrefs.GetInt("icearrowactive"))
		{
			icesold.text = "";
		}
		if(0 == PlayerPrefs.GetInt("poisonarrowactive"))
		{
			poisonsold.text = "";
		}
		if (1 == PlayerPrefs.GetInt ("bombarrowactive")) {
			bombsold.text = "Sold!";
		} else {
			bombsold.text = "";
		}

		notenoughfunds.text = "";
		MaxNumRaids.text = "";

		if (9 <= PlayerPrefs.GetInt ("level")) {
			poison.gameObject.SetActive (true);
			RegArrowRaid.gameObject.SetActive (true);
			amountRegArrowRaid.gameObject.SetActive (true);
		} else {
			poison.gameObject.SetActive (false);
			RegArrowRaid.gameObject.SetActive (false);
			amountRegArrowRaid.gameObject.SetActive (false);
		}
		if (14 <= PlayerPrefs.GetInt ("level")) {
			FireArrowRaid.gameObject.SetActive (true);
			amountFireArrowRaid.gameObject.SetActive (true);
		} else {
			FireArrowRaid.gameObject.SetActive (false);
			amountFireArrowRaid.gameObject.SetActive (false);
		}

		if (19 <= PlayerPrefs.GetInt ("level")) {
			Bomb.gameObject.SetActive (true);
		} else {
			Bomb.gameObject.SetActive (false);
		}

		if (26 <= PlayerPrefs.GetInt ("level")) {
			BombArrowRaid.gameObject.SetActive (true);
			amountBombRaid.gameObject.SetActive(true);
			comingSoon.text = "Coming\nSoon!";
		} else {
			BombArrowRaid.gameObject.SetActive (false);
			amountBombRaid.gameObject.SetActive(false);
			comingSoon.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		cointext.text = "Coins: " + PlayerPrefs.GetInt ("coins");
		amountRegArrowRaid.text = "Number of\nRaids: " + PlayerPrefs.GetInt ("RegArrowRaidAmount");
		amountFireArrowRaid.text = "Number of \nRaids: " + PlayerPrefs.GetInt ("FireArrowRaidAmount");
		amountBombRaid.text = "Number of \nRaids: " + PlayerPrefs.GetInt ("BombArrowRaidAmount");
	}
	public void ClickonFire()
	{
		if (0 == PlayerPrefs.GetInt ("firearrowactive")) {
			FireText.gameObject.SetActive (true);
			IceText.gameObject.SetActive (false);
			PoisonText.gameObject.SetActive (false);
			RegArrowRaidText.gameObject.SetActive (false);
			FireArrowRaidText.gameObject.SetActive (false);
			BombText.gameObject.SetActive (false);
			BombArrowRaidText.gameObject.SetActive (false);
		}
	}
	public void ClickonIce()
	{
		if (0 == PlayerPrefs.GetInt ("icearrowactive")) {
			IceText.gameObject.SetActive (true);
			FireText.gameObject.SetActive (false);
			PoisonText.gameObject.SetActive (false);
			RegArrowRaidText.gameObject.SetActive (false);
			FireArrowRaidText.gameObject.SetActive (false);
			BombText.gameObject.SetActive (false);
			BombArrowRaidText.gameObject.SetActive (false);
		}
	}
	public void ClickonPoison()
	{
		if (0 == PlayerPrefs.GetInt ("poisonarrowactive")) {
			IceText.gameObject.SetActive (false);
			FireText.gameObject.SetActive (false);
			PoisonText.gameObject.SetActive (true);
			RegArrowRaidText.gameObject.SetActive (false);
			FireArrowRaidText.gameObject.SetActive (false);
			BombText.gameObject.SetActive (false);
			BombArrowRaidText.gameObject.SetActive (false);
		}
	}
	public void ClickOnRegArrowRaid()
	{
		RegArrowRaidText.gameObject.SetActive (true);
		IceText.gameObject.SetActive (false);
		FireText.gameObject.SetActive (false);
		PoisonText.gameObject.SetActive (false);
		FireArrowRaidText.gameObject.SetActive (false);
		BombText.gameObject.SetActive (false);
		BombArrowRaidText.gameObject.SetActive (false);
	}
	public void ClickOnFireArrowRaid()
	{
		RegArrowRaidText.gameObject.SetActive (false);
		IceText.gameObject.SetActive (false);
		FireText.gameObject.SetActive (false);
		PoisonText.gameObject.SetActive (false);
		FireArrowRaidText.gameObject.SetActive(true);
		BombText.gameObject.SetActive (false);
		BombArrowRaidText.gameObject.SetActive (false);
	}

	public void ClickOnBomb()
	{
		if (0 == PlayerPrefs.GetInt ("bombarrowactive")) {
			RegArrowRaidText.gameObject.SetActive (false);
			IceText.gameObject.SetActive (false);
			FireText.gameObject.SetActive (false);
			PoisonText.gameObject.SetActive (false);
			FireArrowRaidText.gameObject.SetActive (false);
			BombText.gameObject.SetActive (true);
			BombArrowRaidText.gameObject.SetActive (false);
		}
	}
	public void ClickOnBombRaid()
	{
		BombArrowRaidText.gameObject.SetActive (true);
		RegArrowRaidText.gameObject.SetActive (false);
		IceText.gameObject.SetActive (false);
		FireText.gameObject.SetActive (false);
		PoisonText.gameObject.SetActive (false);
		FireArrowRaidText.gameObject.SetActive (false);
		BombText.gameObject.SetActive (false);
	}
	public void FireArrowPurchase()
	{
		if (100 <= PlayerPrefs.GetInt ("coins")) {
			PlayerPrefs.SetInt ("firearrowactive", 1);
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") - 100);
			firesold.text = "Sold!";
		} else {
			notenoughfunds.text = "Not Enough Funds";
			Invoke ("endtext", 5f);
		}
	}
	public void IceArrowPurchase()
	{
		if (200 <= PlayerPrefs.GetInt ("coins")) {
			PlayerPrefs.SetInt ("icearrowactive", 1);
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") - 200);
			icesold.text = "Sold!";
		}else {
			notenoughfunds.text = "Not Enough Funds";
			Invoke ("endtext", 5f);
		}
	}
	public void PoisonArrowPurchase()
	{
		if (750 <= PlayerPrefs.GetInt ("coins")) {
			PlayerPrefs.SetInt ("poisonarrowactive", 1);
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") - 750);
			poisonsold.text = "Sold!";
		}else {
			notenoughfunds.text = "Not Enough Funds";
			Invoke ("endtext", 5f);
		}
	}
	public void BombArrowPurchase()
	{
		if (1500 <= PlayerPrefs.GetInt ("coins")) {
			PlayerPrefs.SetInt ("bombarrowactive", 1);
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") - 1500);
			bombsold.text = "Sold!";
		} else {
			notenoughfunds.text = "Not Enough Funds";
			Invoke ("endtext", 5f);
		}
	}
	public void RegArrowRaidPurchase()
	{
		if (8 >= PlayerPrefs.GetInt ("RegArrowRaidAmount")) {
			if (300 <= PlayerPrefs.GetInt ("coins")) {
				PlayerPrefs.SetInt ("RegArrowRaidAmount", PlayerPrefs.GetInt ("RegArrowRaidAmount") + 1);
				PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") - 300);
			} else {
				notenoughfunds.text = "Not Enough Funds";
				Invoke ("endtext", 5f);
			}
		} else {
			MaxNumRaids.text = "Max Number of Raids Obtained";
			Invoke ("endtext", 5f);
		}
	}
	public void FireArrowRaidPurchase()
	{
		if (8 >= PlayerPrefs.GetInt ("FireArrowRaidAmount")) {
			if (500 <= PlayerPrefs.GetInt ("coins")) {
				PlayerPrefs.SetInt ("FireArrowRaidAmount", PlayerPrefs.GetInt ("FireArrowRaidAmount") + 1);
				PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") - 500);
			} else {
				notenoughfunds.text = "Not Enough Funds";
				Invoke ("endtext", 5f);
			}
		} else {
			MaxNumRaids.text = "Max Number of Raids Obtained";
			Invoke ("endtext", 5f);
		}
	}
	public void BombRaidPurchase()
	{

		if (8 >= PlayerPrefs.GetInt ("BombArrowRaidAmount")) {
			if (700 <= PlayerPrefs.GetInt ("coins")) {
				PlayerPrefs.SetInt ("BombArrowRaidAmount", PlayerPrefs.GetInt ("BombArrowRaidAmount") + 1);
				PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") - 700);
			} else {
				notenoughfunds.text = "Not Enough Funds";
				Invoke ("endtext", 5f);
			}
		} else {
			MaxNumRaids.text = "Max Number of Raids Obtained";
			Invoke ("endtext", 5f);
		}
	}
	public void endtext()
	{
		notenoughfunds.text = "";
		MaxNumRaids.text = "";
	}
	public void ChangeScene(string scenename)
	{
		SceneManager.LoadScene (scenename);
	}
	public void ChangeSceneToStoryMode(string scenename)
	{
		PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
		SceneManager.LoadScene (scenename);
	}
}

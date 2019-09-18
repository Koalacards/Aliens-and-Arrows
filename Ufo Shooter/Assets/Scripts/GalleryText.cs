using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalleryText : MonoBehaviour {

	public TextMeshProUGUI regularText;
	public TextMeshProUGUI tankText;
	public TextMeshProUGUI speedyText;
	public TextMeshProUGUI zigzagText;
	public TextMeshProUGUI tzigText;
	public TextMeshProUGUI boss1Text;
	public TextMeshProUGUI superText;
	public TextMeshProUGUI szigText;
	public TextMeshProUGUI tportText;
	public TextMeshProUGUI boss2Text;
	public TextMeshProUGUI ultraText;
	public TextMeshProUGUI uzigText;
	public TextMeshProUGUI sspeedText;
	public TextMeshProUGUI boss3Text;


	// Use this for initialization
	void Start () {
		ResetTexts();
	}
	
	
	public void ResetTexts()
	{
		regularText.gameObject.SetActive (false);
		tankText.gameObject.SetActive (false);
		speedyText.gameObject.SetActive (false);
		zigzagText.gameObject.SetActive (false);
		tzigText.gameObject.SetActive (false);
		boss1Text.gameObject.SetActive (false);
		superText.gameObject.SetActive (false);
		szigText.gameObject.SetActive (false);
		tportText.gameObject.SetActive (false);
		boss2Text.gameObject.SetActive (false);
		ultraText.gameObject.SetActive (false);
		uzigText.gameObject.SetActive (false);
		sspeedText.gameObject.SetActive (false);
		boss3Text.gameObject.SetActive (false);
	}

	public void ShowText(string key)
	{
		ResetTexts();	
		switch (key)
		{
			case "regular":
			regularText.gameObject.SetActive(true);
			Debug.Log("Pressed");
			break;
			case "tank":
			tankText.gameObject.SetActive(true);
			break;
			case "speedy":
			speedyText.gameObject.SetActive(true);
			break;
			case "zigzag":
			zigzagText.gameObject.SetActive(true);
			Debug.Log("Pressed!");
			break;
			case "tzig":
			tzigText.gameObject.SetActive(true);
			break;
			case "boss1":
			boss1Text.gameObject.SetActive(true);
			break;
			case "super":
			superText.gameObject.SetActive(true);
			break;
			case "szig":
			szigText.gameObject.SetActive(true);
			break;
			case "tport":
			tportText.gameObject.SetActive(true);
			break;
			case "boss2":
			boss2Text.gameObject.SetActive(true);
			break;
			case "ultra":
			ultraText.gameObject.SetActive(true);
			break;
			case "uzig":
			uzigText.gameObject.SetActive(true);
			break;
			case "sspeed":
			sspeedText.gameObject.SetActive(true);
			break;
			case "boss3":
			boss3Text.gameObject.SetActive(true);
			break;
		}
	}
}

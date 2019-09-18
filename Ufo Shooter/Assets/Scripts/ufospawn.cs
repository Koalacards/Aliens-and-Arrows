using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ufospawn : MonoBehaviour {
	public GameObject ufo;
	public GameObject[] ufoslvl2to3;   //the array of ufo's for each level
	public GameObject[] ufoslvl4;
	public GameObject[] ufoslvl5;
	public GameObject[] ufoslvl6;
	public GameObject[] ufoslvl78;
	public GameObject[] ufoslvl9;
	public GameObject boss1;
	public GameObject[] ufoslvl11_12;
	public GameObject ufolvl13;
	public GameObject[] ufoslvl14_15;
	public GameObject ufolvl16;
	public GameObject[] ufoslvl17_18;
	public GameObject ufolvl19;
	public GameObject boss2;
	public GameObject[] ufoslvl21_22;
	public GameObject ufolvl23;
	public GameObject[]ufoslvl24_25;
	public GameObject[]ufoslvl26;
	public GameObject[]ufoslvl27;
	public GameObject[]ufoslvl28;
	public GameObject[]ufoslvl29;
	int ufoamount;
	float buffertime;
	public Canvas winCanvas;
	public Canvas loseCanvas;
	int numberofufo;
	public TextMeshProUGUI levelintrotext;
	public TextMeshProUGUI leveltext;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI coinText;
	public TextMeshProUGUI pullbackarrow;
	int levelnum;
	int levelint;
	public Image blueufo;
	public Image redufo;
	public Image greenufo;
	bool levelDone;
	public Image yellowufo;
	int coinslost;
	public Image orangeufo;
	public Image darkpurpleufo;
	public TextMeshProUGUI RageMode;
	public TextMeshProUGUI bosswarning;
	public TextMeshProUGUI newItemsAvailable;
	public GameObject RegArrowRaid;
	public Image magentaufo;
	public GameObject FireArrowRaid;
	public Image greyufo;
	public Image DBlueUfo;
	public Image WhiteUfo;
	public Image DGreenUfo;
	public GameObject BombArrowRaid;
	public int cAmount;//Amount of coins	
	public int araidAmount;//Amount of regular arrow raids
	public int fraidAmount;//Amount of fire raids
	public int braidAmount;//Amount of bomb raids

	public GameObject FinalBoss;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("level", 0);
		resetlevel ();
		levelDone = false;
		RageMode.text = "";
		newItemsAvailable.text = "";
		loseCanvas.gameObject.SetActive (false);
		PlayerPrefs.SetInt("InScene", 1);
		PlayerPrefs.SetInt("Lose", 0);
	}
	// Update is called once per frame
	void Update () {
		if (1 == PlayerPrefs.GetInt("Lose") && levelDone == false) {
			faillevel();
			levelDone = true;
		}
		if (ufoamount <= 0) {
			winCanvas.gameObject.SetActive (true);
			if (9 == PlayerPrefs.GetInt ("level") || 14 == PlayerPrefs.GetInt ("level") || 19 == PlayerPrefs.GetInt ("level") || 26 == PlayerPrefs.GetInt("level")) {
				newItemsAvailable.text = "New Items\nAvailable At\nThe Shop!";
			} else {
				newItemsAvailable.text = "";
			}
		}
		levelint = PlayerPrefs.GetInt ("level") + 1;
		leveltext.text = "Level " + levelint;
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("Score");

		coinText.text = "Coins: " + PlayerPrefs.GetInt ("coins");

	}

	void spawn() //spawns the ufo's based on level- remember that the player prefs level is always one less than the actual level
	{
		switch(PlayerPrefs.GetInt("level")){
		case 0:
			GameObject newUFO = Instantiate (ufo);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			break;
		
		case 1:
		case 2:
			newUFO = Instantiate(ufoslvl2to3[Random.Range(0, ufoslvl2to3.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			break;
		case 3:
			newUFO = Instantiate(ufoslvl4[Random.Range(0, ufoslvl4.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			break;
		case 4:
			newUFO = Instantiate(ufoslvl5[Random.Range(0, ufoslvl5.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			break;
		case 5:
			newUFO = Instantiate(ufoslvl6[Random.Range(0, ufoslvl6.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			break;
		case 6:
		case 7:
			newUFO = Instantiate (ufoslvl78 [Random.Range (0, ufoslvl78.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			break;
		case 8:
			newUFO = Instantiate (ufoslvl9 [Random.Range (0, ufoslvl9.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			break;
		case 9:
			newUFO = Instantiate (boss1);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-1, 1));
			break;
		case 10:
		case 11:
			newUFO = Instantiate (ufoslvl11_12 [Random.Range (0, ufoslvl11_12.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			break;
		case 12:
			newUFO = Instantiate (ufolvl13);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.5f, 2.5f));
			break;
		case 13:
		case 14:
			newUFO = Instantiate (ufoslvl14_15 [Random.Range (0, ufoslvl14_15.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			break;
		case 15:
			newUFO = Instantiate (ufolvl16);
			newUFO.gameObject.transform.position = new Vector2 (10, 0);
			break;

		case 16:
		case 17:
			newUFO = Instantiate (ufoslvl17_18 [Random.Range (0, ufoslvl17_18.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			break;

		case 18:
			newUFO = Instantiate (ufolvl19);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			break;

		case 19:
			if (numberofufo == 4) {
				newUFO = Instantiate (boss2);
				newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-1f, 1f));
			} else {
				newUFO = Instantiate (ufolvl19);
				newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			}
			break;

		case 20:
		case 21:
			newUFO = Instantiate (ufoslvl21_22 [Random.Range (0, ufoslvl21_22.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			break;

		case 22:
			newUFO = Instantiate (ufolvl23);
			newUFO.gameObject.transform.position = new Vector2 (10, 0);
			break;

		case 23:
		case 24:
			newUFO = Instantiate (ufoslvl24_25 [Random.Range (0, ufoslvl24_25.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
			break;

		case 25:
			newUFO = Instantiate (ufoslvl26 [Random.Range (0, ufoslvl26.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.4f, 3.1f));
			break;

		case 26:
			newUFO = Instantiate (ufoslvl27 [Random.Range (0, ufoslvl27.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, 0);
			break;

		case 27:
			newUFO = Instantiate (ufoslvl28 [Random.Range (0, ufoslvl28.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-1.5f, 2f));
			break;

		case 28:
			newUFO = Instantiate (ufoslvl29 [Random.Range (0, ufoslvl29.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2f, 3f));
			break;
		case 29:
		newUFO = Instantiate(FinalBoss);
		newUFO.gameObject.transform.position = new Vector2(10, Random.Range(-.5f, .5f));
		break;
		}
		numberofufo = numberofufo - 1;	
		Invoke("StartAgain", buffertime);

	}

	public void StartAgain()//continues spawning if there are more ufos in the level to be spawned
	{
		if (numberofufo > 0) {
			spawn ();
		}
	}
	public void endstarttext()//ends all of the texts at the beginning of the level
	{
		levelintrotext.text = "";
		pullbackarrow.text = "";
		greyufo.gameObject.SetActive (false);
		magentaufo.gameObject.SetActive (false);
		bosswarning.gameObject.SetActive (false);
		blueufo.gameObject.SetActive (false);
		redufo.gameObject.SetActive (false);
		greenufo.gameObject.SetActive (false);
		yellowufo.gameObject.SetActive (false);
		orangeufo.gameObject.SetActive (false);
		darkpurpleufo.gameObject.SetActive (false);
		DBlueUfo.gameObject.SetActive (false);
		WhiteUfo.gameObject.SetActive (false);
		DGreenUfo.gameObject.SetActive (false);
	}
	public void faillevel()//function for when the level is over
	{
		loseCanvas.gameObject.SetActive (true);
		resetValues ();
		numberofufo = 10000000;
		PlayerPrefs.SetInt ("Lose", 0);
	}
	public void resetlevel()//function that sets up each level including how many ufos, time between spawns and texts
		{
		setupValues ();
		switch(PlayerPrefs.GetInt("level")){
		case 0:
			buffertime = Random.Range (4.5f, 4.9f);
			ufoamount = 10;
			numberofufo = 10;
			levelintrotext.text = "Level 1\nIt Begins...";
			pullbackarrow.text = "Pull back \nthe arrow \nto shoot";
			blueufo.gameObject.SetActive (true);
			PlayerPrefs.SetInt("RegInPlay", 1);
			break;

		case 1: 
			buffertime = Random.Range (4.2f, 4.5f);
			ufoamount = 15;
			numberofufo = 15;
			levelintrotext.text = "Level 2\nAnother\nShot\nNecessary";
			redufo.gameObject.SetActive (true);
			PlayerPrefs.SetInt("TankInPlay", 1);
			break;
		case 2:
			
			buffertime = Random.Range (3.8f, 4.2f);
			ufoamount = 20;
			numberofufo = 20;
			levelintrotext.text = "Level 3\n Incoming";
			break;
		case 3:
			buffertime = Random.Range (3.5f, 3.9f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 4\n Speedier";
			greenufo.gameObject.SetActive (true);
			PlayerPrefs.SetInt("SpeedyInPlay", 1);
			break;
		case 4:
			buffertime = Random.Range (3.2f, 3.4f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 5\nAliens Galore";
			break;
		case 5:
			buffertime = Random.Range (3.1f, 3.3f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 6\nUps and\nDowns";
			yellowufo.gameObject.SetActive (true);
			PlayerPrefs.SetInt("ZigInPlay", 1);
			break;
		case 6:
			buffertime = Random.Range (3.1f, 3.2f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 7\nBye Bye\nBlues";
			break;
		case 7:
			buffertime = Random.Range (2.9f, 3.1f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 8\nFaster\n";
			break;

		case 8:
			buffertime = Random.Range (3.2f, 3.4f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 9\nTanky Ups\nand Downs\n";
			orangeufo.gameObject.SetActive (true);
			PlayerPrefs.SetInt("TZigInPlay", 1);
			break;

		case 9:
			buffertime = Random.Range (3.2f, 3.4f);
			ufoamount = 1;
			numberofufo = 1;
			levelintrotext.text = "Level 10\nBoss 1\n";
			bosswarning.gameObject.SetActive (true);
			PlayerPrefs.SetInt("Boss1InPlay", 1);
			break;

		case 10:
			buffertime = Random.Range (3.2f, 3.4f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 11\nEven more\nTanky\n";
			darkpurpleufo.gameObject.SetActive (true);
			PlayerPrefs.SetInt("SuperInPlay", 1);
			break;

		case 11:
			buffertime = Random.Range (3.1f, 3.2f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 12\nPesky\nAliens\n";
			break; 

		case 12:
			buffertime = Random.Range (3.2f, 3.4f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 13\nSpeed\t\nRound\n";
			break;

		case 13:
			buffertime = Random.Range (3.1f, 3.2f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 14\nSuper\nZigzags\n";
			magentaufo.gameObject.SetActive (true);
			PlayerPrefs.SetInt("SZigInPlay", 1);
			break;

		case 14:
			buffertime = Random.Range (2.8f, 3f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 15\nMore  \t\n";
			break;
		case 15:
			buffertime = Random.Range (.3f, .31f);
			ufoamount = 18;
			numberofufo = 18;
			levelintrotext.text = "Level 16\nGiant\nZigzag  \t\n";
			break;

		case 16:
			buffertime = Random.Range (3.2f, 3.4f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 17\nWarps &\nPortals";
			greyufo.gameObject.SetActive (true);
			PlayerPrefs.SetInt("TPortInPlay", 1);
			break;

		case 17:
			buffertime = Random.Range (3.0f, 3.2f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 18\nThey Wont\nStop";
			break;

		case 18:
			buffertime = Random.Range (3.2f, 3.3f);
			ufoamount = 15;
			numberofufo = 15;
			levelintrotext.text = "Level 19\nMadness";
			break;

		case 19:
			buffertime = Random.Range (3.5f, 3.6f);
			ufoamount = 7;
			numberofufo = 7;
			levelintrotext.text = "Level 20\nBoss 2";
			PlayerPrefs.SetInt("Boss2InPlay", 1);
			break;

		case 20:
			buffertime = Random.Range (3.4f, 3.6f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 21\nGoing\nUltra";
			DBlueUfo.gameObject.SetActive (true);
			PlayerPrefs.SetInt("UltraInPlay", 1);
			break;

		case 21:
			buffertime = Random.Range (3.1f, 3.4f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 22\nRaids\nRequired";
			break;

		case 22:
			buffertime = Random.Range (.3f, .5f);
			ufoamount = 12;
			numberofufo = 12;
			levelintrotext.text = "Level 23\nThe Line";
			break;

		case 23:
			buffertime = Random.Range (3.3f, 3.5f);
			ufoamount = 20;
			numberofufo = 20;
			levelintrotext.text = "Level 24\nThe Best\nAttacker";
			WhiteUfo.gameObject.SetActive (true);
			PlayerPrefs.SetInt("UZigInPlay", 1);
			break;

		case 24:
			buffertime = Random.Range (3.1f, 3.3f);
			ufoamount = 23;
			numberofufo = 23;
			levelintrotext.text = "Level 25\nCruelty";
			break;

		case 25:
			buffertime = Random.Range (3.3f, 3.5f);
			ufoamount = 20;
			numberofufo = 20;
			levelintrotext.text = "Level 26\nExtra\nFast";
			DGreenUfo.gameObject.SetActive (true);
			PlayerPrefs.SetInt("SSpeedInPlay", 1);
			break;

		case 26:
			buffertime = Random.Range (.3f, .5f);
			ufoamount = 12;
			numberofufo = 12;
			levelintrotext.text = "Level 27\nZigZags";
			break;

		case 27:
			buffertime = Random.Range (3.29f, 3.3f);
			ufoamount = 25;
			numberofufo = 25;
			levelintrotext.text = "Level 28\nChaos";
			break;
		case 28:
			buffertime = Random.Range (3.19f, 3.2f);
			ufoamount = 30;
			numberofufo = 30;
			levelintrotext.text = "Level 29\nGood\nLuck";
			break;
		case 29:
			ufoamount = 1;
			numberofufo = 1;
			levelintrotext.text = "Level 30\nThe Final\n Boss";
			PlayerPrefs.SetInt("Boss3InPlay", 1);
		break;
		}
			winCanvas.gameObject.SetActive (false);
			loseCanvas.gameObject.SetActive (false);
		if (9 == PlayerPrefs.GetInt ("level") || 19 == PlayerPrefs.GetInt("level")) {
			Invoke ("endstarttext", 10);
			Invoke ("spawn", 9f);
		}else{
			Invoke ("endstarttext", 8);
			Invoke ("spawn", 7f);
		}
	}
	public void LoadScene(string Scene)
	{
		SceneManager.LoadScene (Scene);
	}
	public void SetLevel()
	{
		PlayerPrefs.SetInt ("level", PlayerPrefs.GetInt ("level") + 1);
		resetlevel ();
	}

	public void aliendead()
	{
		ufoamount = ufoamount - 1;
	}
	public void enragemode(){
		RageMode.text = "Boss Has entered Rage Mode!\nHe can no longer be frozen.";
		Invoke("endragetext", 5);
	}
	public void endragetext()
	{
		RageMode.text = "";
	}
	public void spawnRegArrowRaid()
	{
		if(0 < PlayerPrefs.GetInt("RegArrowRaidAmount")){
		Instantiate (RegArrowRaid);
		Debug.Log("Enter Raid");
		PlayerPrefs.SetInt ("RegArrowRaidAmount", PlayerPrefs.GetInt ("RegArrowRaidAmount") -1);
		}
		Debug.Log(PlayerPrefs.GetInt("RegArrowRaidAmount").ToString());
	}
	public void spawnFireArrowRaid()
	{
		if(0 < PlayerPrefs.GetInt("FireArrowRaidAmount")){
			Instantiate (FireArrowRaid);
			PlayerPrefs.SetInt ("FireArrowRaidAmount", PlayerPrefs.GetInt ("FireArrowRaidAmount") -1);
		}
	}
	public void spawnBombArrowRaid()
	{
		if(0 < PlayerPrefs.GetInt("BombArrowRaidAmount")){
			Instantiate (BombArrowRaid);
			PlayerPrefs.SetInt ("BombArrowRaidAmount", PlayerPrefs.GetInt ("BombArrowRaidAmount") -1);
		}
	}
	public void setupValues()
	{
		cAmount = PlayerPrefs.GetInt ("coins");
		araidAmount = PlayerPrefs.GetInt ("RegArrowRaidAmount");
		fraidAmount = PlayerPrefs.GetInt ("FireArrowRaidAmount");
		braidAmount = PlayerPrefs.GetInt ("BombArrowRaidAmount");
	}
	public void resetValues()
	{
		PlayerPrefs.SetInt ("coins", cAmount);
		PlayerPrefs.SetInt ("RegArrowRaidAmount", araidAmount);
		PlayerPrefs.SetInt ("FireArrowRaidAmount", fraidAmount);
		PlayerPrefs.SetInt ("BombArrowRaidAmount", braidAmount);
	}
}

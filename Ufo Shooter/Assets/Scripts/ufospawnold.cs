using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ufospawnold : MonoBehaviour {
	public GameObject ufo;
	public GameObject[] ufoslvl2to3;
	public GameObject[] ufoslvl4;
	public GameObject[] ufoslvl5;
	public GameObject[] ufoslvl6;
	public GameObject[] ufoslvl78;
	public int ufoamount;
	public float buffertime;
	public Canvas winCanvas;
	public Canvas loseCanvas;
	public int numberofufo;
	public Text starttext;
	public Text leveltext;
	public Text scoreText;
	public Text coinText;
	public Text lvl2Text;
	public Text lvl3Text;
	public Text lvl4text;
	public Text pullbackarrow;
	int levelnum;
	int levelint;
	public Animator anim;
	public Image blueufo;
	public Image redufo;
	public Image greenufo;
	public Text lvl5text;
	public bool levelDone;
	public Text loseCoinText;
	public Image yellowufo;
	int coinslost;
	public Text lvl6text;
	public Text lvl7text;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("level", 6);
		resetlevel ();
		levelDone = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (ufo.gameObject.transform.position.x <= -9f) {
			loseCanvas.gameObject.SetActive (true);
		}
		if (ufoamount <= 0) {
			winCanvas.gameObject.SetActive (true);
		}
		levelint = PlayerPrefs.GetInt ("level") + 1;
		leveltext.text = "level " + levelint;
		scoreText.text = "score: " + PlayerPrefs.GetInt ("Score");

		coinText.text = "coins: " + PlayerPrefs.GetInt ("coins");
		SetCoinLoss ();
	}

	void spawn()
	{
		if (0 == PlayerPrefs.GetInt ("level")) {
			GameObject newUFO = Instantiate(ufo);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
		}
		if (1 <= PlayerPrefs.GetInt ("level") && 3 > PlayerPrefs.GetInt ("level")) {
			GameObject newUFO = Instantiate(ufoslvl2to3[Random.Range(0, ufoslvl2to3.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
		}
		if (3 <= PlayerPrefs.GetInt ("level") && 4 > PlayerPrefs.GetInt ("level")) {
			GameObject newUFO = Instantiate(ufoslvl4[Random.Range(0, ufoslvl4.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
		}
		if (4 == PlayerPrefs.GetInt ("level")) {
			GameObject newUFO = Instantiate(ufoslvl5[Random.Range(0, ufoslvl5.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
		}
		if (5 == PlayerPrefs.GetInt ("level")) {
			GameObject newUFO = Instantiate(ufoslvl6[Random.Range(0, ufoslvl6.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
		}
		if (6 == PlayerPrefs.GetInt ("level") || 7 == PlayerPrefs.GetInt("level")) {
			GameObject newUFO = Instantiate(ufoslvl78[Random.Range(0, ufoslvl78.Length)]);
			newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
		}
		numberofufo = numberofufo - 1;	
		Invoke("StartAgain", buffertime);

	}

	public void StartAgain()
	{
		if (numberofufo > 0) {
			spawn ();
		}
	}
	public void endstarttext()
	{
		starttext.text = "";
		lvl2Text.text = "";
		lvl3Text.text = "";
		lvl4text.text = "";
		pullbackarrow.text = "";
		lvl5text.text = "";
		lvl6text.text = "";
		lvl7text.text = "";
		blueufo.gameObject.SetActive (false);
		redufo.gameObject.SetActive (false);
		greenufo.gameObject.SetActive (false);
		yellowufo.gameObject.SetActive (false);
	}
	public void faillevel()
	{
		if (levelDone == false) {
			loseCanvas.gameObject.SetActive (true);
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") - coinslost);
			if (0 >= PlayerPrefs.GetInt ("coins")) {
				PlayerPrefs.SetInt ("coins", 0);
			}
			levelDone = true;
			numberofufo = 10000000;
		}
	}
	public void resetlevel()
		{
			if (0 == PlayerPrefs.GetInt("level")) {
				buffertime = Random.Range (4.5f, 4.9f);
				ufoamount = 10;
				numberofufo = 10;
				starttext.text = "  Level 1\nit begins...";
				lvl2Text.text = "";
				lvl3Text.text = "";
				lvl4text.text = "";
				lvl5text.text = "";
			lvl6text.text = "";
			lvl7text.text = "";
				pullbackarrow.text = "Pull back \nthe arrow \nto shoot";
				blueufo.gameObject.SetActive (true);
				redufo.gameObject.SetActive (false);
			greenufo.gameObject.SetActive (false);
			yellowufo.gameObject.SetActive (false);
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 10);
			}

			if (1 == PlayerPrefs.GetInt("level")) {
				buffertime = Random.Range (4.2f, 4.5f);
				ufoamount = 15;
				numberofufo = 15;
				lvl2Text.text = "\t\t\t\t Level 2\nAnother shot necessary";
				starttext.text = "";
				lvl3Text.text = "";
				lvl4text.text = "";
			lvl5text.text = "";
			lvl6text.text = "";
			lvl7text.text = "";
			pullbackarrow.text = "";
				blueufo.gameObject.SetActive (false);
				redufo.gameObject.SetActive (true);
			greenufo.gameObject.SetActive (false);
			yellowufo.gameObject.SetActive (false);
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 15);
			}
			if (2 == PlayerPrefs.GetInt("level")) {
				buffertime = Random.Range (3.8f, 4.2f);
				ufoamount = 20;
				numberofufo = 20;
				lvl3Text.text = "  Level 3\n Incoming";
				starttext.text = "";
				lvl2Text.text = "";
				lvl4text.text = "";
			lvl5text.text = "";
			lvl6text.text = "";
			lvl7text.text = "";
			pullbackarrow.text = "";
				blueufo.gameObject.SetActive (false);
				redufo.gameObject.SetActive (false);
			greenufo.gameObject.SetActive (false);
			yellowufo.gameObject.SetActive (false);
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 25);
			}
			if (3 == PlayerPrefs.GetInt("level")) {
				buffertime = Random.Range (3.5f, 3.9f);
				ufoamount = 25;
				numberofufo = 25;
				lvl3Text.text = "";
				starttext.text = "";
				lvl2Text.text = "";
				lvl4text.text = "  Level 4\n Speedier";
			lvl5text.text = "";
			lvl6text.text = "";
			lvl7text.text = "";
			pullbackarrow.text = "";
				blueufo.gameObject.SetActive (false);
				redufo.gameObject.SetActive (false);
			greenufo.gameObject.SetActive (true);
			yellowufo.gameObject.SetActive (false);
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 35);
			}
		if(4 == PlayerPrefs.GetInt("level")){
			buffertime = Random.Range (3.2f, 3.4f);
			ufoamount = 35;
			numberofufo = 35;
			lvl3Text.text = "";
			starttext.text = "";
			lvl2Text.text = "";
			lvl4text.text = "";
			lvl6text.text = "";
			lvl7text.text = "";
			lvl5text.text = "    Level 5\nAliens Galore";
			pullbackarrow.text = "";
			blueufo.gameObject.SetActive (false);
			redufo.gameObject.SetActive (false);
			greenufo.gameObject.SetActive (false);
			yellowufo.gameObject.SetActive (false);
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 40);
		}
		if(5 == PlayerPrefs.GetInt("level")){
			buffertime = Random.Range (3.1f, 3.3f);
			ufoamount = 35;
			numberofufo = 35;
			lvl3Text.text = "";
			starttext.text = "";
			lvl2Text.text = "";
			lvl4text.text = "";
			lvl5text.text = "";
			lvl6text.text = "    Level 6\nUps and Downs";
			lvl7text.text = "";
			pullbackarrow.text = "";
			blueufo.gameObject.SetActive (false);
			redufo.gameObject.SetActive (false);
			greenufo.gameObject.SetActive (false);
			yellowufo.gameObject.SetActive (true);
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 50);
		}
		if(6 == PlayerPrefs.GetInt("level")){
			buffertime = Random.Range (3.1f, 3.2f);
			ufoamount = 35;
			numberofufo = 35;
			lvl3Text.text = "";
			starttext.text = "";
			lvl2Text.text = "";
			lvl4text.text = "";
			lvl5text.text = "";
			lvl6text.text = "";
			lvl7text.text = "    Level 7\nBye Bye Blues";
			pullbackarrow.text = "";
			blueufo.gameObject.SetActive (false);
			redufo.gameObject.SetActive (false);
			greenufo.gameObject.SetActive (false);
			yellowufo.gameObject.SetActive (false);
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 50);
		}
			Invoke ("spawn", 4f);
			winCanvas.gameObject.SetActive (false);
			loseCanvas.gameObject.SetActive (false);
			Invoke ("endstarttext", 5);
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
	public void SetCoinLoss()
	{
		loseCoinText.text = "      You lost " + coinslost + " coins\n    during the invasion";
		if (2 >= PlayerPrefs.GetInt ("level")) {
			coinslost = 50;

		}
		if (2 < PlayerPrefs.GetInt ("level") && 4 >= PlayerPrefs.GetInt ("level")) {
			coinslost = 125;
		}
		if (4 < PlayerPrefs.GetInt ("level") && 6 >= PlayerPrefs.GetInt ("level")) {
			coinslost = 175;
		}
	}
	public void aliendead()
	{
		ufoamount = ufoamount - 1;
	}
}

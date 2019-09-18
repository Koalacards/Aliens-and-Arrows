using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndlessMode : MonoBehaviour {
	public TextMeshProUGUI score;
	public GameObject blueUFO;
	public GameObject redUFO;
	public GameObject greenUFO;
	public GameObject yellowUFO;
	public GameObject orangeUFO;
	public GameObject purpleUFO;
	public GameObject pinkUFO;
	public GameObject grayUFO;
	public GameObject dblueUFO;
	public GameObject whiteUFO;
	public GameObject dgreenUFO;
	public GameObject fireArrowPlate;
	public GameObject iceArrowPlate;
	public GameObject poisonArrowPlate;
	public GameObject bombArrowPlate;
	public TextMeshProUGUI fireDamage;
	public TextMeshProUGUI poisonDamage;
	public TextMeshProUGUI bombDamage;
	public List<GameObject> ufos;
	public float buffertime;
	bool hasDone;
	public TextMeshProUGUI alertText;
	public TextMeshProUGUI startText;
	bool Added;
	bool runDone;

	public GameObject loseCanvas;
	public TextMeshProUGUI endScore;
	public TextMeshProUGUI highScore;
	public TextMeshProUGUI newHighScore;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("Lose", 0);
		loseCanvas.gameObject.SetActive(false);
		PlayerPrefs.SetInt ("EndlessScore", 0);
		PlayerPrefs.SetInt ("EScore", 0);
		ufos.Clear ();
		ufos.Add (blueUFO);
		Invoke("SpawnUFO", 4);
		buffertime = 3.3f;
		hasDone = false;
		StartCoroutine(BeginningText());
		Added = false;
		PlayerPrefs.SetInt("InScene", 0);
		runDone = false;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + PlayerPrefs.GetInt ("EndlessScore");
		if(0 == (PlayerPrefs.GetInt("EndlessScore")) % 20 && 0 != PlayerPrefs.GetInt("EndlessScore") && hasDone == false && 2.9<=buffertime)
		{
			LowerBuffer ();
			hasDone = true;
		}
		AddObjects();
		if(1 == PlayerPrefs.GetInt("Lose") && runDone == false)
		{
			Lose();
			runDone = true;
		}
	}

	public void SpawnUFO()
	{
		GameObject[] UFOs = ufos.ToArray ();
		GameObject newUFO = Instantiate(UFOs[Random.Range(0, UFOs.Length)]);
		newUFO.gameObject.transform.position = new Vector2 (10, Random.Range (-2.7f, 3.4f));
		Buffer ();
	}
		
	void Buffer()
	{
		Invoke ("SpawnUFO", buffertime);
	}
	public void LowerBuffer()
	{
		buffertime = buffertime - .05f;
		Invoke ("ResetHasDone", 8);
	}
	public void ResetHasDone()
	{
		hasDone = false;
	}
	public void Reset()
	{
		alertText.text = "";
		startText.text = "";
	}
	public IEnumerator BeginningText()
	{
		startText.text = "  3";
		yield return new WaitForSeconds(1);
		startText.text = "  2";
		yield return new WaitForSeconds(1);
		startText.text = "  1";
		yield return new WaitForSeconds(1);
		startText.text = "Go!";
		yield return new WaitForSeconds(1);
		Invoke("Reset",0);
	}
	public void AddObjects()
	{
		switch(PlayerPrefs.GetInt("EndlessScore"))
		{
			case 5:
			if(Added == false)
			{
				ufos.Add(redUFO);
				alertText.text = "Tank UFOs Inbound!";
				Added = true;
			}
			break;
			case 8:
			Reset();
			break;
			case 9:
			Added = false;
			break;
			case 10: 
			if(Added == false)
			{
				fireArrowPlate.gameObject.SetActive(true);
				fireDamage.gameObject.SetActive(true);
				alertText.text = "Fire Arrows Available!";
				Added = true;
			}
			break;
			case 13:
			Reset();
			break;
			case 14:
			Added = false;
			break;
			case 15: 
			if(Added == false)
			{
				ufos.Add(greenUFO);
				alertText.text = "Speedy UFOs Inbound!";
				Added = true;
			}
			break;
			case 18:
			Reset();
			break;
			case 19:
			Added = false;
			break;
			case 20:
			if(Added == false)
			{
				ufos.Add(yellowUFO);
				alertText.text = "Zigzag UFOs Inbound!";
				Added = true;
			}
			break;
			case 23:
			Reset();
			break;
			case 24:
			Added = false;
			break;
			case 25:
			if(Added == false)
			{
				iceArrowPlate.gameObject.SetActive(true);
				alertText.text = "Ice Arrows Available!";
				Added = true;
			}
			break;
			case 28:
			Reset();
			break;
			case 29:
			Added = false;
			break;
			case 30:
			if(Added == false)
			{
				ufos.Add(orangeUFO);
				alertText.text = "Tank Zigzag Ufos Incoming!";
				Added = true;
			}
			break;
			case 33:
			Reset();
			break;
			case 34:
			Added = false;
			break;
			case 35:
			if(Added == false)
			{
				ufos.Add(purpleUFO);
				alertText.text = "Super Tank Ufos Incoming!";
				Added = true;
			}
			break;
			case 38:
			Reset();
			break;
			case 39:
			Added = false;
			break;
			case 40:
			if(Added == false)
			{
				poisonArrowPlate.gameObject.SetActive(true);
				poisonDamage.gameObject.SetActive(true);
				alertText.text = "Poison Arrows Available!";
				Added = true;
			}
			break;
			case 43:
			Reset();
			break;
			case 44:
			Added = false;
			break;
			case 45:
			if(Added == false)
			{
				ufos.Add(pinkUFO);
				alertText.text = "Super Tank Zigzag Ufos Incoming!";
				Added = true;
			}
			break;
			case 48:
			Reset();
			break;
			case 49:
			Added = false;
			break;
			case 50:
			if(Added == false)
			{
				ufos.Add(grayUFO);
				alertText.text = "Teleport Ufos Incoming!";
				Added = true;
			}
			break;
			case 53:
			Reset();
			break;
			case 54:
			Added = false;
			break;
			case 55:
			if(Added == false)
			{
				ufos.Add(dblueUFO);
				alertText.text = "Ultra Tank Ufos Incoming!";
				Added = true;
			}
			break;
			case 58:
			Reset();
			break;
			case 59:
			Added = false;
			break;
			case 60:
			if(Added == false)
			{
				bombArrowPlate.gameObject.SetActive(true);
				bombDamage.gameObject.SetActive(true);
				alertText.text = "Bomb Arrows Available!";
				Added = true;
			}
			break;
			case 63:
			Reset();
			break;
			case 64:
			Added = false;
			break;
			case 65:
			if(Added == false)
			{
				ufos.Add(whiteUFO);
				alertText.text = "Ultra Tank Zigzag Ufos Incoming!";
				Added = true;
			}
			break;
			case 68:
			Reset();
			break;
			case 69:
			Added = false;
			break;
			case 70:
			if(Added == false)
			{
				ufos.Add(dgreenUFO);
				alertText.text = "Super Speedy Ufos Incoming!";
				Added = true;
			}
			break;
			case 75:
			ufos.Remove(blueUFO);
			break;
			case 80:
			ufos.Remove(redUFO);
			break;
			case 85:
			ufos.Remove(yellowUFO);
			break;
			case 90:
			ufos.Remove(greenUFO);
			break;
			case 95:
			ufos.Remove(orangeUFO);
			break;
			case 100:
			ufos.Remove(purpleUFO);
			break;
		}
	}
	public void changescene(string scene)
		{
			SceneManager.LoadScene(scene);
		}

	public void Lose()
	{
		loseCanvas.gameObject.SetActive(true);
		int endscore = PlayerPrefs.GetInt("EndlessScore");
		endScore.text = "Score: " + endscore;
		if(endscore> PlayerPrefs.GetInt("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore", endscore);
			highScore.text = "Highscore: " + endscore;
			newHighScore.gameObject.SetActive(true);
		}else{
			highScore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore");
			newHighScore.gameObject.SetActive(false);
		}
	}
}

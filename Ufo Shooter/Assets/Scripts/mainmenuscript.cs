using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class mainmenuscript : MonoBehaviour {
	public TextMeshProUGUI leveltext;
	public TextMeshProUGUI highScoreText;

	public GameObject[] ufos;
	// Use this for initialization
	void Start () {
		leveltext.text = "Level: " + (PlayerPrefs.GetInt ("level") + 1);
		highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore");
		Invoke ("spawn", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void spawn()
	{
		GameObject ufo = Instantiate (ufos [Random.Range (0, ufos.Length)]);
		ufo.transform.position = new Vector2 (10, Random.Range (2, 4.5f));
		Invoke ("RepeatSpawn", 2.5f);
	}

	public void RepeatSpawn()
	{
		spawn ();
	}

	public void changescene(string scene)
	{
		SceneManager.LoadScene (scene);
	}
}

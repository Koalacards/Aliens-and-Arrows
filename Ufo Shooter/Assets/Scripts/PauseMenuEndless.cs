using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuEndless : MonoBehaviour {
	public GameObject Menu;
	private ArrowEndless aEndless;
	void Start()
	{
		PlayerPrefs.SetInt ("Pause", 0);
		Menu.gameObject.SetActive (false);
		aEndless = FindObjectOfType<ArrowEndless> ();
	}
	public void Pause()
	{
		PlayerPrefs.SetInt ("Pause", 1);
		aEndless.StartCoroutine (aEndless.respawnArrow (0));
		Menu.gameObject.SetActive (true);
	}
	public void Resume()
	{
		PlayerPrefs.SetInt ("Pause", 0);
		Menu.gameObject.SetActive (false);
	}

	public void MainMenu()
	{
		PlayerPrefs.SetInt ("Pause", 0);
		SceneManager.LoadScene ("MainMenu");
	}
}

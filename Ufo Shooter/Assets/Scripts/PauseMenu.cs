using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public GameObject Menu;
	private ufospawn ufoSpawn;
	private attemptedscript atscript;
	void Start()
	{
		PlayerPrefs.SetInt ("Pause", 0);
		Menu.gameObject.SetActive (false);
		ufoSpawn = FindObjectOfType<ufospawn> ();
		atscript = FindObjectOfType<attemptedscript> ();
	}
	public void Pause()
	{
		PlayerPrefs.SetInt ("Pause", 1);
		atscript.StartCoroutine (atscript.respawnArrow (0));
		Menu.gameObject.SetActive (true);
	}
	public void Resume()
	{
		PlayerPrefs.SetInt ("Pause", 0);
		Menu.gameObject.SetActive (false);
	}

	public void MainMenu()
	{
		ufoSpawn.resetValues ();
		PlayerPrefs.SetInt ("Pause", 0);
		SceneManager.LoadScene ("MainMenu");
	}
}

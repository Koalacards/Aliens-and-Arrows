using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SuperSpeedyUfo: MonoBehaviour {
	public float speed;
	public int damage;
	private ufospawn uf;
	bool noIce = true;
	private SpriteRenderer spr;
	public Sprite regufo;
	public Sprite frozenufo;
	public Sprite explosion1;
	public Sprite explosion2;
	bool aliendead;
	public Sprite poisonedufo;
	public TextMeshProUGUI damageText;
	// Use this for initialization
	void Start () {
		damage = 10;
		uf = FindObjectOfType<ufospawn> ();
		spr = FindObjectOfType<SpriteRenderer> ();
		aliendead = false;
	}

	// Update is called once per frame
	void Update () {
		damageText.text = "" + damage;
		if (transform.position.x <= -9.4) {
			PlayerPrefs.SetInt ("Lose", 1);
			Destroy (this.gameObject);
		}
		if (damage > 0) {

			if (noIce == true) {
				spr.sprite = regufo;
			}
			if (noIce == false) {
				spr.sprite = frozenufo;
			}
		}
	}
	void FixedUpdate()
	{
		if (damage <= 0) {
			if (aliendead == false) {
				die ();
				aliendead = true;
			}
		}
		if (noIce == true && damage > 0 && 0 == PlayerPrefs.GetInt("Pause")) {
			transform.Translate (Vector2.left * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("arrow")) {
			damage = damage - 10;
		}

		if (other.CompareTag ("firearrow")) {
			damage = damage - 20;
			noIce = true;
		}

		if (other.CompareTag ("icearrow")) {
			noIce = false;
			Invoke ("thaw", 5);
		}
		if (other.CompareTag ("poisonarrow")){
			StartCoroutine (poison ());
		}

		if(other.CompareTag ("bombarrow")) {
			damage = damage - 40;
		}  
	}
	public void thaw()
	{
		noIce = true;
	}
	public void die()
	{
		StartCoroutine (death ());
	}
	IEnumerator death()
	{
		Destroy (damageText);
		yield return new WaitForSecondsRealtime (.0001f);
		spr.sprite = explosion1;
		yield return new WaitForSecondsRealtime (.1f);
		spr.sprite = explosion2;
		yield return new WaitForSecondsRealtime (.1f);
		Destroy (this.gameObject);
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 1000);
		PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 5);
		PlayerPrefs.SetInt("EndlessScore", PlayerPrefs.GetInt("EndlessScore") + 1);
	
		if(1 ==PlayerPrefs.GetInt("InScene")){
			uf.aliendead ();
		}

	}
	IEnumerator poison()
	{
		for (int i = 0; i < 3; i++) {
			if (noIce == true) {
				spr.sprite = regufo;
				yield return new WaitForSeconds (1.2f);
				damage = damage - 10;
				spr.sprite = poisonedufo;
				yield return new WaitForSeconds (.08f);
			}
			if (noIce == false) {
				spr.sprite = frozenufo;
				yield return new WaitForSeconds (1.2f);
				damage = damage - 10;
				spr.sprite = poisonedufo;
				yield return new WaitForSeconds (.08f);
			}
		}
	}
}

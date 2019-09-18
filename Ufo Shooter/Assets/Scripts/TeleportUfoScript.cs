using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeleportUfoScript : MonoBehaviour {
	public float speed;
	public int damage;
	private ufospawn uf;
	private SpriteRenderer sp;
	public Sprite damagedufo;
	bool noIce = true;
	public Sprite regufo;
	public Sprite frozenregufo;
	public Sprite frozendamagedufo;
	public Sprite explosion1;
	public Sprite explosion2;
	bool aliendead;
	public Sprite poisonedufo;
	public GameObject particleStream;
	public TextMeshProUGUI damageText;
	// Use this for initialization
	void Start () {
		damage = 20;
		uf = FindObjectOfType<ufospawn> ();
		sp = FindObjectOfType<SpriteRenderer> ();
		aliendead = false;
		InvokeRepeating ("Teleport", 2.0f, 1.2f);
	}

	// Update is called once per frame
	void Update () {
		if (damage > 10) {
			damageText.text = "" + damage;
		} else {
			damageText.text = " " + damage;
		}
		if (damage <= 10 && damage > 0) {
			if (noIce == true) {
				sp.sprite = damagedufo;
			}

			if (noIce == false) {
				sp.sprite = frozendamagedufo;
			}
		}
		if (damage > 10) {
			if (noIce == true) {
				sp.sprite = regufo;
			}

			if (noIce == false) {
				sp.sprite = frozenregufo;
			}
		}


		if (transform.position.x <= -9.4) {
			PlayerPrefs.SetInt ("Lose", 1);
			Destroy (this.gameObject);
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
		
		if (other.CompareTag ("arrow") || other.CompareTag ("arrowraid")) {
			damage = damage - 10;
		}

		if (other.CompareTag ("firearrow") || other.CompareTag ("firearrowraid")) {
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

	    if(other.CompareTag ("bombarrow") || other.CompareTag ("bombarrowraid")) {
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
	public void Teleport()
	{
		particleStream.gameObject.SetActive (false);
		transform.position= new Vector2(transform.position.x, Random.Range(-2.7f, 3.4f));
		particleStream.gameObject.SetActive (true);
	}
	IEnumerator death()
	{
		Destroy (damageText);
		yield return new WaitForSecondsRealtime (.0001f);
		sp.sprite = explosion1;
		yield return new WaitForSecondsRealtime (.1f);
		sp.sprite = explosion2;
		yield return new WaitForSecondsRealtime (.1f);
		Destroy (this.gameObject);

		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 1000);
		PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 20);
		PlayerPrefs.SetInt("EndlessScore", PlayerPrefs.GetInt("EndlessScore") + 1);
	
		if(1 ==PlayerPrefs.GetInt("InScene")){
			uf.aliendead ();
		}

	}
	IEnumerator poison()
	{
		for (int i = 0; i < 3; i++) {
			if (damage > 10) {
				if (noIce == true) {
					sp.sprite = regufo;
					yield return new WaitForSeconds (1.2f);
					damage = damage - 10;
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}
				if (noIce == false) {
					sp.sprite = frozenregufo;
					yield return new WaitForSeconds (1.2f);
					damage = damage - 10;
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}

			}
			if (damage <=10) {
				if (noIce == true) {
					sp.sprite = damagedufo;
					yield return new WaitForSeconds (1.2f);
					damage = damage - 10;
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}
				if (noIce == false) {
					sp.sprite = frozendamagedufo;
					yield return new WaitForSeconds (1.2f);
					damage = damage - 10;
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}

			}
		}
	}

}

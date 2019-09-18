using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UltraTankUFOScript: MonoBehaviour {
	public float speed;
	public int damage;
	private ufospawn uf;
	private SpriteRenderer sp;
	public Sprite Eighty;
	bool noIce = true;
	public Sprite regufo;
	public Sprite frozenregufo;
	public Sprite EightyFrozen;
	public Sprite FortyFrozen;
	public Sprite Forty;
	public Sprite explosion1;
	public Sprite explosion2;
	bool aliendead;
	public Sprite poisonedufo;
	public TextMeshProUGUI damageText;
	// Use this for initialization
	void Start () {
		damage = 60;
		uf = FindObjectOfType<ufospawn> ();
		sp = FindObjectOfType<SpriteRenderer> ();
		aliendead = false;
	}

	// Update is called once per frame
	void Update () {
		if (damage > 10) {
			damageText.text = "" + damage;
		} else {
			damageText.text = " " + damage;
		}
		if (damage > 40) {
			if (noIce == true) {
				sp.sprite = regufo;
			}

			if (noIce == false) {
				sp.sprite = frozenregufo;
			}
		} else if (damage > 20) {
			if (noIce == true) {
				sp.sprite = Eighty;
			}

			if (noIce == false) {
				sp.sprite = EightyFrozen;
			}
		}else if (damage > 0) {
			if (noIce == true) {
				sp.sprite = Forty;
			}

			if (noIce == false) {
				sp.sprite = FortyFrozen;
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
		PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 35);
		PlayerPrefs.SetInt("EndlessScore", PlayerPrefs.GetInt("EndlessScore") + 1);
	
		if(1 ==PlayerPrefs.GetInt("InScene")){
			uf.aliendead ();
		}

	}
	IEnumerator poison()
	{
		for (int i = 0; i < 3; i++) {
			if (damage > 40) {
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

			} else if (damage > 20) {
				if (noIce == true) {
					sp.sprite = Eighty;
					yield return new WaitForSeconds (1.2f);
					damage = damage - 10;
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}
				if (noIce == false) {
					sp.sprite = EightyFrozen;
					yield return new WaitForSeconds (1.2f);
					damage = damage - 10;
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}

			} else if (damage > 0) {
				if (noIce == true) {
					sp.sprite = Forty;
					yield return new WaitForSeconds (1.2f);
					damage = damage - 10;
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}
				if (noIce == false) {
					sp.sprite = FortyFrozen;
					yield return new WaitForSeconds (1.2f);
					damage = damage - 10;
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}

			}
		}
	}

}

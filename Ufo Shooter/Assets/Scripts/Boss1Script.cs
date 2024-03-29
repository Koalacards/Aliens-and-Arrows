using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Boss1Script : MonoBehaviour {
	public float speed;
	public int damage;
	private ufospawn uf;
	private SpriteRenderer sp;
	public Sprite damagedufo;
	bool noIce = true;
	public Sprite regufo;
	public Sprite frozenregufo;
	public Sprite explosion1;
	public Sprite explosion2;
	bool aliendead;
	public Sprite takeDamagesprite;
	bool tookdamage;
	public TextMeshProUGUI damageText;
	// Use this for initialization
	void Start () {
		damage = 400;
		uf = FindObjectOfType<ufospawn> ();
		sp = FindObjectOfType<SpriteRenderer> ();
		aliendead = false;
	}

	// Update is called once per frame
	void Update () {
		if(damage <= 10)
		{
			damageText.text = "  " + damage;
		}else if(damage <= 100)
		{
			damageText.text = " " + damage;
		}else{
			damageText.text = "" + damage;
		}
		if (tookdamage == false) {
			if (damage <= 150 && damage > 0) {
				speed = .65f;
				sp.sprite = damagedufo;
				noIce = true;
				uf.enragemode ();
			}
			if (damage > 150) {
				if (noIce == true) {
					sp.sprite = regufo;
				}

				if (noIce == false) {
					sp.sprite = frozenregufo;
				}
			}
		}


		if (transform.position.x <= -9.4) {
			uf.faillevel ();
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
		yield return new WaitForSecondsRealtime (.0001f);
		sp.sprite = explosion1;
		yield return new WaitForSecondsRealtime (.5f);
		sp.sprite = explosion2;
		yield return new WaitForSecondsRealtime (.5f);
		Destroy (this.gameObject);

		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 1000);
		PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 250);
		uf.aliendead ();

	}
	IEnumerator takeDamage()
	{
		tookdamage = true;
	if(damage > 150)
		{
		if(noIce == true)
			{
				sp.sprite = takeDamagesprite;
				yield return new WaitForSeconds(.08f);
				sp.sprite = regufo;
			}
			if (noIce == false) {
				sp.sprite = takeDamagesprite;
				yield return new WaitForSeconds(.08f);
				sp.sprite = frozenregufo;
			}
		}else{
			sp.sprite = takeDamagesprite;
			yield return new WaitForSeconds(.08f);
			sp.sprite = damagedufo;
		}
		tookdamage = false;
	}
}

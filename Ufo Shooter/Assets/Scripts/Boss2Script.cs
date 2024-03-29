using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Boss2Script : MonoBehaviour {
	public float speed;
	public int damage;
	private ufospawn uf;
	private SpriteRenderer sp;
	bool noIce = true;
	public Sprite regufo;
	public Sprite frozenregufo;
	public Sprite enragedufo;
	public Sprite explosion1;
	public Sprite explosion2;
	bool aliendead;
	public Sprite poisonedufo;
	public Sprite takeDamagesprite;
	public GameObject particle;
	bool tookDamage;
	public TextMeshProUGUI damageText;
	// Use this for initialization
	void Start () {
		damage = 600;
		uf = FindObjectOfType<ufospawn> ();
		sp = FindObjectOfType<SpriteRenderer> ();
		aliendead = false;
		tookDamage = false;
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
		if (tookDamage == false) {
			if (damage <= 200 && damage > 0) {
				sp.sprite = enragedufo;
				speed = .4f;
				uf.enragemode ();
				noIce = true;
			}
			if (damage > 200) {
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
		if (other.CompareTag ("arrow")||other.CompareTag("arrowraid")) {
			StartCoroutine(takeDamage());
			damage = damage - 10;
		}
		if (other.CompareTag ("firearrow")||other.CompareTag("firearrowraid")) {
			StartCoroutine(takeDamage());
			damage = damage - 20;
			if (transform.localScale.x > .3f) {
				transform.localScale = new Vector2 (transform.localScale.x - .005f, transform.localScale.y - .005f);

			}

		}
		if (other.CompareTag ("icearrow")) {
			if (damage > 200) {
				noIce = false;
				Invoke ("thaw", 5);
				particle.gameObject.SetActive (false);
				if (transform.localScale.x > .3f) {
					transform.localScale = new Vector2 (transform.localScale.x - .025f, transform.localScale.y - .025f);

				}
			}
		}
		if (other.CompareTag ("poisonarrow")) {
			StartCoroutine (poison ());
		}

	}
	public void thaw()
	{
		noIce = true;
		particle.gameObject.SetActive (true);
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
		PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 500);
		uf.aliendead ();

	}
	IEnumerator poison()
	{
		for (int i = 0; i < 3; i++) {
			if (damage > 200) {
				if (noIce == true) {
					sp.sprite = regufo;
					yield return new WaitForSeconds (1.2f);
					damage = damage - 10;
					if (transform.localScale.x > .3f) {
						transform.localScale = new Vector2 (transform.localScale.x - .002f, transform.localScale.y - .002f);
					}
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}
				if (noIce == false) {
					sp.sprite = frozenregufo;
					yield return new WaitForSeconds (1.2f);
					damage = damage - 10;
					if (transform.localScale.x > .3f) {
						transform.localScale = new Vector2 (transform.localScale.x - .002f, transform.localScale.y - .002f);
					}
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}

			}
			if (damage <=200) {
				sp.sprite = enragedufo;
				yield return new WaitForSeconds (1.2f);
				damage = damage - 10;
				if (transform.localScale.x > .3f) {
					transform.localScale = new Vector2 (transform.localScale.x - .002f, transform.localScale.y - .002f);
				}
				sp.sprite = poisonedufo;
				yield return new WaitForSeconds (.08f);

			}
		}
	}

	IEnumerator takeDamage()
	{
		tookDamage = true;
		if(damage > 200)
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
		}
		if(damage <= 200){
			sp.sprite = takeDamagesprite;
			yield return new WaitForSeconds(.08f);
			sp.sprite = enragedufo;
		}
		tookDamage = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UltraTankZigZag: MonoBehaviour {
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
	private Rigidbody2D rb2d;
	float yvel = .6f;
	float oppyvel;
	bool goingUp;
	public TextMeshProUGUI damageText;
	// Use this for initialization
	void Start () {
		damage = 80;
		uf = FindObjectOfType<ufospawn> ();
		sp = FindObjectOfType<SpriteRenderer> ();
		aliendead = false;
		oppyvel = -1 * yvel;
		goingUp = true;
		rb2d = FindObjectOfType<Rigidbody2D> ();
		rb2d.velocity = new Vector2 (0, yvel);
		rb2d.bodyType = RigidbodyType2D.Dynamic;
	}

	// Update is called once per frame
	void Update () {
		if (damage > 10) {
			damageText.text = "" + damage;
		} else {
			damageText.text = " " + damage;
		}
		if (damage > 50) {
			if (noIce == true) {
				sp.sprite = regufo;
			}

			if (noIce == false) {
				sp.sprite = frozenregufo;
			}
		} else if (damage > 30) {
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
			thawScript();
			transform.Translate (Vector2.left * speed * Time.deltaTime);
			if(transform.position.y >= 3f) {
				rb2d.velocity= new Vector2(0, oppyvel);
				goingUp = false;
			}
			if (transform.position.y <= -2.3f) {
				rb2d.velocity = new Vector2(0, yvel);
				goingUp = true;
			}
		}
		if(1 == PlayerPrefs.GetInt("Pause"))
		{
			rb2d.bodyType = RigidbodyType2D.Static;
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
			rb2d.bodyType = RigidbodyType2D.Static;
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
		thawScript();
	}
	public void thawScript()
	{
		if(noIce == true)
		{
			if (goingUp == true) {
			rb2d.velocity = new Vector2 (0, yvel);
			}
			if (goingUp == false) {
			rb2d.velocity = new Vector2 (0, oppyvel);
			}
		}
		rb2d.bodyType = RigidbodyType2D.Dynamic;
		
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
		PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 45);
		PlayerPrefs.SetInt("EndlessScore", PlayerPrefs.GetInt("EndlessScore") + 1);
	
		if(1 ==PlayerPrefs.GetInt("InScene")){
			uf.aliendead ();
		}

	}
	IEnumerator poison()
	{
		for (int i = 0; i < 3; i++) {
			if (damage > 50) {
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

			} else if (damage > 30) {
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

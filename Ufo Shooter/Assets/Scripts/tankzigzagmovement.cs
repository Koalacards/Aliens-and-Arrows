using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tankzigzagmovement : MonoBehaviour {
	public float speed;
	public int damage;
	private ufospawn uf;
	private SpriteRenderer sp;
	public Sprite damagedufo;
	bool noIce = true;
	public Sprite regufo;
	public Sprite frozenregufo;
	public Sprite frozendamagedufo;
	float yvel = .7f;
	float oppyvel;
	private Rigidbody2D rb2d;
	public Sprite poisonedufo;
	bool aliendead;
	bool goingUp;
	public TextMeshProUGUI damageText;
	public ParticleSystem moveParticle;
	public ParticleSystem endParticle;
	public Sprite small;
	// Use this for initialization
	void Start () {
		damage = 20;
		uf = FindObjectOfType<ufospawn> ();
		rb2d = FindObjectOfType<Rigidbody2D> ();
		sp = FindObjectOfType<SpriteRenderer> ();
		aliendead = false;
		oppyvel = yvel * -1f;
		rb2d.velocity = new Vector2(0, yvel);
		rb2d.bodyType = RigidbodyType2D.Dynamic;
		goingUp = true;
		endParticle.Stop();
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
			thawScript();
			transform.Translate (Vector2.left * speed * Time.deltaTime);
			if(transform.position.y >= 3.4f) {
				rb2d.velocity= new Vector2(0, oppyvel);
				goingUp = false;
			}
			if (transform.position.y <= -2.7f) {
				rb2d.velocity = new Vector2(0, yvel);
				goingUp = true;
			}
		}
		if(1== PlayerPrefs.GetInt("Pause"))
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
		playDestructionParticle();
		yield return new WaitForSecondsRealtime (.2f);
		Destroy (this.gameObject);

		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 1000);
		PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 15);
		PlayerPrefs.SetInt("EndlessScore", PlayerPrefs.GetInt("EndlessScore") + 1);
	
		if(1 ==PlayerPrefs.GetInt("InScene")){
			uf.aliendead ();
		}

	}
	public void playDestructionParticle() {

		Destroy (damageText);
		sp.sprite = small;
		moveParticle.gameObject.SetActive(false);

		endParticle.Play();
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

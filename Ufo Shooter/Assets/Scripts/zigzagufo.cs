using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class zigzagufo : MonoBehaviour {
	public float speed;
	public int damage;
	private ufospawn uf;
	bool noIce = true;
	private SpriteRenderer spr;
	public Sprite frozenufo;
	public Sprite regularufo;
	float yvel = .7f;
	float oppyvel;
	private Rigidbody2D rb2d;
	bool aliendead;
	bool goingUp;
	public TextMeshProUGUI damageText;
	public ParticleSystem endParticle;
	public ParticleSystem moveParticle;
	public Sprite small;
	// Use this for initialization
	void Start () {
		damage = 10;
		uf = FindObjectOfType<ufospawn> ();
		spr = FindObjectOfType<SpriteRenderer> ();
		rb2d = FindObjectOfType<Rigidbody2D> ();
		oppyvel = yvel * -1f;
		rb2d.velocity = new Vector2(0, yvel);
		rb2d.bodyType = RigidbodyType2D.Dynamic;
		goingUp = true;
		aliendead = false;
		endParticle.Stop();
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
				spr.sprite = regularufo;
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
			thawScript();
			transform.Translate (Vector2.left * speed * Time.deltaTime);
			if (transform.position.y >= 3.4f) {
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
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 10);
		PlayerPrefs.SetInt("EndlessScore", PlayerPrefs.GetInt("EndlessScore") + 1);
	
		if(1 ==PlayerPrefs.GetInt("InScene")){
			uf.aliendead ();
		}
	}

	public void playDestructionParticle() {

		Destroy (damageText);
		spr.sprite = small;
		moveParticle.gameObject.SetActive(false);

		endParticle.Play();
	}
}
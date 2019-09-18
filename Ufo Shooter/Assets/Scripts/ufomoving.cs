using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ufomoving : MonoBehaviour {
	public float speed;
	public int damage;
	private ufospawn uf;
	bool noIce = true;
	private SpriteRenderer spr;
	public Sprite frozenufo;
	public Sprite blueufo;
	bool aliendead;
	public TextMeshProUGUI damageText;
	public ParticleSystem moveParticle;
	public ParticleSystem endParticle;
	public Sprite small;
	// Use this for initialization
	void Start () {
		damage = 10;
		uf = FindObjectOfType<ufospawn> ();
		spr = FindObjectOfType<SpriteRenderer> ();
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
				spr.sprite = blueufo;
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
		playDestructionParticle();
		yield return new WaitForSeconds(0.2f);
		Destroy (this.gameObject);

		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 1000);
		PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 5);
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

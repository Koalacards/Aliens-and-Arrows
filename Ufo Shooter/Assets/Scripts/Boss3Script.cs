using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Boss3Script : MonoBehaviour {
	public float speed;
	public int damage;
	private ufospawn uf;
	private SpriteRenderer sp;
	bool noIce = true;
	public Sprite regufo;
	public Sprite frozenregufo;
	public Sprite damagedufo;
	public Sprite frozendamagedufo;
	public Sprite explosion1;
	public Sprite explosion2;
	bool aliendead;
	public Sprite poisonedufo;
	public Sprite takeDamagesprite;
	public GameObject particle;
	bool tookDamage;

	public Sprite regHatch;

	public Sprite damagedHatch;

	public BoxCollider2D hatchCollider;

	public PolygonCollider2D bigCollider;

	public TextMeshProUGUI damageText;

	public float buffertime;

	public bool doneCycleOne;

	// Use this for initialization
	void Start () {
		damage = 800;
		uf = FindObjectOfType<ufospawn> ();
		sp = FindObjectOfType<SpriteRenderer> ();
		aliendead = false;
		tookDamage = false;
		bigCollider.enabled = false;
		doneCycleOne = false;
	}

	// Update is called once per frame
	void Update () {
		if(damage <= 10)
		{
			damageText.text = "   " + damage;
		}else if(damage <= 100)
		{
			damageText.text = "  " + damage;
		}else{
			damageText.text = "" + damage;
		}
		if(noIce == false&& tookDamage == false)
		{
			hatchCollider.enabled = false;
			doneCycleOne = false;
			if(damage > 200)
			{
				sp.sprite = frozenregufo;
			}
			if(damage <= 200 && damage > 0)
			{
				sp.sprite = damagedufo;
			}
		}else if (doneCycleOne == false){
			StartCoroutine(CycleOne());
			doneCycleOne = true;
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
		if (noIce == true && damage > 0) {
			transform.Translate (Vector2.left * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("arrow") || other.CompareTag ("arrowraid")) {
			if(noIce == false)
			{
				StartCoroutine (takeDamage ());
				damage = damage - 10;
			}
		}
		if (other.CompareTag ("firearrow") || other.CompareTag ("firearrowraid")) {
			if(noIce == false)
			{
				StartCoroutine (takeDamage ());
				damage = damage - 20;
			}
		}

		if (other.CompareTag ("poisonarrow")) {
			if(noIce == false)
			{
				StartCoroutine (poison ());
			}
		}
		if (other.CompareTag ("bombarrow") || other.CompareTag ("bombarrowraid")) {
			if(noIce == false)
			{
				StartCoroutine (takeDamage ());
				damage = damage - 40;
			}
		}  
		if (other.CompareTag ("icearrow")) {
			bigCollider.enabled = true;
			noIce = false;
			particle.gameObject.SetActive (false);
			Invoke ("thaw", buffertime);
		}

	}
	public void thaw()
	{
		noIce = true;
		bigCollider.enabled = false;
		particle.gameObject.SetActive (true);
	}
	public void die()
	{
		StartCoroutine (death ());
	}
	IEnumerator death()
	{
		yield return new WaitForSecondsRealtime (.0001f);
		sp.sprite = explosion1;
		yield return new WaitForSecondsRealtime (.1f);
		sp.sprite = explosion2;
		yield return new WaitForSecondsRealtime (.1f);
		Destroy (this.gameObject);

		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 100000000);
		PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 50000000);
		uf.aliendead ();

	}
	IEnumerator poison()
	{
		for (int i = 0; i < 8; i++) {
			if (damage > 200) {
				if (noIce == true) {
					sp.sprite = regufo;
					yield return new WaitForSeconds (.8f);
					damage = damage - 5;
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}
				if (noIce == false) {
					sp.sprite = frozenregufo;
					yield return new WaitForSeconds (.8f);
					damage = damage - 5;
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}

			}
			if (damage <=200) {
				if (noIce == true) {
					sp.sprite = damagedufo;
					yield return new WaitForSeconds (.8f);
					damage = damage - 5;
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}
				if (noIce == false) {
					sp.sprite = frozendamagedufo;
					yield return new WaitForSeconds (.8f);
					damage = damage - 5;
					sp.sprite = poisonedufo;
					yield return new WaitForSeconds (.08f);
				}
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
			if(noIce == true)
			{
			sp.sprite = takeDamagesprite;
			yield return new WaitForSeconds(.08f);
			sp.sprite = damagedufo;
			}
			if (noIce == false) {
				sp.sprite = takeDamagesprite;
				yield return new WaitForSeconds (.08f);
				sp.sprite = frozendamagedufo;
			}
		}
		tookDamage = false;
	}

	IEnumerator CycleOne()
	{
		while(noIce == true)
		{
			
			if(damage>200)
			{
				if(noIce == true)
				{
					sp.sprite = regHatch;	
					hatchCollider.enabled = true;
				}
				yield return new WaitForSeconds(2);
				if(noIce == true)
				{
					sp.sprite = regufo;
					hatchCollider.enabled = false;
				}
				yield return new WaitForSeconds(2);
			}
			if(damage <=200 && damage > 0)
			{
				if(noIce == true)
				{
					sp.sprite = damagedHatch;
					hatchCollider.enabled = true;
				}
				yield return new WaitForSeconds(2);
				if(noIce == true)
				{
					sp.sprite = damagedufo;	
					hatchCollider.enabled = false;
				}
				yield return new WaitForSeconds(2);
			}
		}
	}
}
